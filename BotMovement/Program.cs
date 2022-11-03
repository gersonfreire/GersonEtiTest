namespace BotMovement
{
    internal class Program
    {
        static bool IsMovementPossible(int x1, int y1,
                               int x2, int y2)
        {
            int verDistance = x2 - x1;
            int horDistance = y2 - y1;

            // Se já atingiu o ponto final, então É válido ("ficar parado")!
            if ((verDistance == 0) && (horDistance == 0))
            {
                return true;
            }

            // avançar somente para cima é permitido
            else if ((verDistance >= 1) && (horDistance == 0))
            {
                return IsMovementPossible(x1 + verDistance, y1, x2, y2);
            }

            // avançar somente para direita é permitido
            else if ((verDistance == 0) && (horDistance >= 1))
            {
                return IsMovementPossible(x1, y1 + horDistance, x2, y2);
            }

            // avancar para cima E direita é permitido
            else if ((verDistance >= 1) && (horDistance >= 1))
            {
                return IsMovementPossible(x1, y1 + horDistance, x2, y2);
            }

            // qualquer outro tipo de movimento não é permitido!
            else
            {
                return false;
            }
        }

        public static void Main()
        {
            Console.Write("Digite coordenadas x1 e y1 do ponto de partida (dois inteiros positivos separados por espaço: ");
            string? inputNumber = Console.ReadLine();

            if (inputNumber?.Split(' ').Length < 2)
            {
                Console.WriteLine($"Coordendadas inválidas! Digite dois números inteiros positivos separados por espaço!");
                return;
            }

            string? inputX1 = inputNumber?.Split(' ')[0];
            string? inputY1 = inputNumber?.Split(' ')[1];
            if (!int.TryParse(inputX1, out int x1) || (x1 <= 0)
                || (!int.TryParse(inputY1, out int y1) || (y1 <= 0)))
            {
                Console.WriteLine($"Desculpe, {inputNumber} não são números inteiros válidos!");
                return;
            }

            Console.Write("Digite coordenadas x2 e y2 do ponto de chegada (dois inteiros positivos separados por espaço: ");
            inputNumber = Console.ReadLine();

            if (inputNumber?.Split(' ').Length < 2)
            {
                Console.WriteLine($"Coordendadas inválidas! Digite dois números inteiros positivos separados por espaço!");
                return;
            }

            string? inputX2 = inputNumber?.Split(' ')[0];
            string? inputY2 = inputNumber?.Split(' ')[1];
            if (!int.TryParse(inputX2, out int x2) || (x2 <= 0)
                || (!int.TryParse(inputY2, out int y2) || (y2 <= 0)))
            {
                Console.WriteLine($"Desculpe, {inputNumber} não são números inteiros válidos!");
                return;
            }

            Console.WriteLine("\nVerificando, aguarde...\n");

            if (IsMovementPossible(x1, y1, x2, y2))
                Console.Write($"Legal! O movimento é SIM possivel do ponto ({x1},{y1}) para ({x2},{y2})!\n");
            else
                Console.Write($"Poxa, sinto muito, mas o movimento do ponto ({x1},{y1}) para ({x2},{y2}) NÃO É POSSÍVEL!\n");
        }
    }
}
