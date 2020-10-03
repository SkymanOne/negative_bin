using System;
using System.Linq;


namespace negative_bin
{
    class Program
    {
        static int r;
        static double p;
        static void Main(string[] args)
        {
            bool run;

            Reset();

            do
            {
                run = true;

                Console.WriteLine("Enter X");
                int X = int.Parse(Console.ReadLine());
                double result = Calculate(X);

                Console.WriteLine(result);

                Console.WriteLine("Enter <q> to exit or <r> to reset values\nOtherwise press Enter");
                var s = Console.ReadLine();
                if (s == "q") run = false;
                if (s == "r") Reset();

            } while (run);
        }

        public static void Reset()
        {
            Console.WriteLine("Enter r: ");
            r = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter p: ");
            var input = Console.ReadLine();
            if (input.Contains("/")) {
                int[] numbers = input.Split('/').Select(x => int.Parse(x)).ToArray();
                p = (double) numbers[0] / numbers[1];
            } else {
                p = double.Parse(input);
            }
        }

        public static double Calculate(int X)
        {
            return Math.Round((double)combination(X - 1, r - 1)
                * Math.Pow(p, r)
                * Math.Pow(1 - p, X - r), 12);
        }

        public static long combination(int n, int k)
        {
            return factorial(n)/(factorial(k)*factorial(n-k));
        }

        public static long factorial(int n) {
            if (n == 1) return 1;

            return n * factorial(n-1);
        }
    }
}
