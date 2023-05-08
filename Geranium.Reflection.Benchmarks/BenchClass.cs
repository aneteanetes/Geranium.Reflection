using System.Diagnostics;

namespace Geranium.Reflection.Benchmarks
{
    [DebuggerDisplay("{I}{S}{O}{D}")]
    public class BenchClass
    {
        public BenchClass() { }

        public BenchClass(int i)
        {
            this.I = i;
        }

        public BenchClass(int i, string s) : this(i) { this.S=s; }

        public BenchClass(int i, string s, object o) : this(i, s) { this.O = o; }
        public BenchClass(int i, string s, object o, double d) : this(i, s,o) { this.D = d; }

        public int I { get; set; } = -1;

        public string S { get; set; }

        public object O { get; set; }

        public double D { get; set; }

        public override string ToString() => $"{I}{S}{O}{D}";
    }
}