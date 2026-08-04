public class Program{
    public void swapNumbers(ref int a, ref int b){
        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine("a = "+a);
        Console.WriteLine("b = "+b);
    }
    public static void Main(String[] args){
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        Program p = new Program();
        Console.WriteLine("After wapping: ");
        p.swapNumbers(ref a, ref b);
    }
}