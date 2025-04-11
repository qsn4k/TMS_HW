using System.Reflection.Metadata;

namespace lesson_12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в программу 'Регистрация пользователей)'");
            while (true)
            {
                try
                {
                    Console.WriteLine("Регистарция пользователя:");
                    Account user = new Account();
                    user.UserRegistration();
                }
                catch (WrongPasswordExpection ex)
                {
                    Console.WriteLine($"Консоль: {ex.Message}");
                }
                catch (WrongLoginExpection ex)
                {
                    Console.WriteLine($"Консоль: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Консоль: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
