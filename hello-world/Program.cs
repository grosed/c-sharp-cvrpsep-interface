using System;

using System.Runtime.InteropServices;


public class Tester
{
        [DllImport("libprint.so", EntryPoint="print")]

        static extern void print(string message);

        public static void Main(string[] args)
        {

                print("Hello World C# => C++");
        }
}



// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
