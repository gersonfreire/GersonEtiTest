namespace GpsBestRoute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("EntradaGPS .txt");

                if(int.TryParse(lines[0], out int testCases))
                {
                    Console.WriteLine(testCases);

                }
                else
                {
                    Console.WriteLine("Quantidade de casos de testes inálido");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}  