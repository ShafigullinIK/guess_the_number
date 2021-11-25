## Консольная игра "Угадай число"

Комп загадывает число (в некотором отрезке), 
у игрока есть несколько попыток, чтобы угадать это число
Игрок вводит различные числа, комп считает количество попыток,
а также "говорит" введенное число больше или меньше загаданного.


1. Нам необходимо задать исходные (обозначить условия). Отрезок (минимальное и максимальное значение), количество попыток. Один способ - задать как константы, второй способ - запросить у игрока. 
2. Инициализировать игру. Загадываем число и приветсвуем игрока, объясняем условия игры.
3. Делаем ход. Запрашиваем и получаем от игрока число. Сравниваем это число с загаданным, изменяем количество попыток и выводим результат.
4. Завершение игры (Если человек угадал, либо потратил все попытки). Либо предложить сыграть еще раз.

* GameInit() - метод, который задает все исходные значения в вашей игре.
* MakeMove() - ходы, задаются этим методом.
* RequestNumber() - запрос числа у игрока, обработка нештатных ситуаций.
* CheckNumber(int PlayesrNumber, int SecretNumber)
* GameOver(bool winner) - 
Вариант решения:
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