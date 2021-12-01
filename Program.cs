int secret, min, max;
int countOfAttempts;
int b = 0;

int RequestNumber()
{
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int GenNumber(int min, int max)
{
    int number = new Random().Next(min, max+1);
    return number;
}

int MakeMove(int SecretNumber, int CountOfAttempts)
{
    if (CountOfAttempts != 0)
    {
    Console.Write("Введите число: ");
    int recNum = RequestNumber();
        if (recNum == SecretNumber)
        {
            return 1;
        }
        else {
            if (recNum > SecretNumber)
            {
                Console.WriteLine("Ваше число больше загаданного.");
            }
            else if (recNum < SecretNumber)
            {
                Console.WriteLine("Ваше число меньше загаданного.");
            }
            return 0;
        }
    }
    else return -1;

}

void Main()
{
    int a = MakeMove(secret, countOfAttempts);
    switch (a)
    {
        case 1:
            Console.WriteLine("Вы угадали число! Игра окончена.");
            b = 1;
            break;
        case 0:
            Console.WriteLine($"Осталось {countOfAttempts-1} попыток.");
            break;
        case -1:
            Console.WriteLine("У Вас закончились попытки. Вы проиграли.");
            Console.WriteLine($"Было загадано число {secret}");
            b = 1;
            break;

    }
    countOfAttempts--;

    if (b == 0) Main();
    else { };

}

Console.WriteLine("Введите минимальное число: ");
min = RequestNumber();
Console.WriteLine("Введите максимальное число: ");
max = RequestNumber();
Console.WriteLine("Введите число попыток: ");
countOfAttempts = RequestNumber();
secret = GenNumber(min,max);
Console.WriteLine("Для начала игры нажмите любую клавишу.");
Console.ReadKey();
Console.WriteLine($"Компьютер загадал число в диапазоне от {min} до {max}. У Вас есть {countOfAttempts} попыток, чтобы угадать это число.");
Main();
Console.ReadKey();