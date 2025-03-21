using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6
{
    class CreditCard
    {
        private string number = "";
        private int sum = 0;

        public CreditCard()
        {
            Console.Write("Введите номер счёта:");
            number = Console.ReadLine();
            Console.Write("Введите начальную сумма:");
            while (true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out sum);
                if (isValid) break;
                Console.Write("Введите ещё раз:");
            }
        }

        public CreditCard(string number, int sum)
        {
            this.number = number;
            this.sum = sum;
        }

        public void PutMoney(int s)
        {
            if (s >= 0) sum += s;
        }

        public void PutMoney()
        {
            Console.Write("Какую сумму вы хотите положить: ");
            while (true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out int money);
                if (isValid)
                {
                    if (money >= 0) sum += money;
                    break;
                }
                Console.Write("Вы ввели неправильное число. Введите ещё раз:");
            }
        }

        public void TakeMoney(int s)
        {
            if (sum - s >= 0) sum -= s;
            else Console.WriteLine("Недостаточно средств");
        }

        public void TakeMoney()
        {
            Console.Write("Введите сумму, которую желаете снять: ");
            while (true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out int money);
                if (isValid)
                {
                    if (sum - money >= 0) sum -= money;
                    break;
                }
                Console.Write("Вы ввели неправильное число. Введите ещё раз:");
            }
        }

        public void Information()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Информация о карточке:");
            Console.WriteLine($"Номер счёта: {number}");
            Console.WriteLine($"Сумма на счёте: {sum}");
            Console.WriteLine("-----------------------");
        }
    }
}
