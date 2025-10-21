
using System.Threading.Channels;
using SimpleSurveySystem;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.Contracts.ServiceContracts;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Enums;
using SimpleSurveySystem.Extensions;
using SimpleSurveySystem.Infrastructure;
using SimpleSurveySystem.Infrastructure.Repositories;
using SimpleSurveySystem.Services;
using Spectre.Console;


AppDbContext appDbContext = new AppDbContext();

IUserRepository userRepository = new UserRepository(appDbContext);
ISurveyRepository surveyRepository = new SurveyRepository(appDbContext);
IQuestionRepository questionRepository = new QuestionRepository(appDbContext);

IAuthenticationService authenticationService = new AuthenticationService(userRepository);
IQuestionService questionService = new QuestionService(questionRepository, surveyRepository);
ISurveyService surveyService = new SurveyService(surveyRepository);



Console.WriteLine("Hello, World!");
//var query = _context.Products
// .Include(p => p.Category)
// .AsQueryable();





while (true)
{
    Console.Clear();

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[mediumspringgreen]🔰 Select an action:[/]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more actions)[/]")
            .AddChoices(new[]
            {
                "Login",
                "Register",
                "Exit"
            }));
    switch (choice)
    {

        case "Login":
            LoginMenu();
            break;
        case "Register":
            Register();
            break;

        case "Exit":
            AnsiConsole.MarkupLine("[red]Exiting... Goodbye![/]");
            return;

    }
}
void LoginMenu()
{
    Console.Clear();
    var userName = AnsiConsole.Ask<string>("Enter your [green]USERNAME[/]:");
    var password = AnsiConsole.Prompt(
        new TextPrompt<string>("Enter your [green]PASSWORD[/]:")
            .PromptStyle("red")
            .Secret());

    try
    {
        authenticationService.Login(userName, password);
        switch (Session.LoggedInUser.Role)
        {
            case RoleEnum.Admin:
                AdminMenu();
                break;

            case RoleEnum.NormalUSer:
                UserMenu();
                break;

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
        return;
    }
}

void AdminMenu()
{
    do
    {
        Console.Clear();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[mediumspringgreen]🔰 Select an action:[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more actions)[/]")
                .AddChoices(new[]
                {
                    "View Surveys",
                    "Add New Surveys",
                    "Add Question to Surveys",
                    "Delete Survey",
                    "Log Out"
                }));
        switch (choice)
        {
            case "Add New Surveys":
                Console.Clear();
                Console.Write("Enter Survey Title :");
                string inPutTitle = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(inPutTitle))
                {
                    Console.WriteLine("Title Cant Be null !.");
                    Console.ReadKey();
                    break;
                }

                try
                {
                    var newSurveyId = surveyService.CreateNewSurvey(inPutTitle);
                    Console.WriteLine($"Survey created successfully with ID {newSurveyId}");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    break;
                }
                break;

            case "Add Question to Surveys":
                Console.Clear();
                var surveysm = surveyService.GetSurveysList();
                ConsolePainter.WriteTable(surveysm);
                Console.Write("Enter Survey ID to add question (00-for back) :");
                string inputStrSurveyIdQ = Console.ReadLine()!;
                if (inputStrSurveyIdQ == "00")
                {
                    break;
                }
                bool checkInPutSurveyIDQ = int.TryParse(inputStrSurveyIdQ, out int inPutSurveyIdQ);

                if (!surveyService.SurveyExist(inPutSurveyIdQ))
                {
                    Console.WriteLine("Invalid Survey ID !");
                    Console.ReadKey();
                    break;
                }

                Console.Write("Enter Question Title : ");
                string inPutQuestionTitle = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(inPutQuestionTitle))
                {
                    Console.WriteLine("Question Title Cant be Null !");
                    Console.ReadKey();
                    break;
                }

                List<CreateNewOptionsForQuestionDto> optionsList = new List<CreateNewOptionsForQuestionDto>();

                int optionNum = 1;
                string optionText;
                do
                {
                    do
                    {
                        Console.Write($"Enter Text For Option Number {optionNum} : ");
                        optionText = Console.ReadLine()!;
                        if (string.IsNullOrWhiteSpace(optionText))
                        {
                            Console.WriteLine("Text Cant be Null !");
                            Console.ReadKey();
                        }
                    } while (string.IsNullOrWhiteSpace(optionText));

                    CreateNewOptionsForQuestionDto option = new CreateNewOptionsForQuestionDto()
                    {
                        OptionNumber = optionNum,
                        Text = optionText
                    };
                    optionsList.Add(option);
                    optionNum++;

                } while (optionsList.Count < 4);

                CreateNewQuestionForSurveyDto question = new CreateNewQuestionForSurveyDto()
                {
                    SurveyId = inPutSurveyIdQ,
                    QuestionTitle = inPutQuestionTitle,
                    Options = optionsList
                };

                try
                {
                    var newQuestionId = questionService.AddNewQuestion(question);
                    Console.WriteLine($"Question With Id {newQuestionId} Add to Survey With ID {inPutSurveyIdQ}");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    break;
                }

                break;
            case "View Surveys":
                Console.Clear();
                var surveys = surveyService.GetSurveysList();
                ConsolePainter.WriteTable(surveys);
                Console.Write("Enter Survey ID to see more details : (00-for back)");
                string inputStrSurveyId = Console.ReadLine()!;
                if (inputStrSurveyId == "00")
                {
                    break;
                }
                bool checkInPutSurveyID = int.TryParse(inputStrSurveyId, out int inPutSurveyId);

                try
                {
                    var showSurvey = surveyService.GetSurveyWithId(inPutSurveyId);
                    ConsolePainter.WriteTable(showSurvey);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine("1 : Show participating users");
                Console.WriteLine("2 : View Vote Details");
                Console.WriteLine("0 : Exit");
                string inPutChoice = Console.ReadLine()!;
                if (inPutChoice == "1")
                {

                }
                Console.ReadKey();
                break;
            case "Log Out":
                return;
        }

    } while (true);
}

void UserMenu()
{

}

void Register()
{

}