using System.Diagnostics;

namespace InterfaceJikken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                MyClass2 asClassInstance = new MyClass2();
                MyInterface2 asInterface = new MyClass2();

                Debug.WriteLine("mc2");
                asClassInstance.Method1_1();                    // 1

                Debug.WriteLine("mc2 class");
                ((MyClass1)asClassInstance).Method1_1();        // 2
                ((MyClass2)asClassInstance).Method1_1();        // 3

                Debug.WriteLine("mc2 if");
                ((MyInterface1)asClassInstance).Method1_1();    // 4
                ((MyInterface2)asClassInstance).Method1_1();    // 5

                Debug.WriteLine("mi2");
                asInterface.Method1_1();                        // 6

                Debug.WriteLine("mi2 class");
                ((MyClass1)asInterface).Method1_1();            // 7
                ((MyClass2)asInterface).Method1_1();            // 8

                Debug.WriteLine("mi2 if");
                ((MyInterface1)asInterface).Method1_1();        // 9
                ((MyInterface2)asInterface).Method1_1();        // 10
            }
        }
    }

    internal interface MyInterface1
    {
        void Method1_1();
    }
    internal interface MyInterface2 : MyInterface1
    {
        // 実質、MyInterface1と同じものを持ったinterface
    }
#if true // パターン１
    internal class MyClass1 : MyInterface1
    {
        public void Method1_1() => Debug.WriteLine(" Method1_1 of MyClass1");  // ①
    }

    internal class MyClass2 : MyClass1, MyInterface2
    {
        public new void Method1_1() => Debug.WriteLine(" Method1_1 of MyClass2");  // ②
    }
#endif

#if false // パターン２
    internal class MyClass1 : MyInterface1
    {
        public void Method1_1() => Debug.WriteLine(" Method1_1 of MyClass1");  // ①
    }

    internal class MyClass2 : MyClass1, MyInterface2
    {
        void MyInterface1.Method1_1() => Debug.WriteLine(" Method1_1 of MyClass2");  // ②
    }
#endif

#if false // パターン３
    internal class MyClass1 : MyInterface1
    {
        public virtual void Method1_1() => Debug.WriteLine(" Method1_1 of MyClass1");  // ①
    }

    internal class MyClass2 : MyClass1, MyInterface2
    {
        public override void  Method1_1() => Debug.WriteLine(" Method1_1 of MyClass2");  // ②
    }
#endif
}