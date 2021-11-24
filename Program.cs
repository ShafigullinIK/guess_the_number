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
