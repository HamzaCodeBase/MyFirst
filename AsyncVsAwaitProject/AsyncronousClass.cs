namespace AsyncVsAwaitProject
{
    internal class AsyncronousClass
    {
        internal static async Task<string> WashClothesAsync()
        {
            Console.WriteLine("Washing Clothes Started");
            await Task.Delay(3000);
            Console.WriteLine("Washing Clothes Done");
            return "Washing Clothes Done";
        }
        internal static async Task DryClothesAsync(string str)
        {
            Console.WriteLine("Drying Clothes Started");
            await Task.Delay(2000);
            Console.WriteLine("Drying Clothes Done");
        }
        internal static async Task CleanHomeAsync()
        {
            Console.WriteLine("Cleaning Home Started");           
            await Task.Delay(5000);
            Console.WriteLine("Cleaning Home Done");
        }
        internal static async Task CookFoodAsync()
        {
            Console.WriteLine("Cooking Food Started");
            await Task.Delay(3000);
            Console.WriteLine("Cooking Food Done");
        }



        internal static async Task GetDataAsync()
        {
            var client = new HttpClient();
            var data = await client.GetAsync("https://api.restful-api.dev/objects");
            Console.WriteLine("Come Here");
        }
    }
}
