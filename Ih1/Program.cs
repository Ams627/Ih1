using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ih1
{
    class A
    {
        protected A()
        {
            Console.WriteLine("Protected constructor A");
        }

        public void F()
        {
            Console.WriteLine("F in class A");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("Protected constructor B");
        }

        protected new virtual void F()
        {
            Console.WriteLine("F in class B");
        }
    }

    class C : B
    {
        public C()
        {
            Console.WriteLine("Protected constructor B");
        }
        protected override void F()
        {
            Console.WriteLine("F in class C");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                (new A()).F();
                ((A)new B()).F();
                
                ((A)new B()).F();
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
