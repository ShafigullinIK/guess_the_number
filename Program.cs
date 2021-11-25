int RequestNumber(string message)
{
  Console.WriteLine(message);
  string line = Console.ReadLine();
  return Convert.ToInt32(line);
}

int CreateSecretNumber(int leftBound, int rightBound)
{
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
  }
  else
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

// Моё решение
// Просьба дпть комментарии
// int resGame = initGame();
// System.Console.WriteLine(resGame);

// int initGame()
// {
//   int attempts = 7;
//   int leftBound = 1;
//   int rightBound = 100;
//   int SecretNumber = createNumber(leftBound, rightBound);
//   System.Console.WriteLine($"Угадайте число от {leftBound} до {rightBound}  за {attempts} попыток");
//   return playGame(SecretNumber, attempts);
// }

// int playGame(int numSec, int numAttempts)
// {
//   int attemptsMade = 0;
//   int res = 0;// 0 - использовали все попытки и не выиграли 1 - угадали число
//   do
//   {
//     attemptsMade++;
//     numAttempts--;
//     if (MakeMove(numSec, numAttempts))
//     {
//       System.Console.WriteLine($"Вы выиграли и угадали число: {numSec} за {attemptsMade} попыток!");
//       res = 1;
//       return res;
//     }
//     else System.Console.WriteLine($"Вы не угадали число у Вас осталось {numAttempts} попыток!");


//   } while (numAttempts > 0);
//   System.Console.WriteLine($"Вы проиграли и не угадали число: {numSec} за {attemptsMade} попыток!");
//   return res;
// }



// int requestNumber() // метод запросит число 
// {
//   string inNumstr = string.Empty;
//   do
//   {
//     System.Console.WriteLine("Введите число: ");
//     inNumstr = ExError(Console.ReadLine());
//   } while (inNumstr == "");
//   return Convert.ToInt32(inNumstr);
// }

// string ExError(string? inputstring)
// {
//   string res = string.Empty;
//   for (int i = 0; i < inputstring!.Length; i++)
//   {
//     if (inputstring[i] >= 48 && inputstring[i] < 58 || inputstring[i] == 45)
//     {
//       res = res + inputstring[i];
//     }
//   }
//   return res;
// }

// // int createNumber = createNumber(1, 100);
// int createNumber(int minValue, int maxValue)
// {
//   return new Random().Next(minValue, maxValue);
// }

// bool MakeMove(int SecretNumber, int CountOfAttempts)
// {
//   int reqNum = requestNumber();
//   if (CountOfAttempts == 0) return false;

//   if (SecretNumber == reqNum) return true;
//   else
//   {
//     if (SecretNumber > reqNum)
//     {
//       System.Console.WriteLine($"Вы ввели {reqNum} , которое меньше загаданного числа");
//       return false;
//     }
//     else
//     {
//       System.Console.WriteLine($"Вы ввели {reqNum} , которое больше загаданного числа");
//       return false;
//     }
//   }
// }