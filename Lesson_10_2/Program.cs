//2. Написать программу, которая уведомляет менеджера и клиента о статусе заказа с помощью событий:
//    -Создать класс OnlineStore с методом обработки заказа (ProccessOrder(int orderId)) и событием OnOrderProcessed
//    - Событие должно срабатывать при обработке заказа
//    - Добавить обработчики события:
//        1) Уведомление клиенту(Выводит в консоль "Уведомление клиенту: Ваш заказ {id} готов!")
//        2) Уведомление менеджеру(Выводит в консоль "Уведомление менеджеру: Заказ {id} обработан.")
//    -Обработать несколько заказов, проверяя, что события вызываются автоматически

namespace Lesson_10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<OnlineStore> onlineStores = new List<OnlineStore> {new OnlineStore(), new OnlineStore() };
            onlineStores[0].OnOrderProccess += OnlineStore.MessageClient;
            onlineStores[0].OnOrderProccess += OnlineStore.MessageManager;

            onlineStores[0].ProccessOrder(10);
            onlineStores[0].ProccessOrder(20);
            onlineStores[1].ProccessOrder(11);
            onlineStores[1].ProccessOrder(21);
            onlineStores[0].ProccessOrder(5430);
        }
    }

    class OnlineStore
    {

        public event Action<int> OnOrderProccess;

        public void ProccessOrder (int orderId)
        {
            OnOrderProccess?.Invoke(orderId);
        }

        static public void MessageClient(int orderId)
        {
            Console.WriteLine($"Уведомление клиенту: Ваш заказ {orderId} готов!");
        }

        static public void MessageManager(int orderId)
        {
            Console.WriteLine($"Уведомление менеджеру: Заказ {orderId} обработан.");
        }
    }
}
