namespace AsyncVsAwaitProject
{
    internal class SyncronousClass
    {
        internal static string WashClothes()
        {
            Console.WriteLine("Washing Clothes Started");
            Thread.Sleep(3000);
            Console.WriteLine("Washing Clothes Done");
            return "Washing Clothes Done";
        }
        internal static void DryClothes(string str)
        {
            Console.WriteLine("Drying Clothes Started");
            Thread.Sleep(2000);
            Console.WriteLine("Drying Clothes Done");
        }
        internal static void CleanHome()
        {
            Console.WriteLine("Cleaning Home Started");
            Thread.Sleep(5000);
            Console.WriteLine("Cleaning Home Done");
        }
        internal static void CookFood()
        {
            Console.WriteLine("Cooking Food Started");
            Thread.Sleep(3000);
            Console.WriteLine("Cooking Food Done");
        }
    }
}
