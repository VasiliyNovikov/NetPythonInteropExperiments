using System.IO;
using System.Reflection;
using NetPythonInteropExperiments;
using Python.Runtime;

const string testModule = "test";
var testPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, testModule + ".py");

Runtime.PythonDLL = "libpython3.6m.so";

using var gilState = Py.GIL();
using var scope = Py.CreateScope();
var importlibUtil = scope.Import("importlib.util");

var spec = importlibUtil.spec_from_file_location(testModule, testPath);
var module = (PyObject)importlibUtil.module_from_spec(spec);
spec.loader.exec_module(module);

dynamic? setupMethod = module.HasAttr("setup") ? module.GetAttr("setup") : null;
setupMethod(null, null, null);

//using var obj = new NetObject { StrProp = "Str value", IntProp = 42 }.ToPython();
//scope.Set("obj", obj);

//scope.Exec("print(obj.Method('Python str', 24))");