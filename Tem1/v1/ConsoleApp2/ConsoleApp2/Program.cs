namespace ConsoleApplication1
{
    public static class CustomExtensions
    {
        private static readonly Dictionary<string, Actions> ActionsMap = new()
        {
            { "+", Actions.SimpleAdd },
            { "*", Actions.PreferredAdd },
            { "-", Actions.Remove },
        };

        public static (Actions, string) SplitOnTwo(this string str, char separator)
        {
            var firstValue = string.Empty;
            var scndValue = string.Empty;

            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == separator)
                {
                    if (i != str.Length - 1)
                    {
                        for (var j = i + 1; j < str.Length; j++)
                        {
                            scndValue += str[j];
                        }
                    }
                    return (firstValue.ConvertToEnum(), scndValue);
                }

                firstValue += str[i];
            }

            return (firstValue.ConvertToEnum(), scndValue);
        }


        private static Actions ConvertToEnum(this string action)
        {
            if (ActionsMap.ContainsKey(action))
            {
                return ActionsMap[action];
            }

            return Actions.Default;
        }
    }

    internal class GoblinQueue
    {
        private readonly List<string> _currentQueue;

        public GoblinQueue()
        {
            _currentQueue = new List<string>();
        }

        public void Add(string name, Actions actions)
        {
            int index;
            switch (actions)
            {
                case Actions.PreferredAdd:
                    index = _currentQueue.Count / 2;
                    break;
                case Actions.SimpleAdd:
                    index = _currentQueue.Count;
                    break;
                default:
                    throw new ArgumentException();
            }

            _currentQueue.Insert(index, name);

        }

        public string Remove()
        {
            if (_currentQueue.Count > 0)
            {
                var removeElement = _currentQueue.First();
                _currentQueue.Remove(removeElement);
                return removeElement;
            }

            return string.Empty;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var stringCountAction = Console.ReadLine();

            if (!int.TryParse(stringCountAction, out var countActions))
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var goblinQueue = new GoblinQueue();
            var removedGoblins = new List<string>();

            for (var i = 0; i < countActions; i++)
            {
                var goblin = Console.ReadLine();

                if (string.IsNullOrEmpty(goblin))
                {
                    Console.WriteLine("Invalid action check input");
                    return;
                }

                var (action, goblinName) = goblin.SplitOnTwo(' ');

                if (action == Actions.Default)
                {
                    Console.WriteLine("Invalid action check input");
                    return;
                }

                if (action == Actions.Remove)
                {
                    removedGoblins.Add(goblinQueue.Remove());
                    continue;
                }

                if (goblin != string.Empty)
                {
                    goblinQueue.Add(goblinName, action);
                }
            }

            PrintRemovedGoblins(removedGoblins);

        }

        private static void PrintRemovedGoblins(List<string> removedGoblins)
        {
            foreach (var goblin in removedGoblins)
            {
                Console.Write(goblin + "\n");
            }
        }
    }

    public enum Actions
    {
        SimpleAdd = 0,
        PreferredAdd = 1,
        Remove = 2,

        Default = -1,
    }
}