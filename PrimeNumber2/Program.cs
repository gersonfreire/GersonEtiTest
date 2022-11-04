namespace PrimeNumber
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Digite um número inteiro para saber se ele é primo (ou enter para finalizar): ");
            string? inputNumber = Console.ReadLine();

            if (string.IsNullOrEmpty(inputNumber))
            {  
                Console.WriteLine($"Finalizado pelo usuário sem informar o número!");
                return;
            }

            if (!int.TryParse(inputNumber, out int numberToCheck) || (numberToCheck <= 0))
            {
                Console.WriteLine($"Desculpe, {inputNumber} não é um número inteiro válido!");
                return;
            }

            int iteractions = 0;
            int divideSuccess = 0;

            for (int i = 1; i <= numberToCheck; i++)
            {
                iteractions++;

                if (numberToCheck % i == 0) 
                {
                    divideSuccess++;
                    if (divideSuccess > 2) 
                    {
                        Console.WriteLine($"O número {numberToCheck} NÃO é primo e a quantidade de interações foi {iteractions}");

                        return;
                    }
                }
            }

            Console.WriteLine($"O número {numberToCheck} é primo e a quantidade de interações foi {iteractions}");

        }
    }
}