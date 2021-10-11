using NetPythonInteropExperiments;
using Python.Runtime;

Runtime.PythonDLL = "libpython3.6m.so";

using var gilState = Py.GIL();
using var scope = Py.CreateScope();

using var obj = new NetObject { StrProp = "Str value", IntProp = 42 }.ToPython();
scope.Set("obj", obj);

scope.Exec("print(obj.Method('Python str', 24))");