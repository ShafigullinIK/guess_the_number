int requestNumber()  
{
    Console.WriteLine("Введите число:");
    string str = Console.ReadLine(); 
    int num = 0;  
    try
    {
        num = Convert.ToInt32(str);
    }
    catch
    {
        Console.WriteLine("Ошибка при вводе числа. Будьте внимательны.");
    }
    return num;
}

int CreateNumber()
{
    return new Random().Next(1, 100);
}

// int answer = requestNumber();
int secretNum = CreateNumber();
Console.WriteLine(secretNum);

bool IsItTrue(int secretNum)
{
    bool res = false;
    for(int count = 2; count >= 0; count--)
    {
        int answer = requestNumber();
        if(secretNum == answer)
        {
            Console.Write("Вы угадали! ");
            res = true;
            break;
        }
        else
        {
            if(count == 0) break;
            if(secretNum > answer) Console.WriteLine($"Загаданное число больше. Осталось {count} попытка(-и).");
            else Console.WriteLine($"Загаданное число меньше. Осталось {count} попытка(-и).");
        }
    }
    return res;
}

bool result = IsItTrue(secretNum);
if(result == true) Console.WriteLine("Поздравляем!");
else 
Console.WriteLine("Повезет в следующий раз!");
