using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fight_cons
{
    internal class SER
    {
        public static async Task Main2Async(Hero hero)
        {
            //string secondAppPath = "C:\\Users\\user\\source\\repos\\ConsoleApp2\\ConsoleApp2\\bin\\Debug\\net6.0\\ConsoleApp2.exe";
            //string secondAppArguments = "222";

            //(new System.Threading.Thread(delegate ()
            //{
            //    Process process = new Process();
            //    process.StartInfo.UseShellExecute = true;
            //    process.StartInfo.CreateNoWindow = true;
            //    process.StartInfo.Arguments = "SECOND WINDOW";
            //})).Start();



            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 12345;

            using (Socket senderSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                await senderSocket.ConnectAsync(new IPEndPoint(ipAddress, port));

                string serializerString = $"{hero.TotalMaxHP}\n{hero.TotalHP}";

                //string input = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(serializerString);
                await senderSocket.SendAsync(new ArraySegment<byte>(data), SocketFlags.None);

                Console.WriteLine("Main application continues execution.");
            }

            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();

            //try
            //{
            //    Process process = new Process();
            //    process.StartInfo.FileName = "dotnet";
            //    process.StartInfo.Arguments = "run --project Fight_cons/SER2.csproj";
            //    process.StartInfo.CreateNoWindow = false;
            //    process.StartInfo.UseShellExecute = true;
            //    process.Start();

            //    // Дожидаемся завершения второго приложения (не обязательно)
            //    process.WaitForExit();

            //    Console.WriteLine("First application continues execution.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}

            //Console.WriteLine("Press ENTER to exit");
            //Console.ReadLine();
        }
    }
}
