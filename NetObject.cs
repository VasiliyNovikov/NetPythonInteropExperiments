namespace NetPythonInteropExperiments
{
    public class NetObject
    {
        public string? StrProp { get; set; }
        public int IntProp { get; set; }
        public string Method(string strParam, int intParam) => $"Method called for {strParam} and {intParam}";
    }
}