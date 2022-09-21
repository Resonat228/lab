namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var listdata = new List<int>(input.Select(int.Parse));
            
            var inputMoments = Console.ReadLine().Split();
            var queueOfMoments = new List<int>(inputMoments.Select(int.Parse));

            var maximumAmount = 0;

            for (int i = 0; i < listdata[0] - listdata[1]; i++)
            {
                var temporaryAmount = queueOfMoments[i] + queueOfMoments.Skip(i + listdata[1]).Max();
                
                if (maximumAmount < temporaryAmount)
                {
                    maximumAmount = temporaryAmount;
                }
            }
            
            Console.WriteLine(maximumAmount);
        }
    }

}

