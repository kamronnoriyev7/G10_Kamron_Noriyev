namespace FileManagmentService.ExtraFolder;

public class WorkingWithDelegate
{
    public static void Main(string[] args)
    {
        Delegate myDelegate = MyMethod(3,5,6);
        myDelegate(MyMethod2("uzb", 5, 6));
        myDelegate(MyMethod3("salom", 5, 6));
        myDelegate.
        
    }

    public static Delegate MyMethod(int a, int b, int c)
    {
        Console.WriteLine(a+b+c);
    }

    public static void MyMethod2(string a, int b, int c)
    {
        Console.WriteLine($"{a}" +b+c);
    }

    public static void MyMethod3(string a, int b, int c)
    {
        Console.WriteLine($"{a}" +b/c);
    }
}