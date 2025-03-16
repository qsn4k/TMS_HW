//Создать консольное приложение "Шифр Цезаря".
//Реализовать функционал:
//1. Программа предлагает пользователю выбрать: зашифровать или расшифровать сообщение
//2. Запрашивает у пользователя ключ шифрования (число, на сколько символов сдвигать буквы)
//3. Запрашивает само сообщение (может содержать буквы, пробелы и знаки препинания)
//4. Шифрует/дешифрует сообщение:
//    - Каждая буква заменяется на другую, сдвинутую по алфавиту (например, А → Г при сдвиге на 3)
//    - Если символ не буква (пробел, точка, запятая) — не заменяется
//    - Сохраняется регистр (большие буквы остаются большими, маленькие — маленькими)
//5. Выводит результат
string shifr(string str, int key)
{
    string alfabetENG = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string alfabetEng = alfabetENG.ToLower();
    string fullAlfabetENG = alfabetENG + alfabetEng;

    string alfabetRUS = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    string alfabetRus = alfabetRUS.ToLower();
    string fullAlfabetRUS = alfabetRUS + alfabetRus;

    string fullAlfabet = fullAlfabetENG + fullAlfabetRUS;

    string resStr = "";
    for (int i = 0; i < str.Length; i++)
    {
        char c = str[i];
        int indexR = fullAlfabetRUS.IndexOf(c);
        int indexE = fullAlfabetENG.IndexOf(c);
        if (indexR == -1 && indexE == -1) resStr += c.ToString();
        else if (indexE != -1)
        {
            int indexEng = alfabetEng.IndexOf(c);
            int indexENG = alfabetENG.IndexOf(c);
            if (indexENG != -1) c = alfabetENG[(indexENG + key) % 26];
            else c = alfabetEng[(indexEng + key) % 26];
        }
        else if (indexR != -1)
        {
            int indexRus = alfabetRus.IndexOf(c);
            int indexRUS = alfabetRUS.IndexOf(c);
            if (indexRUS != -1) c = alfabetRUS[(indexRUS + key) % 33];
            else c = alfabetRus[(indexRus + key) % 33];
        }
        else Console.WriteLine("Неизвестная ошибка");
        resStr += c.ToString();
    }
    return resStr;
}


Console.WriteLine("Шифр Цезаря");

while (true)
{
    Console.WriteLine("Меню:");
    Console.WriteLine("1. Зашифровать сообщение");
    Console.WriteLine("2. Дешифровать сообщение");
    Console.WriteLine("0. Выход");
    int choice = 0;
    while (true)
    {
        Console.Write("Введите: ");
        bool isValid = int.TryParse(Console.ReadLine(), out choice);
        if (isValid && choice >= 0 && choice <= 2) break;
    }
    switch (choice)
    {
        case 1:
            Console.Write("Введите ключ шифрования:");
            int key = 0;
            while (true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out key);
                if (isValid) break;
                Console.Write("Вы ввели не правильно, введите ещё раз: ");
            }
            Console.Write("Введите сообщение: ");
            string str = Console.ReadLine();
            string resStr = shifr(str, key);
            Console.WriteLine($"Шифрованное сообщение: {resStr}");

            break;
        case 2:
            Console.Write("Введите ключ шифрования:");
            key = 0;
            while (true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out key);
                if (isValid) break;
                Console.Write("Вы ввели не правильно, введите ещё раз: ");
            }
            Console.Write("Введите сообщение: ");
            str = Console.ReadLine();
            key = key - 2 * key;
            resStr = shifr(str, key);
            Console.WriteLine($"Дешифрованное сообщение: {resStr}");
            break;
        case 0:
            Console.WriteLine("Завершение работы...");
            return 0;
    }

}
