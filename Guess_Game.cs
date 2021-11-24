int createNumber(int minVal, int maxVal)
{
    return new Random().Next(minVal, maxVal);
}



int SecretNumber = createNumber(1, 100);