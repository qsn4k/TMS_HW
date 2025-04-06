namespace Lesson_11_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pair<int, string> pair = new Pair<int, string>(10, "Hello world");
            pair.Write();
            ComparablePair<int, string> comparablePair1 = new ComparablePair<int, string>(10, "b");
            ComparablePair<int, string> comparablePair2 = new ComparablePair<int, string>(10, "a");
            Console.WriteLine(comparablePair1.CompareTo(comparablePair2));

        }

        class ComparablePair<T1, T2> : Pair<T1, T2>, IComparable<ComparablePair<T1, T2>>
            where T1 : IComparable<T1>
            where T2 : IComparable<T2>
        {

            public ComparablePair(T1 a, T2 b) : base(a, b)
            {
            }

            public int CompareTo(ComparablePair<T1, T2>? other)
            {
                if (A.CompareTo(other.A) > 0) return 1;
                else if (A.CompareTo(other.A) < 0) return -1;
                else
                {
                    if (B.CompareTo(other.B) > 0) return 1;
                    else if (B.CompareTo(other.B) < 0) return -1;
                    else return 0;
                }
            }
        }


        class Pair<T1, T2>
        {
            public T1 A { get; set; }

            public T2 B { get; set; }

            public Pair(T1 a, T2 b)
            {
                this.A = a;
                this.B = b;
            }

            public void Write()
            {
                Console.WriteLine($"Значение переменной a:{A}" +
                    $"\nЗначение переменной b:{B}");
            }
        }
    }
}
