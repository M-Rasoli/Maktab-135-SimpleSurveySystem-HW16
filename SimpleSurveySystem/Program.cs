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
using System.Linq;
using System.Threading.Channels;


AppDbContext appDbContext = new AppDbContext();

IUserRepository userRepository = new UserRepository(appDbContext);
ISurveyRepository surveyRepository = new SurveyRepository(appDbContext);
IQuestionRepository questionRepository = new QuestionRepository(appDbContext);
IVoteRepository voteRepository = new VoteRepository(appDbContext);
IOptionRepository optionRepository = new OptionRepository(appDbContext);

IAuthenticationService authenticationService = new AuthenticationService(userRepository);
IQuestionService questionService = new QuestionService(questionRepository, surveyRepository);
ISurveyService surveyService = new SurveyService(surveyRepository);
IUserService userService = new UserService(userRepository);
IVoteService voteService = new VoteService(voteRepository);
IOptionService optionService = new OptionService(optionRepository);



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
                    var participatingUsersList = surveyService.GetParticipatingUsersList(inPutSurveyId);
                    ConsolePainter.WriteTable(participatingUsersList);
                    Console.WriteLine("Press Any Key For Back");
                    Console.ReadKey();
                    break;

                }
                else if (inPutChoice == "2")
                {
                    int pageNumber = 1;
                    int pageSize = 4;
                    do
                    {
                        var showOptionsVotes = optionService.GetOptionsWithVotesDetail(inPutSurveyId, pageNumber, pageSize);
                        ConsolePainter.WriteTable(showOptionsVotes);
                        if (showOptionsVotes.Count == 0)
                        {
                            Console.WriteLine("There are no other questions.");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Press (n) Key For Next question (00 - for back)");
                        string inPutQuestion = Console.ReadLine()!;
                        if (inPutQuestion == "00")
                        {
                            break;
                        }
                        if (inPutQuestion == "n")
                        {
                            pageNumber++;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Commend ");
                            Console.ReadKey();
                            break;
                        } 

                    } while (true);
                    break;
                }
                else if (inPutChoice == "0")
                {
                    break;
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
                    "Log Out"
                }));
        switch (choice)
        {
            case "View Surveys":
                Console.Clear();
                var surveys = surveyService.GetSurveysListForNormalUsers();
                ConsolePainter.WriteTable(surveys);
                Console.Write("Enter the survey ID to participate in : (00-for back)");
                string inputStrSurveyId = Console.ReadLine()!;
                if (inputStrSurveyId == "00")
                {
                    break;
                }
                bool checkInPutSurveyID = int.TryParse(inputStrSurveyId, out int inPutSurveyId);

                if (!surveyService.SurveyExist(inPutSurveyId))
                {
                    Console.WriteLine("Invalid Survey ID !");
                    Console.ReadKey();
                    break;
                }

                if (userService.CheckIfUserAlreadyParticipateInTheSurvey(inPutSurveyId, Session.LoggedInUser.Id))
                {
                    Console.WriteLine("You have already participated in this survey.");
                    Console.ReadKey();
                    break;
                }

                var firstQuestionId = questionService.GetFirstQuestionIdOfSurvey(inPutSurveyId);
                int count = firstQuestionId;
                var lastQuestionId = questionService.GetLastQuestionIdOfSurvey(inPutSurveyId);
                string questionTitle;
                do
                {
                    Console.Clear();
                    questionTitle = questionService.GetQuestionTitle(count);
                    Console.WriteLine(questionTitle);
                    GetOptionsForQuestionWithPaginationDto getOptions = new GetOptionsForQuestionWithPaginationDto()
                    {
                        QuestionId = count
                    };
                    var options = questionService.GetOptionsOfQuestion(getOptions);
                    var showOptions = options.Select(o => new
                    {
                        OptionNumber = o.OptionNumber,
                        Text = o.OptionText
                    }).ToList();

                    ConsolePainter.WriteTable(showOptions);
                    int inPutOptionNumber;
                    do
                    {
                        Console.Write("Enter Option Number for Voting : ");
                        string inPutOptionNumberStr = Console.ReadLine()!;
                        bool checkInPutOptionNum = int.TryParse(inPutOptionNumberStr, out inPutOptionNumber);
                        if (inPutOptionNumber > 5 || inPutOptionNumber < 1)
                        {
                            Console.WriteLine("Invalid Option number");
                            Console.ReadKey();
                        }
                        else
                        {
                            break;
                        }

                    } while (true);

                    var optionId = options.FirstOrDefault(o => o.OptionNumber == inPutOptionNumber).OptionId;
                    CreateVoteDto vote = new CreateVoteDto()
                    {
                        OptionId = optionId,
                        QuestionId = count,
                        SurveyId = inPutSurveyId,
                        UserId = Session.LoggedInUser.Id
                    };
                    try
                    {
                        var printNumber = voteService.CreateNewVote(vote);
                        Console.WriteLine($"You just Chose OptionNumber {printNumber} !");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                    }
                    Console.WriteLine("Enter (n) for next Question");
                    string inNext = Console.ReadLine()!;
                    if (inNext == "n")
                    {
                        count++;
                    }

                    if (count > lastQuestionId)
                    {
                        Console.WriteLine("tnx for ur work");
                        Console.ReadKey();
                        break;
                    }
                } while (true);

                break;
            case "Log Out":
                return;
        }
    } while (true);
}

void Register()
{

}