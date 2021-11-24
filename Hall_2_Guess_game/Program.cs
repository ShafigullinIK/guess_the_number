//Авторы: Александр Сибирко, Artem, Лютый Олег, Маркин Антон, Юрий Грибовсикй

int createNumber(int minVal, int maxVal) //метод загадывания числа компьютером
{
    return new Random().Next(minVal, maxVal+1);
}

int requestNumber() //ввод числа с проверкой + добавить проверку на пустоту + не работает с отрицательными числами
{
    bool notExit = true;
    string s = string.Empty;
    while (notExit)
    {
        Console.Write("Введите число: ");
        s = Console.ReadLine();

        notExit = false;
        foreach (char c in s)
            if (!(c >= '0' && c <= '9'))
            {
                notExit = true;
                break;
            }

        if (notExit)
            Console.WriteLine("Ошибка ввода числа. Повторите ввод.");
    }
    return int.Parse(s);
}


bool MakeMove(int SecretNumber, int CountOfAttempts) //цикл хода игры
{
    int PlayersNumber = requestNumber();
    
    if (PlayersNumber == SecretNumber) //угадали число
    {
        Console.WriteLine($"Вы угадали число {SecretNumber} и у вас оставалось {CountOfAttempts} попыток");
        return true;
    }
    else
    {
        CountOfAttempts--;
        if (CountOfAttempts > 0)
        {
            if (PlayersNumber > SecretNumber)
            {
                //попытки ещё есть число больше чем загаданное
                Console.WriteLine($"Загаданное число меньше {PlayersNumber}");
            }
            else
            {
                //попытки ещё есть число меньше чем загаданное
                Console.WriteLine($"Загаданное число больше {PlayersNumber}");
            }
            Console.WriteLine($"У вас осталось {CountOfAttempts} попыток");
            return false;
        }
        else
        {
            //попытки закончились
            Console.WriteLine($"Попытки закончились");
            return false;
        }
    }
}

void WriteRules(int min, int max, int countAt)  //описане правил
{
    Console.WriteLine ("Компьютер загадал число от " + min + " до " + max);
    Console.WriteLine ("Попробуйте его угадать за " + countAt + " попыток");
} 

void RunGame() //основной метод запуска игры
{   
    //настрока игры
    int minNum = 1; 
    int maxNum = 100; 
    int CountOfAttempts = 10; //задаём количество

    //подготовка игры
    int SecretNumber = createNumber(minNum, maxNum); //загадываем число
    //Console.WriteLine(SecretNumber); //!!!заремарить в релизе!!! чит код - отладочный кот
    WriteRules(minNum,maxNum,CountOfAttempts); //показываем описание правил WIP
    bool GameResult = false;

    //основное тело игры
    while (GameResult == false && CountOfAttempts > 0)
    {
        GameResult = MakeMove(SecretNumber, CountOfAttempts);
        CountOfAttempts--;
    }
}

//вызов игры
RunGame();