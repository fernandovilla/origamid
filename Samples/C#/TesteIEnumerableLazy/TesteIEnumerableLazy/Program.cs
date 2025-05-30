
//https://stackoverflow.blog/2022/06/15/c-ienumerable-yield-return-and-lazy-evaluation/

namespace TesteIEnumerableLazy
{
    public static class Program
    {
        static bool didTheCodeRun = false;
        static int lastYielded = -1;

        public static void Main()
        {
            //var results = RunTheCode();
            //Console.WriteLine(didTheCodeRun);

            var numbers = GetOneToTen();
            Console.WriteLine($"Last Yielded: {lastYielded}");
             
            var enumerator = numbers.GetEnumerator();

            enumerator.MoveNext();
            Console.WriteLine($"Number: {enumerator.Current}");

            foreach (var number in numbers) {
                if (number >= 4)
                    break;
            }

            Console.WriteLine($"Last Yielded: {lastYielded}");

            var numbersTimesTwo = numbers.Select(i => i * 2);
            Console.WriteLine($"Last Yielded: {lastYielded}");

            var arr = numbers.ToArray(); //Executa todo o método, é a mesma coisa que ToList();
            Console.WriteLine($"Last Yielded: {lastYielded}");

            Console.ReadKey();
        }

        public static IEnumerable<bool> RunTheCode()
        {
            didTheCodeRun = true;
            yield return true;
        }

        public static IEnumerable<int> GetOneToTen()
        {
            for (int i = 1; i <= 10; i++)
            {
                lastYielded = i;
                yield return i;
            }
        }
    }
}