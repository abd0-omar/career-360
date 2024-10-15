// but the current error handling hurts my eyes, hopefully only for now, or maybe I'll get used to it and that's worse
// maybe this will help a little https://github.com/karanraj-tech/result-pattern
var registeredUsername = new List<string>();
var registeredPassword = new List<string>();

void login()
{

    // Login
    Console.Write("Enter your username: ");
    var loginUserName = Console.ReadLine();
    if (string.IsNullOrEmpty(loginUserName) || loginUserName.Trim().Length == 0)
    {
        throw new ArgumentException("User can't be empty");
    }

    Console.Write("Enter your password: ");
    var loginPassword = Console.ReadLine();
    if (string.IsNullOrEmpty(loginPassword) || loginPassword.Trim().Length == 0)
    {
        throw new ArgumentException("Password cannot be empty!");
    }

    validation(loginUserName, loginPassword);
}

void register()
{
    // Register
    Console.Write("Enter a username: ");
    var user = Console.ReadLine();
    if (string.IsNullOrEmpty(user) || user.Trim().Length == 0)
    {
        throw new ArgumentException("User can't be empty");
    }

    Console.Write("Enter a password: ");
    var pass = Console.ReadLine();
    if (!string.IsNullOrEmpty(pass) && pass.Trim().Length > 0)
    {
        registeredUsername.Add(user);
        registeredPassword.Add(pass);
    }
    else
    {
        throw new ArgumentException("Password cannot be empty!");
    }
}

while (true)
{
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            // reg fn
            try
            {
                register();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
            break;
        case "2":
            // login fn
            try
            {
                login();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
            break;
        default:
            Console.WriteLine("Wrong choice");
            continue;
    }

}

void validation(string loginUserName, string loginPassword)
{
    var user_idx = registeredUsername.IndexOf(loginUserName);
    var user_pass = registeredPassword.IndexOf(loginPassword);

    if (user_idx != -1 && user_pass != -1 && user_idx == user_pass)
    {
        Console.WriteLine("Login successful! Welcome, " + loginUserName + "!");
    }
    else
    {
        // return error
        // either login failed
        // or user already exists (would ignore this one)
        throw new ArgumentException("Login failed! Incorrect username or password.");
    }
}
