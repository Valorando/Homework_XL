using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_09_11_II
{
    internal class Program
    {
        static int[] numbers = new int[10] { 5, 8, 12, 6, 74, 56, 7, 21, 9, 15 };
        static Mutex mutex = new Mutex();

        static void Original_array(int[] arr)
        {
            mutex.WaitOne();
            Console.WriteLine("Оригинальный массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);
            mutex.ReleaseMutex();
        }
        
        static void Modified_array(int[] arr)
        {
            mutex.WaitOne();
            Console.WriteLine("Массив, элементы которого увеличены на 5:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] += 5);
            }
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);
            mutex.ReleaseMutex();
        }

        static void Max_element(int[] arr)
        {
            mutex.WaitOne();
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Максимальный элемент: {arr.Max()}");
            }
            mutex.ReleaseMutex();
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => Original_array(numbers));
            Thread t2 = new Thread(() => Modified_array(numbers));
            Thread t3 = new Thread(() => Max_element(numbers));
            t1.Start();
            t2.Start();
            t3.Start();
            Console.Read();
        }
    }
}
