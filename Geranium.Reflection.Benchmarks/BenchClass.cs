using System.Diagnostics;

namespace Geranium.Reflection.Benchmarks
{
    [DebuggerDisplay("{I}{S}{O}")]
    public class BenchClass
    {
        public BenchClass() { }

        public BenchClass(int i, string s)
        {
            this.I = i;
            this.S = s;
        }

        public BenchClass(string s, int i) : this(i, s) { }

        public BenchClass(int i, string s, object o) : this(i, s) { this.O = o; }
        
        public int I { get; set; }

        public string S { get; set; }

        public object O { get; set; }

        public override string ToString() => $"{I}{S}{O}";
    }
}
