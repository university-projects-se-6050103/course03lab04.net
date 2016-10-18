using System;

namespace lab04
{
    public class CLIUtils
    {

        public static int GetEncryptionChoice()
        {
            Console.WriteLine("Hello. Let's enctrypt your file. Choose preferable encr. below");
            PrintEnctryptionOptions();
            return ReadIntInRange(1, 4);
        }

        // TODO Add more encryption options
        private static void PrintEnctryptionOptions()
        {
            Console.WriteLine("1. Зашифрувати за допомогою байтових потоків");
            Console.WriteLine("2. Зашифрувати за допомогою Ссимвольних потоків");
            Console.WriteLine("3. Розшифрувати за допомогою символьних потоків");
            Console.WriteLine("4. Розшифрувати за допомогою байтових потоків");
        }

        private static int ReadIntInRange(int from, int to)
        {
            var input = Console.ReadKey().KeyChar.ToString();
            int inputInt;
            var parseResult = int.TryParse(input, out inputInt);

            if (parseResult)
            {
                if (inputInt >= from && inputInt <= to)
                {
                    return inputInt;
                }
                else
                {
                    Console.WriteLine($"Enterned number is out of range ({from}-{to}). Try again");
                    return ReadIntInRange(from, to);
                }
            }
            else
            {
                Console.WriteLine("Invalid char probided. Try again");
                return ReadIntInRange(from, to);
            }
        }

        public static void PreservePromptClose()
        {
            Console.ReadKey();
        }
    }
}