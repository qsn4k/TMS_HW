Console.WriteLine("Введите размерность массива (например 4 => 4*4): ");
int size = int.Parse(Console.ReadLine());
int[,] matrix = new int[size, size];
for (int rows = 0; rows < size; rows++)
{
    for (int col = 0; col < size; col++)
    {
        matrix[rows, col] = Random.Shared.Next(-99, 100);
    }
}
Console.WriteLine("Ваш массив:");
for (int rows = 0; rows < size; rows++)
{
    for (int col = 0; col < size; col++)
    {
        Console.Write(matrix[rows, col] + "\t");
    }
    Console.WriteLine("");
}
while (true)
{
    Console.WriteLine("\nМеню:");
    Console.WriteLine("1.Количество положительных и отрицательных чисел");
    Console.WriteLine("2.Сортировка элементов в массиве по строкам");
    Console.WriteLine("3.Инверсия столбцов");
    Console.WriteLine("4.Вывод матрицы");
    Console.WriteLine("0.Выход");
    Console.WriteLine("Ввод: ");
    int choice;
    while (true)
    {
        bool isValid = int.TryParse(Console.ReadLine(), out choice);
        if (isValid) break;
        else if (choice < 0 || choice > 4) Console.WriteLine("Введите правильный номер пункта");
        else Console.WriteLine("Введите число");
    }
    switch (choice)
    {
        case 1:
            int numOfPos = 0;
            int numOfNeg = 0;
            for(int rows = 0; rows < size; rows++)
            {
                for(int col = 0; col < size; col++)
                {
                    if (matrix[rows, col] > 0) numOfPos++;
                    else if (matrix[rows, col] < 0) numOfNeg++;
                }
            }
            Console.WriteLine($"Количество положительных чисел в матрице {numOfPos}");
            Console.WriteLine($"Количество отрицательных чисел в матрице {numOfNeg}");
            break;
        case 2:
            for(int rows = 0; rows < size; rows++)
            {
                
                for(int col = 0; col < size; col++)
                {
                    int minId = col;
                    for(int colTemp = col; colTemp < size; colTemp++)
                    {
                        if (matrix[rows, minId] > matrix[rows, colTemp]) minId = colTemp;
                    }
                    int temp = matrix[rows, minId];
                    matrix[rows, minId] = matrix[rows, col];
                    matrix[rows, col] = temp;
                }
            }
            break;
        case 3:
            for(int col = 0; col < size; col++)
            {
                for (int rows = 0; rows < size / 2; rows++)
                {
                    int temp = matrix[rows, col];
                    matrix[rows, col] = matrix[size - rows - 1, col];
                    matrix[size - rows - 1, col] = temp;
                }
            }
            break;
        case 4:
            Console.WriteLine("Ваш массив:");
            for (int rows = 0; rows < size; rows++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[rows, col] + "\t");
                }
                Console.WriteLine("");
            }
            break;
        case 0:
            Console.WriteLine("Спасибо за использование!");
            return 0;
        default:
            break;
    }
}