using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Counter
    {
        static int numCounters = 0;

        int count;

        public Counter()
        {
            count = 0;
            numCounters++;
        }

        public int IncrementCount()
        {
            return ++count;            
        }

        public int GetCount()
        {
            return count;
        }

        public static int HowManyCounters()
        {
            return numCounters;
        }
    }

    class A
    {
        private B b;

        public A()
        {
            new B(this);
        }

        public A(B pB)
        {
            b = pB;
        }
    }

    class B
    {
        private A a;

        public B(A pA)
        {
            a = pA;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var counter1 = new Counter();

            Console.WriteLine(String.Format("Count 1 has count {0}: There are {1} counters.", counter1.GetCount(), Counter.HowManyCounters()));

            counter1.IncrementCount();
            counter1.IncrementCount();
            counter1.IncrementCount();
            counter1.IncrementCount();
            counter1.IncrementCount();
            counter1.IncrementCount();

            Console.WriteLine(String.Format("Count 1 has count {0}: There are {1} counters.", counter1.GetCount(), Counter.HowManyCounters()));

            var counter2 = new Counter();
            Console.WriteLine(String.Format("Count 2 has count {0}: There are {1} counters.", counter2.GetCount(), Counter.HowManyCounters()));
            counter1.IncrementCount();
            counter1.IncrementCount();
            counter1.IncrementCount();
            counter2.IncrementCount();
            counter2.IncrementCount();
            counter2.IncrementCount();
            counter2.IncrementCount();
            counter2.IncrementCount();
            counter2.IncrementCount();
            counter2.IncrementCount();
            counter2.IncrementCount();

            Console.WriteLine(String.Format("Count 1 has count {0}: There are {1} counters.", counter1.GetCount(), Counter.HowManyCounters()));
            Console.WriteLine(String.Format("Count 2 has count {0}: There are {1} counters.", counter2.GetCount(), Counter.HowManyCounters()));

            Console.WriteLine(String.Format("Count 2 has count {0}: There are {1} counters.", counter1.GetCount(), Counter.HowManyCounters()));

            Console.ReadLine();




            var a = new A();

            var b = new B(a);
        }
    }
}
