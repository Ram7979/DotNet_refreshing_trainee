using System;
public class Program
{
    public int[] MultipliTable(int n, int upto)
    {
        int[] arr = new int[upto];
        for (int i = 1; i <= upto; i++)
        {
            arr[i - 1] = n * i;
        }
        return arr;

    }
    public static void Main(string[] args)
    {
        Program p = new Program();
        int n = int.Parse(Console.ReadLine());
        int upto = int.Parse(Console.ReadLine());

        int[] res = p.MultipliTable(n, upto);
        Console.WriteLine(string.Join(",", res));

    }
}