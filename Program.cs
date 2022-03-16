using System;

public class Program
{
    public delegate bool Filtering(int num);
    public static int[] GetFiltered(int[] arr, Filtering num)
    {
        return arr.Where(x => num(x)).ToArray();
    }
    //
    public static void Print(int[] array)
    {
        foreach (int num in array)
        {
            System.Console.Write($"{num}, ");
        }
    }
    //
    public static void Main()
    {
        Filtering IsEven = num => (num % 2 == 0);
        Filtering NotEven = num => !(num % 2 == 0);
        Filtering HasNum3 = num => num.ToString().Contains("3");
        Filtering HasSameNum = num =>
        {
            int item = num % 10;
            while (num != 0)
            {
                int i = num % 10;
                num = num / 10;
                if (i != item)
                {
                    return false;
                }
            }
            return true;
        };
        //
        int[] array = new int[] { 1, 2, 3, 5, 6, 11, 12, 13, 14, 22, 23, 33, 44, 55 };
        int[] evenArray = GetFiltered(array, IsEven);
        int[] notEvenArray = GetFiltered(array, NotEven);
        int[] has3Array = GetFiltered(array, HasNum3);
        int[] hasSameNumberArray = GetFiltered(array, HasSameNum);
        //
        System.Console.WriteLine("Original array items:");
        Print(array);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Even array items:");
        Print(evenArray);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Not even array items:");
        Print(notEvenArray);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Has 3 array items:");
        Print(has3Array);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Has same number array items:");
        Print(hasSameNumberArray);
        System.Console.WriteLine("\n********************");
    }
}
