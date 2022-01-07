void Interface(int[] tools) // Основной интерфейс игры
{
    Intro();
    GameInit(tools);
    do { CheckWinner(MainGame(tools)); } while (GameOver());
}

void Intro() // Знакомство
{
    string name = InputData("String", "Name");
    OutputConsole("Tutorial1"); Console.Write(name); OutputConsole("Tutorial2");
}

void GameInit(int[] tools) // Пульт главного меню
{
    OutputConsole("Start");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.S: break;
        case ConsoleKey.T: ChangeDefaultStart(tools); break;
        default:
            OutputConsole("Error");
            break;
    }
}

void ChangeDefaultStart(int[] tools) // Параметры игры
{
    tools[0] = Convert.ToInt32(InputData("Int32", "StartNumb"));
    tools[1] = Convert.ToInt32(InputData("Int32", "EndNumb"));
    tools[2] = Convert.ToInt32(InputData("Int32", "CountGuess"));
}

void CheckWinner(bool winner) // Определение победителя
{
    if (winner == true) OutputConsole("Winner");
    else OutputConsole("Loser");
}

bool MainGame(int[] tools) // Основной движок игры
{
    int guessNumb = new Random().Next(tools[0], tools[1] + 1);
    int inputNumb;
    bool winner = false;
    for (int count = tools[2]; !(count <= 0 || winner); count--)
    {
        OutputConsole("Count"); Console.Write(count); Console.WriteLine();
        inputNumb = Convert.ToInt32(InputData("Int32", "Enter"));
        if (inputNumb == guessNumb) winner = true;
        if (inputNumb > guessNumb) OutputConsole("Upper");
        if (inputNumb < guessNumb) OutputConsole("Lower");
    }
    return winner;
}

bool GameOver() // Выбор начинать новую игру или выйти
{
    return InputData("bool", "Newgame") == "y";
}

void OutputConsole(string sentence) // Интерфейс вывода в консоль и анимация
{
    switch (sentence)
    {
        case "Name":
            Console.WriteLine("Enter your name:");
            break;
        case "Tutorial1":
            Console.Clear();
            System.Threading.Thread.Sleep(500);
            Console.Write("Hello, ");
            break;
        case "Tutorial2":
            Console.Write("! You are need to guess my number");
            Console.WriteLine();
            System.Threading.Thread.Sleep(3000);
            break;
        case "Start":
            Console.WriteLine("To play press S, To change setting press T");
            break;
        case "Count":
            Console.Clear();
            System.Threading.Thread.Sleep(500);
            Console.Write("Count of attempts to play: ");
            break;
        case "Enter":
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Enter your number");
            break;
        case "Winner":
            Console.Clear();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Congratulations! You guessed the number!");
            break;
        case "Loser":
            Console.Clear();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Sorry, you lose...");
            break;
        case "Newgame":
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Do you want to play new game? (y/n): ");
            break;
        case "StartNumb":
            Console.Clear();
            Console.WriteLine("Enter start number");
            break;
        case "EndNumb":
            Console.WriteLine("Enter end number:");
            break;
        case "CountGuess":
            Console.WriteLine("Enter the number of attempts:");
            break;
        case "Upper":
            Console.Clear();
            Console.WriteLine("You entered a number greater");
            System.Threading.Thread.Sleep(2000);
            break;
        case "Lower":
            Console.Clear();
            Console.WriteLine("You entered a number less");
            System.Threading.Thread.Sleep(2000);
            break;
        case "Error":
            Console.WriteLine("Your enter wrong value");
            break;
        default: break;
    }
}

string InputData(string tool, string outValue) // Проверка входных данных
{
    string inputdata = String.Empty;
    string toolUpper = tool.ToUpper();
    bool conduction = true;
    do
    {
        OutputConsole(outValue);
        inputdata = Console.ReadLine()!;
        switch (toolUpper)
        {
            case "STRING":
                conduction = String.IsNullOrEmpty(inputdata);
                break;
            case "INT32":
                conduction = (String.IsNullOrEmpty(inputdata)) || !(Int32.TryParse(inputdata, out int out1));
                break;
            case "BOOL":
                conduction = (String.IsNullOrEmpty(inputdata)) || !((inputdata == "y") || (inputdata == ("n")));
                break;
            default:
                Console.WriteLine("Uncorrect indefy format, please enter correct format of input values");
                conduction = false;
                break;
        }
    } while (conduction);
    return inputdata;
}

// Main
int[] defaultStart = { 0, 100, 7 };
Interface(defaultStart);
