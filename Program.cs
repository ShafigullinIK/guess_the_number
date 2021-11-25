int GameInit() //метод получает исходные данные и хранит секретное число
{
    int[] inputData = new int[2];
    Console.WriteLine("Привет! Введи интервал чисел и количество попыток, я загадаю число из этого интервала, а тебе нужно будет его угадать");
    Console.WriteLine("Введи начало интервала: ");
    int min = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введи конец интервала: ");
    int max = Convert.ToInt32(Console.ReadLine());
    int res = new Random().Next(min, max);  //запоминает секретное число
    return res;
}
int AscMethod() //метод хранит число игрока
{
    Console.WriteLine("Bведи свое предположение: ");
    int PlayesrNumber = Convert.ToInt32(Console.ReadLine());
    return PlayesrNumber;
}
int MakeMove(int count) // метод делает ход и проверяет, хранит ответ/ исходные данные - количество попыток
{
    int SecretNumber = GameInit();
    while (count >= 0)
    {
        int PlayesrNumber = AscMethod();
        if (PlayesrNumber > SecretNumber)
        {
            Console.WriteLine("Загаданное число меньше введенного");
            count--;
        }
        else
        {
            if (PlayesrNumber < SecretNumber)
            {

                Console.WriteLine("Загаданное число больше введенного");
                count--;
            }
            else
            {
                Console.WriteLine("Победа!");
                return SecretNumber;
            }
        }
    }
    Console.WriteLine("В этот раз не получилось");
    return SecretNumber;
}

Console.WriteLine(MakeMove(3));