using System;

namespace WorkerRoleCommandProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var processor = new ReservationProcessor())
            {
                processor.Start();

                Console.WriteLine("Host started");
                Console.WriteLine("Press enter to finish");
                Console.ReadLine();

                processor.Stop();
            }
        }
    }
}
