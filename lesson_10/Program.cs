//1.Написать программу, которая использует делегаты для фильтрации списка чисел:
//    -Создать список чисел и вывести на экран
//    - Предложить пользователю выбрать способ фильтрации (оставить только чётные числа, только нечётные, числа больше 10 и т. п.)
//    - Реализовать метод Filter, который принимает список чисел и делегат-фильтр и возвращает отфильтрованный список
//    - Отфильтровать список и вывести на экран результат


using System.Dynamic;

namespace lesson_10
{
    internal class Program
    {
        //Predicate<int, int> finc = (int a, int b) a > b => false;



        static void Main(string[] args)
        {
            List<int> listInt = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.Write("Список чисел:");
            foreach (var item in listInt)
            {
                Console.Write(string.Join(" ", $", {item}"));
            }
            Console.WriteLine("Способ фильтрации: " +
                "\n1. Оставить четные числа" +
                "\n2. Оставить нечетные числа" +
                "\n3. Оставить только те, которые делятся на 3");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    listInt = Filter((int a) => a % 2 == 0 ? true : false, listInt);
                    break;
                case 2:
                    listInt = Filter((int a) => a % 2 == 1 ? true : false, listInt);
                    break;
                case 3:
                    listInt = Filter((int a) => a % 3 == 0 ? true : false, listInt);
                    break;
                default:
                    break;
            }

            Console.Write("Список чисел:");
            foreach (var item in listInt)
            {
                Console.Write(string.Join(" ", $", {item}"));
            }
        }

        static List<int> Filter(Predicate<int> predicate, List<int> list)
        {
            List<int> resultList = new();
            foreach (var a in list)
            {
                if (predicate(a)) resultList.Add(a);
            }
            return resultList;
        }

    }
}
