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
for (int rows = 0; rows < size; rows++)
{
    for (int col = 0; col < size; col++)
    {
        Console.WriteLine(matrix[rows, col]);
    }
    Console.WriteLine("");
}
