// Игра в Угадайку
Console.WriteLine("Введите размер диапазона отгадываемых положительных чисел");
int range = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Правила игры в Угадай число:");
int numAttampts(int a)
{
int count = 0;
    while (a > 0)
    {
        a = a / 2;
        count++;
    }
return count;
}
int userAttampts = numAttampts(range);

Console.WriteLine($"Компутер загадал рандомное число. У вас есть {userAttampts} попыток, что бы его отгадать");
int[] newArray(int[] coll)
{
    for (int i = 0; i < coll.Length; i++)
    {
        coll[i] = i;
    }
return coll;
}
int[] col = new int[range];
int[] Array = newArray(col);
int lowBound = Array.First();
int uppBound = Array.Last();

int compNum()
{
    return new Random().Next(lowBound, uppBound);
}
int compNumber = compNum();
Console.WriteLine(compNumber);

int userNumber()
{
int userNum = 0;
Console.WriteLine($"Введите число от {lowBound} до {uppBound}");
int result = 0;
string usNumber = Console.ReadLine();
while (int.TryParse(usNumber, out result) == false)
{
    Console.WriteLine($"Неверный ввод. Введите число от {lowBound} до {uppBound}");
    usNumber = Console.ReadLine();
}
userNum = Convert.ToInt32(usNumber);
while (userNum < lowBound || userNum > uppBound)
{
Console.WriteLine($"Ваше число не входит в диапазон. Введите число от {lowBound} до {uppBound}");
userNum = Convert.ToInt32(Console.ReadLine());
}
return userNum;
}

bool checkNumber(int compNumber, int userAttampts)
{
bool result = false;
int countAttampts = userAttampts;
    while (countAttampts > 0)
    {
        int userNum = userNumber();
        if (userNum < compNumber)
        {
            Console.WriteLine($"Загаданное число больше введённого! Осталось попыток {countAttampts - 1}");
            result = false;
        }
        else if (userNum > compNumber)
        {
            Console.WriteLine($"Загаданное число меньше введённого! Осталось попыток {countAttampts - 1}");
            result = false;
        }
        else if (userNum == compNumber)
        {
            Console.WriteLine("Число угадано верно!");
            result = true;
            break;
        }
    countAttampts--;
    }
if (result == true) Console.WriteLine("Вы победили!");
else Console.WriteLine("Ваши попытки закончились! Вы проиграли((");
return result;
}
checkNumber(compNumber, userAttampts);

