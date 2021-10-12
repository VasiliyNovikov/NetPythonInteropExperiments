using System;

namespace NetPythonInteropExperiments
{
    public class TestClient
    {
        private readonly string _name;
        public TestClient(string name) => _name = name;
        public void Add(int a, int b) => Console.WriteLine($"{_name}: {a} + {b} = {a + b}");
    }
}