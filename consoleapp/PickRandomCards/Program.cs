using System;
using System.Linq;

namespace PickRandomCards
{
    class Program
    {
        static void Main(string[] args)
        {
            PickRandomCards();
        }

        private static void PickRandomCards()
        {
            Console.Write("Enter the number of cards to pick: ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int numberOfCards))
            {
                foreach (string card in CardPicker.PickSomeCards(numberOfCards))
                {
                    Console.WriteLine(card);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            //check if pick dublicated cards
            var groups = CardPicker.PickSomeCards(numberOfCards).GroupBy(v => v);
            foreach (var group in groups)
                Console.WriteLine("Value {0} has {1} items", group.Key, group.Count());
        }
    }
}
