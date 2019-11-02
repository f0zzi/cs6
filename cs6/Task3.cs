using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs6
{
    class Fibo
    {
        public int quantity { get; set; }
        public Fibo(int quantity_) { quantity = quantity_; }
        public IEnumerator<ulong> GetEnumerator()
        {
            ulong prev, current = 0, next = 1;
            for (int i = 0; i < quantity; i++)
            {
                yield return current;
                prev = current;
                current = next;
                try
                { next = checked(current + prev); }
                catch (OverflowException)
                {
                    Console.WriteLine($"Sorry, we have reached ulong max value :(");
                    break;
                }
            }
        }
    }
}
