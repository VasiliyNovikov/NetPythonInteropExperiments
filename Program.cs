using System.Collections.Generic;
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
dynamic? testMethod = module.HasAttr("test") ? module.GetAttr("test") : null;
dynamic? teardownMethod = module.HasAttr("teardown") ? module.GetAttr("teardown") : null;


var context = new Dictionary<string, object>();
var client1 = new TestClient("Client 1");
var client2 = new TestClient("Client 2");


if (setupMethod != null)
    setupMethod(context, client1, client2);

if (testMethod != null)
    testMethod(context, client1, client2);

if (teardownMethod != null)
    teardownMethod(context, client1, client2);
