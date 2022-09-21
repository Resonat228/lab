namespace ConsoleApp3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var listdata = new List<int>(input.Select(int.Parse));
            var sumOfElements = 0;

            List<List<string>> listContainer = new List<List<string>>();

            for (int i = 0; i < listdata[1]; i++)
            {
                listContainer.Add(new List<string>());
            }

            for (int i = 0; i < listdata[0] & listdata[2] >= sumOfElements; i++)
            {
                var cargo = Console.ReadLine();
                var bargeActions = cargo.Split();


                if (bargeActions.Length > 1)
                {
                    var compartmentNumber = int.Parse(bargeActions[1]);
                    var typeOfFuel = bargeActions[2];

                    switch (bargeActions[0])
                    {
                        case "+":
                            listContainer[compartmentNumber - 1].Add(typeOfFuel);
                            sumOfElements += 1;
                            break;
                        case "-":
                            listContainer[compartmentNumber - 1].Remove(typeOfFuel);
                            sumOfElements -= 1;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value");
                    break;
                }
            }
            
            Console.WriteLine(sumOfElements);
        }
    }
}

