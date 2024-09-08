using System;

public class Utils
{
    private static Random s_random = new Random();

    public static int GetRandomInt(int min, int max)
    {
        return s_random.Next(min, max + 1);
    }
}
