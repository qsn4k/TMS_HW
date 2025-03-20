using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6
{
    class CreditCard
    {
        private string number;
        private int sum;

        CreditCard()
        {
            Console.Write("Введите номер счёта:");
            number = Console.ReadLine();
            Console.Write("Введите начальную сумма:");
            while(true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out int sum);
                if (!isValid) break;
                Console.Write("Введите ещё раз:");
            }
        }

        CreditCard(string number, int sum)
        {
            this.number = number;
            this.sum = sum;
        }
        int editSum(int sum)
        {
            return this.sum += sum;
        }

    }
}
