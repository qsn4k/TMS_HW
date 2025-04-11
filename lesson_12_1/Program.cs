namespace lesson_12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Pososi");
            }
        }
    }
}
