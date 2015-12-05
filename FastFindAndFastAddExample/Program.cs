using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFindAndFastAddExample
{
    public class Program
    {
        private const int ElementsCount = 20000000;
        private const int RemoveElement = 77777;
        static void Main(string[] args)
        {
            string[] data = new string[ElementsCount];
            Console.WriteLine("Please wait till all {0} will be initialized...", ElementsCount);
            for (int i = 0; i != ElementsCount; i++)
                data[i] = GenerateString(3, 20);

            //HashSet обеспечит максимальную скорость поиска и удаления элемента,
            //так как определяет индекс где хранить элемент по хэш коду объекта 
            HashSet<string> hashSet = new HashSet<string>();

            Console.WriteLine("Initialize HashSet by {0} elements", ElementsCount);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i != ElementsCount; i++)
                hashSet.Add(data[i]);
            stopWatch.Stop();
            Console.WriteLine("Initialize complete. " + GetTimeString(stopWatch));

            Console.WriteLine("Find and remove one element in HashSet");
            stopWatch = new Stopwatch();
            stopWatch.Start();
            hashSet.Remove(data[RemoveElement]);
            stopWatch.Stop();
            Console.WriteLine("Find and remove complete. " + GetTimeString(stopWatch));
            
            //List обеспечивает быстрое добавление элементов для хранения,
            //так как при добавлении элемента он просто добавляет его в конец списка
            List<string> listExample = new List<string>();
            Console.WriteLine("Initialize List by {0} elements", ElementsCount);
            stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i != ElementsCount; i++)
                listExample.Add(data[i]);
            stopWatch.Stop();
            Console.WriteLine("Initialize complete. " + GetTimeString(stopWatch));

            Console.WriteLine("Find and remove one element in a List");
            stopWatch = new Stopwatch();
            stopWatch.Start();
            listExample.Remove(data[RemoveElement]);
            stopWatch.Stop();
            Console.WriteLine("Find and remove complete. " + GetTimeString(stopWatch));
        }

        public static string GetTimeString(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return "RunTime " + elapsedTime;
        }

        public static string GenerateString(int minLength, int maxLength)
        {
            Random rand = new Random();
            StringBuilder result = new StringBuilder();
            int length = rand.Next(minLength, maxLength);
            for (int i = 0; i != length; i++)
                result.Append((char)('a' + rand.Next(26)));
            return result.ToString();
        }
    }
}
