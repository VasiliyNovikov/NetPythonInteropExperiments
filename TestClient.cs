using System;

namespace NetPythonInteropExperiments
{
    public class TestClient
    {
        private readonly string _name;
        public TestClient(string name) => _name = name;

        public void Add(int a, int b) => Console.WriteLine($"{_name}: {a} + {b} = {a + b}");

        public void Call(string method, dynamic args, dynamic kwargs)
        {
            Console.WriteLine($"{_name} - Invoke method {method}:");
            Console.WriteLine("  args:");
            foreach (var arg in args)
                Console.WriteLine($"    {arg}");
            Console.WriteLine("  kwargs:");
            Console.WriteLine(kwargs);
            foreach (var kwarg in kwargs.items())
                Console.WriteLine($"    {kwarg[0]}: {kwarg[1]}");
        }
    }
}