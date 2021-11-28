string GameInit()
{
    string rules = "Добро пожаловать в игру Угадайка!";
    rules = rules + "Хочешь узнать правила игры?";
    rules = rules + "Я загадываю число, а ты его угадиваешь :)";
    return rules;
}

(int, int) MimMax()
{
    string questions = "Но давай сначала определимся с диапазоном чисел";
    questions = questions + "Какое число будет минимальным? ";
    Console.WriteLine(questions);
    int minNum = requestNumber();
    Console.Write("А какое максимальным? ");
    int maxNum = requestNumber();
    return (minNum, maxNum);
}

int requestNumber()
{
    Console.WriteLine("Введи число:");
    return Convert.ToInt32(Console.ReadLine());
}

int CountOfAttempts()
{
    Console.WriteLine("Давай ещё определимся с количеством попыток");
    Console.WriteLine("Сколько попыток у тебя будет? ");
    return requestNumber();
}

int CreateNumber(int minNum, int maxNum)
{
    return new Random().Next(minNum, maxNum + 1);
}
bool IsItTrue(int secretNum, int playerNum)
{
    return secretNum == playerNum;
}

string MoreLess(int secretNum, int playerNum)
{
    string answer = String.Empty;
    if (secretNum > playerNum)
    {
        answer = "Неверно! Загаданное число больше твоего :)";
    }
    else
    {
        answer = "Неверно! Загаданное число меньше твоего :)";
    }
    return answer;
}

int lifes(int secretNum, int count)
{
    while (count > 0)
    {
        int playerNum = requestNumber();
        bool arg = IsItTrue(secretNum, playerNum);
        if (arg == false)
        {
            if (secretNum > playerNum)
            {
                Console.WriteLine(MoreLess(secretNum, playerNum));
            }
            else
            {
                Console.WriteLine(MoreLess(secretNum, playerNum));
            }
            count--;
            Console.WriteLine($"У вас осталось {count} попыток");
        }
        else
        {
            Console.WriteLine("Ура! Победа!");
            break;
        }
    }
    return count;
}

Console.WriteLine(GameInit());
(int minNum, int maxNum) diap = MimMax();
int count = CountOfAttempts();
Console.WriteLine($"Итак! Я загадываю число от {diap.minNum} до {diap.maxNum},"
                + $" а у тебя есть {count} попыток это число отгадать");

int findNum = CreateNumber(diap.minNum, diap.maxNum);
lifes(findNum, count);

