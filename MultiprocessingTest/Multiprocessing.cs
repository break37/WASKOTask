using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MultiprocessingTest
{
    class Multiprocessing
    {
        private const int ITERATIONS = 1000000;
        private const int TASK_ITERATIONS = 100;

        static void Main(string[] args)
        {

            Task interruptingTask = new Task(PrintInterruption);
            Thread interruptingThread = new Thread(PrintInterruption);

            interruptingThread.Start();

            for (int i = 0; i < ITERATIONS; i++)
            {
                Console.Write($"\r{(double)i / ITERATIONS * 100}");
            }
        }

        private static void PrintInterruption()
        {
            for (int i = 0; i < TASK_ITERATIONS; i++)
            {
                Console.WriteLine($"\n{i + 1} interruption");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
