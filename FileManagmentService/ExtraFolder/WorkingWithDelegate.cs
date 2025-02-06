namespace FileManagmentService.ExtraFolder;

public class WorkingWithDelegate
{
    public delegate void MyDelegate(int a, int b, int c);
    public static void Main(string[] args)
    {
        var myDelegate = new MyDelegate(MyMethod);
        myDelegate += MyMethod2;
        myDelegate += MyMethod3;
        myDelegate(9, 10, 2);
        
    }

    public static void MyMethod(int a, int b, int c)
    {
        Console.WriteLine(a+b+c);
    }

    public static void MyMethod2(int a, int b, int c)
    {
        Console.WriteLine($"{a}" +b+c);
    }

    public static void MyMethod3(int a, int b, int c)
    {
        Console.WriteLine($"{a}" +b/c);
    }
}

public class MyDelegate
{
    
}