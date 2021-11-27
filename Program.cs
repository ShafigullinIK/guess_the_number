int RequestNumber(string message) 
{
    Console.WriteLine(message);
    string line = Console.ReadLine();
    return Convert.ToInt32(line);
}

int CreateSecretNumber(int leftBound, int rightBound) {
    return new Random().Next(leftBound, rightBound);
}

bool MakeMove(int secretNumber, int countOfAttempts) 
{
    int playersNumber = RequestNumber("У вас осталось " + countOfAttempts + " попыток. " + "Введите число: ");
    if (playersNumber == secretNumber) 
    {
        return true;
    }
    if (playersNumber > secretNumber) 
    {
        Console.WriteLine("Ваше число больше того, которое мы загадали");
    } else 
    {
        Console.WriteLine("Ваше число меньше того, которое мы загадали");
    }
    return false;

}

int leftBound = 0;
int rightBound = 100;
int countOfAttempts = 7;
int secretNumber = CreateSecretNumber(leftBound, rightBound);
// int number = RequestNumber("Введите число: ");
Console.WriteLine(secretNumber);

// Ввод своего имени и объяснение правил
void Intro()
{
    Console.WriteLine("Введите свое имя");
    string name = InputData("String");
    Console.Clear();
    System.Threading.Thread.Sleep(500);
    Console.WriteLine($"Приветствую тебя, {name}! Тебе необходимо угадать число, которое я загадаю.");
    System.Threading.Thread.Sleep(3000);
}

// Здесь мы выбираем: хотим играть в своем диапазоне чисел или в диапазоне по умолчанию
void GameInit(int[] numberArr)
{
    Console.Clear();
    Console.WriteLine("Диапазон чисел вы хотите ввести сами? (y/n)");
    if (InputData("Bool") != "n")
    {
        Console.WriteLine("Введите начальный отрезок для числа");
        numberArr[0] = Convert.ToInt32(InputData("Int32"));
        Console.WriteLine("Введите конечный отрезок для числа");
        numberArr[1] = Convert.ToInt32(InputData("Int32"));
        Console.WriteLine("Введите количество попыток");
        numberArr[2] = Convert.ToInt32(InputData("Int32"));
    }
    int numberGuess = new Random().Next(numberArr[0], numberArr[1] + 1);
    numberArr[3] = numberGuess;
    Console.Clear();
}
// Проверка на правильность ввода данных
// tool - это режим работы метода: строковые данные, целочисленные данные или выбор да/нет
string InputData(string tool)
{
    string inputdata = String.Empty;
    string toolUpper = tool.ToUpper();
    bool conduction = true;
    do
    {
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

// Метод сравнения входного числа с загаданным, результат печатается в консоль
bool CheckNumber(int inputNumb, int guessNumb)
{
    Console.Clear();
    if (inputNumb > guessNumb) Console.WriteLine("Перелёт");
    else if (inputNumb < guessNumb) Console.WriteLine("Недолёт");
    return inputNumb == guessNumb;
}

// "Двигатель" программы - спрашивает нас о числе, пока мы не отгадаем или пока не закончатся попытки
bool MakeMove(int[] numberArr)
{
    bool game = false;
    for (int i = 0, leng = numberArr[2]; i < numberArr[2]; i++)
    {
        Console.WriteLine($"Количество попыток {leng--}");
        System.Threading.Thread.Sleep(500);
        Console.WriteLine("Введите число");
        if (CheckNumber(Convert.ToInt32(InputData("Int32")), numberArr[3])) return game = true;
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
    }
    return game;
}

// Результат нашей игры - либо мы выиграли, либо проиграли. Вывод результата на консоль. Спрашивает о продолжении игры.
bool GameOver(bool result)
{
    if (result == true) Console.WriteLine("Вы угадали! Поздравляем!");
    else Console.WriteLine("Вы не угадали. Игра окончена.");
    System.Threading.Thread.Sleep(1500);
    Console.Clear();
    Console.WriteLine("Желаете начать новую игру? (y/n)");
    return (InputData("bool") != "n");
}

// MAIN
// Значения по умочанию даны в виде массива и все параметры мы можем спокойно перегонять из метода в метод.
// Сначала включается приветствие Intro();
// Далее метод MakeMove спрашивает нас о числе, выдает истину или ложь об угаданном числе в метод GameOver()
// и тот дает результат выигрыша или проигрыша. Затем спрашивает нас о желании играть дальше.
// Цикл проверяет наше желание играть дальше пока мы не скажем "нет".
int[] numbers = { 0, 100, 7, 25 };
Intro();
do {GameInit(numbers);} while (GameOver(MakeMove(numbers)));
