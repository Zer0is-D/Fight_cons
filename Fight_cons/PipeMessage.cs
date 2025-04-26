using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace FightCons
{
    internal class PipeMessage
    {
        public static bool DialogInturapted = false;
        private static string ListenerPath = @"C:\Users\user\source\repos\AsyncListener\AsyncListener\bin\Debug\net6.0\AsyncListener.exe"; // это можно улучшить

        private static ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/k start cmd /k {ListenerPath}",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            CreateNoWindow = false,
            Environment = { { "ComSpec", "cmd.exe" } }
        };
        private static Process process = new Process { StartInfo = startInfo };

        public static void TavernLocal(Hero hero)
        {
            string MyPipe = "MyPipe";
            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(MyPipe, PipeDirection.Out))
            {
                try
                {
                    process.Start();

                    CheckAndWaitConnectionAsync(pipeServer);

                    string[] Dialogs = Spying.TavernTalks(hero.Statistic.TavernTalksProgress);

                    // Отправка сообщения на сервер
                    SendMessage(pipeServer, Dialogs);

                    if (!CheckForInturaption(pipeServer))
                        hero.Statistic.TavernTalksProgress++;

                    pipeServer.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    pipeServer.Close();
                }
            }
        }

        public static async Task<bool> AdSpellAsync(string[] messageMas)
        {
            string PipeName = "MyPipe";
            sbyte Turn = 0;

            while (true)
            {
                Process[] processes = Process.GetProcessesByName(PipeName);

                Console.WriteLine("процесс уже запущен, создаю новый");

                Turn++;
                PipeName += Turn.ToString();
                if (processes.Length > 0)
                {

                }
                else
                    break;
            }



            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.Out))
            {
                try
                {
                    process.Start();

                    //sbyte d = 0;

                    //CheckAndWaitConnectionAsync(pipeServer);

                    SendMessage(pipeServer, messageMas);

                    while (pipeServer.IsConnected)
                    {
                        await Task.Delay(100);
                        if (pipeServer.IsConnected)
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    //pipe.Close();
                    return true;
                }
            }

            return true;
        }

        public static void MultiAdSpellAsync(string[] messageMas, sbyte num)
        {            
            List<NamedPipeServerStream> PipesServer = new List<NamedPipeServerStream>();
            List<string> proccesNames = new List<string>();
            List<int> proccesIds = new List<int>();

            for (sbyte i = 0; i < num;)
            {
                Process localProcess = new Process();

                PipesServer.Add(new NamedPipeServerStream($"MyPipe{i}", PipeDirection.Out));
                localProcess.StartInfo = startInfo;
                localProcess.StartInfo.Arguments = $"/k start cmd /k {ListenerPath} MyPipe{i}";

                localProcess.Start();

                proccesNames.Add(localProcess.ProcessName);
                proccesIds.Add(localProcess.Id);

                PipesServer[i].WaitForConnection();

                SendMessage(PipesServer[i], messageMas);

                i++;
            }

            while (true)
            {
                sbyte i = 0;

                foreach (var procId in proccesNames)
                {
                    Process[] process = null;

                    try
                    {
                        process = Process.GetProcessesByName(procId);

                        if (process.Length == 1)
                            i++;
                    }
                    catch (ArgumentException)
                    {
                        i++;
                    }                   
                }

                if (i == num)
                    break;
            }

            foreach (var pipe in PipesServer)
                pipe.Close();

            foreach (var procId in proccesIds)
            {
                try
                {
                    Process process = Process.GetProcessById(procId);
                    process.Kill();
                }
                catch (ArgumentException)
                {

                }
            }              
        }

        private static async Task<bool> CheckAndWaitConnectionAsync(NamedPipeServerStream pipeServer)
        {
            sbyte d = 0;

            while (!pipeServer.IsConnected)
            {
                if (d == 10)
                {
                    Console.WriteLine("Ошибка подключения другой консоли");
                    break;
                }

                //pipeServer.WaitForConnectionAsync();
                await Task.Delay(100);
                d++;
            }

            return true;
        }

        private static void SendMessage(NamedPipeServerStream pipeServer, string[] messageMas)
        {
            // Отправка сообщения на сервер
            for (sbyte i = 0; i < messageMas.Length; i++)
            {
                string message = messageMas[i];
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                pipeServer.WriteAsync(buffer, 0, buffer.Length);

                if (DialogInturapted)
                    break;
            }
        }

        private static bool CheckForInturaption(NamedPipeServerStream pipeServer)
        {
            if (pipeServer.IsConnected)
            {
                if (!DialogInturapted)
                    return false;
                else
                    DialogInturapted = true;
            }

            return true;
        }
    }

    //  Soket junk!
    //private static string TavernConversations = @"C:\Users\user\source\repos\SoketListner\SoketListner\bin\Debug\net6.0\SoketListner.exe";

    //if (Process.GetProcessesByName("SoketListner").Any())
    //{
    //    Console.WriteLine("NO");
    //}
    //else
    //{
    //    //process.Start();
    //}

    //try
    //{
    //    string serverIP = "127.0.0.1"; // IP-адрес сервера
    //    int serverPort = 1234; // Порт сервера

    //    // Создание клиентского сокета
    //    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    //    await clientSocket.ConnectAsync(serverIP, serverPort); // Подключение к серверу

    //    string[] mas =
    //    {
    //            "Слушая болтовню в трактире, вас увлек разговор группы запивак: ",
    //            "- ...Помните? Так вот вы представляете, я его аж 5 раз убил. А он все живой. \nЯ таких чудишь еще видывал. ",
    //            "- Вранье! Да не мог ты его! Все тот лес за сотню миль обходят. ",
    //            "- Да! Вруешь! ",
    //            "- И смельчаки, что живые прискакали, и слово теперь не вымолвят. \nА ты то как языком чешешь. - сказал посмеиваясь мужчина рядом. ",
    //            "Мужики посмеялись кроме пустослова. ",
    //            "- Эх, ну вас... Но морда у него..*ДУХ* ",
    //            "Грохот от упавшей бочки отвлек вас.\n"
    //    };

    //    // Отправка сообщения на сервер
    //    for (sbyte i = 0; i > mas.Length;)
    //    {                    
    //        string message = mas[i]; // Ваше сообщение
    //        byte[] buffer = Encoding.UTF8.GetBytes(message);
    //        await clientSocket.SendAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
    //        i++;
    //    }                


    //    await WaitAnswer(clientSocket, hero);

    //    // Закрытие клиентского сокета
    //    clientSocket.Close();
    //}
    //finally
    //{
    //    pipeServer.Close();
    //}

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

    //private static async Task WaitAnswer(Socket serverSocket, Hero hero)
    //{
    //    string IP = "127.0.0.1";
    //    int serverPort = 1234;

    //    serverSocket.Bind(new IPEndPoint(IPAddress.Parse(IP), serverPort));
    //    serverSocket.Listen(1);

    //    Socket clientSocket = await serverSocket.AcceptAsync();

    //    BytesRead = await clientSocket.ReceiveAsync(new ArraySegment<byte>(Buffer), SocketFlags.None);

    //    if (BytesRead > 0)
    //    {
    //        string requestData = Encoding.UTF8.GetString(Buffer, 0, BytesRead);
    //        Console.WriteLine(requestData);
    //        hero.Statistic.TavernTalksProgress++;
    //    }
    //}
}
