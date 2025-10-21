
using SimpleSurveySystem;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.Contracts.ServiceContracts;
using SimpleSurveySystem.Enums;
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
                "Login As User",
                "Login As Admin",
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
                    "Log Out"
                }));
        switch (choice)
        {
            case "View Surveys":
                Console.Clear();

                break;
        }

    } while (true);
}

void UserMenu()
{

}

void Register()
{

}