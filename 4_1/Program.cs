Console.WriteLine("Введите количество студентов: ");
int length = int.Parse(Console.ReadLine());
int[] arrayStudent = new int[length];
for (int i = 0; i < length; i++)
{
    Console.WriteLine($"Введите оценку студента номер {i + 1}:");
    arrayStudent[i] = int.Parse(Console.ReadLine());
}
while (true)
{
    Console.WriteLine("Меню");
    Console.WriteLine("1.Средняя оценка группы");
    Console.WriteLine("2.Самая высокая и низка оценка группы");
    Console.WriteLine("3.Количество студентов");
    Console.WriteLine("0.Выход");
    Console.WriteLine("Введите: ");
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            int temp = 0;
            for (int i = 0; i < length; i++)
            {
                temp += arrayStudent[i];
            }
            double result = temp / (double)length;
            Console.WriteLine($"Средняя оценка группы = {result}");
            break;
        case 2:
            int min = arrayStudent[0];
            int max = arrayStudent[0];
            for (int i = 0; i < length; i++)
            {
                if (arrayStudent[i] < min)
                {
                    min = arrayStudent[i];
                }
                if (arrayStudent[i] > max)
                {
                    max = arrayStudent[i];
                }
            }
            Console.WriteLine($"Самая высокая оценка: {max}");
            Console.WriteLine($"Самая низкая оценка: {min}");
            break;
        case 3:
            temp = 0;
            for (int i = 0; i < length; i++)
            {
                temp += arrayStudent[i];
            }
            result = temp / (double)length;
            int resPol = 0;
            foreach (int item in arrayStudent)
            {
                if ((double)item >= result) resPol++;     
            }
            Console.WriteLine($"Количество студентов = {length}");
            Console.WriteLine($"Количество студентов с оценкой выше средней= {resPol}");
            break;
        case 0:
            return 0;
        default:
            Console.WriteLine("Введено неправильное значение");
            break;
    }
}