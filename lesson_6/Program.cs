namespace lesson_6
{
    internal class Program
    {
        static int Main()
        {
            Console.WriteLine("Заполните первоначальные данные для счетов: ");
            CreditCard[] creditCards = new CreditCard[3];
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Счёт {i+1}:");
                creditCards[i] = new CreditCard();
            }
            
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1.Положить деньги на счёт");
                Console.WriteLine("2.Снять деньги со счёта");
                Console.WriteLine("3.Получить информацию о карте");
                Console.WriteLine("4.Получить информацию о всех картах");
                Console.WriteLine("0.Выход");
                int choice = 0;
                while (true)
                {
                    bool isValid = int.TryParse(Console.ReadLine(), out choice);
                    if(isValid)
                    {
                        if (choice >= 0 && choice <= 4)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("Вы ввели не правильный номер действия. ПОпробуйте снова: ");
                        }
                    }
                    else
                    {
                        Console.Write("Вы ввели не число. Попробуйте снова: ");
                    }
                }

                int result = 0;

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите порядковый номер счёта: ");
                        while (true)
                        {
                            bool isValid = int.TryParse(Console.ReadLine(), out result);
                            if (isValid) if (result > 0 && result < 4) break;
                            Console.Write("Не правильное значение. Повторите попытку: ");
                        }
                        result--;
                        creditCards[result].PutMoney();
                        break;
                    case 2:
                        Console.Write("Введите порядковый номер счёта: ");
                        while (true)
                        {
                            bool isValid = int.TryParse(Console.ReadLine(), out result);
                            if (isValid) if (result > 0 && result < 4) break;
                            Console.Write("Не правильное значение. Повторите попытку: ");
                        }
                        result--;
                        creditCards[result].TakeMoney();
                        break;
                    case 3:
                        Console.Write("Введите порядковый номер счёта: ");
                        while (true)
                        {
                            bool isValid = int.TryParse(Console.ReadLine(), out result);
                            if (isValid) if (result > 0 && result < 4) break;
                            Console.Write("Не правильное значение. Повторите попытку: ");
                        }
                        result--;
                        creditCards[result].Information();
                        break;
                    case 4:
                        for(int i = 0; i < 3; i++)
                        {
                            Console.WriteLine($"\nСчёт {i+1}:");
                            creditCards[i].Information();
                        }
                        break;
                    case 0:
                        return 0;
                    default:
                        break;
                }
            }
        }



    }
}
