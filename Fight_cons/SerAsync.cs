using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace Fight_cons
{
    /// Структура работы метода
    /// 1) Передача сериализированных данных
    /// 2) Чтение первой строчки (выбор метода)
    /// 3) Параметры для метода
    /// 
    internal class SerAsync
    {
        private static NamedPipeServerStream pipeServer = new NamedPipeServerStream("MyPipe", PipeDirection.InOut);
        //private static string TavernConversations = @"C:\Users\user\source\repos\AsyncListener\AsyncListener\bin\Debug\net6.0\AsyncListener.exe";
        private static string TavernConversations = @"C:\Users\user\source\repos\SoketListner\SoketListner\bin\Debug\net6.0\SoketListner.exe";        

        private static byte[] Buffer = new byte[1024];
        private static int BytesRead;

        public static int Port = 12345;
        public enum Meto
        {
            tavern,
            echo
        }

        //public static async Task SecondWindow(Charecter hero)
        //{
        //    ///  Уточнить насчет вызова в конкретной позиции и размера окна
        //    ///  Окна
        //    ///  1) Окно с изображением персонажа
        //    ///  2) Окно со слухами на локации()
        //    ///  3) Окно с рекламой
        //    ///  4) Окно 

        //    using (Socket senderSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        //    {
        //        await senderSocket.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port));

        //        string serializerString = $"{hero.TotalMaxHP}\n{hero.TotalHP}";

        //        byte[] data = Encoding.UTF8.GetBytes(serializerString);
        //        await senderSocket.SendAsync(new ArraySegment<byte>(data), SocketFlags.None);
        //    }            
        //}

        //  Заброшеный фрагмент кода
        //  нужно понять почему 2 приложение запускается в фоне 
        public static async Task TavernLocal(Hero hero)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/k start cmd /k {TavernConversations}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = false,
                Environment = { { "ComSpec", "cmd.exe" } }
            };
            Process process = new Process { StartInfo = startInfo };

            if (Process.GetProcessesByName("SoketListner").Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                //process.Start();
            }

            try
            {
                string serverIP = "127.0.0.1"; // IP-адрес сервера
                int serverPort = 1234; // Порт сервера

                // Создание клиентского сокета
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                await clientSocket.ConnectAsync(serverIP, serverPort); // Подключение к серверу

                // Отправка сообщения на сервер
                string message = $"{hero.HeroSpying.TavernTalksProgress}"; // Ваше сообщение
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await clientSocket.SendAsync(new ArraySegment<byte>(buffer), SocketFlags.None);


                await WaitAnswer(clientSocket, hero);

                // Закрытие клиентского сокета
                clientSocket.Close();
            }
            finally
            {
                pipeServer.Close();
            }           
        }

        private static async Task WaitAnswer(Socket serverSocket, Hero hero)
        {
            string IP = "127.0.0.1";
            int serverPort = 1234;

            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(IP), serverPort));
            serverSocket.Listen(1);

            Socket clientSocket = await serverSocket.AcceptAsync();

            BytesRead = await clientSocket.ReceiveAsync(new ArraySegment<byte>(Buffer), SocketFlags.None);

            if (BytesRead > 0)
            {
                string requestData = Encoding.UTF8.GetString(Buffer, 0, BytesRead);
                Console.WriteLine(requestData);
                hero.HeroSpying.TavernTalksProgress++;
            }
        }
    }

    //internal class SerProcces
    //{
    //    public static async Task Onather()
    //    {
    //        string AppPath = @"C:\Users\user\source\repos\AsyncListener\AsyncListener\bin\Debug\net6.0\AsyncListener.exe";

    //        //  Запуск стороны
    //        using (Process process = new Process())
    //        {
    //            try
    //            {
    //                process.StartInfo.FileName = AppPath;
    //                process.StartInfo.CreateNoWindow = false;
    //                process.StartInfo.UseShellExecute = true;
    //                process.Start();

    //                //// Дожидаемся завершения второго приложения (не обязательно)
    //                //process.WaitForExit();

    //                //Console.WriteLine("First application continues execution.");
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine($"Error: {ex.Message}");
    //            }
    //        }

    //        //using (Socket senderSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
    //        //{
    //        //    await senderSocket.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port));

    //        //    string serializerString = $"{Meto.tavern}";

    //        //    byte[] data = Encoding.UTF8.GetBytes(serializerString);
    //        //    await senderSocket.SendAsync(new ArraySegment<byte>(data), SocketFlags.None);
    //        //}
    //    }
    //}
}
