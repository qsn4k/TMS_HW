using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_12_1
{
    class Account
    {
        private string login { get; set; }

        private string password { get; set; }

        private string confirmPassword { get; set; }


        public bool UserRegistration()
        {
            try
            {
                Console.Write("Введите ваш логин: ");
                string loginReg = Console.ReadLine();
                if (loginReg.IndexOf(' ') >= 0 || loginReg.Length >= 20)
                   throw new WrongLoginExpection("Ошибка ввода логина");
                
                login = loginReg;
            }
            catch (WrongPasswordExpection ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            try
            {
                Console.Write("Введите ваш пароль: ");
                string passReg = Console.ReadLine();
                if (passReg.IndexOf(' ') >= 0 || passReg.Length >= 20)
                    throw new WrongPasswordExpection("Ошибка ввода пароля");
                else
                {
                    bool isCheckDigital = false;
                    foreach (var item in passReg)
                    {
                        if (Char.IsDigit(item))
                        {
                            isCheckDigital = true;
                            break;
                        }
                    }
                    if (!isCheckDigital) throw new WrongPasswordExpection("Ошибка ввода пароля");
                }

                password = passReg;
            }
            catch (WrongPasswordExpection ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            try
            {
                Console.Write("Введите ваш пароль повторно: ");
                string confPassReg = Console.ReadLine();
                if (confPassReg.IndexOf(' ') >= 0 || confPassReg.Length >= 20 || confPassReg != password)
                    throw new WrongPasswordExpection("Ошибка ввода пароля");
                else
                {
                    bool isCheckDigital = false;
                    foreach (var item in confPassReg)
                    {
                        if (Char.IsDigit(item))
                        {
                            isCheckDigital = true;
                            break;
                        }
                    }
                    if (!isCheckDigital) throw new WrongPasswordExpection("Ошибка ввода пароля");
                }

                confirmPassword = confPassReg;
            }
            catch (WrongPasswordExpection ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            Console.WriteLine("Пользователь успешно зарегистрирован)");
            return true;
        }

    }
}
