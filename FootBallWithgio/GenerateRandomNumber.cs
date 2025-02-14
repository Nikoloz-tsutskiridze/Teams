
public static class GenerateRandomNumber
{
    public static Random Random = new Random();
  
    public static int Generate(int start, int end)
    {
        var randomNumber = Random.Next(start, end);
        return randomNumber;
    }
    
}