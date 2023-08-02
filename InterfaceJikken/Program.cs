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
                asClassInstance.Method1_1();

                Debug.WriteLine("mc2 class");
                ((MyClass1)asClassInstance).Method1_1();
                ((MyClass2)asClassInstance).Method1_1();

                Debug.WriteLine("mc2 if");
                ((MyInterface1)asClassInstance).Method1_1();
                ((MyInterface2)asClassInstance).Method1_1();

                Debug.WriteLine("mi2");
                asInterface.Method1_1();

                Debug.WriteLine("mi2 class");
                ((MyClass1)asInterface).Method1_1();
                ((MyClass2)asInterface).Method1_1();

                Debug.WriteLine("mi2 if");
                ((MyInterface1)asInterface).Method1_1();//不要なキャスト
                ((MyInterface2)asInterface).Method1_1();//不要なキャスト
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
#if true // ①
    internal class MyClass1 : MyInterface1
    {
        public void Method1_1() => Debug.WriteLine(" Method1_1 of MyClass1");  // ①
    }

    internal class MyClass2 : MyClass1, MyInterface2
    {
        public new void Method1_1() => Debug.WriteLine(" Method1_1 of MyClass2");  // ②
    }
#endif

#if false // ②
    internal class MyClass1 : MyInterface1
    {
        public void Method1_1() => Debug.WriteLine(" Method1_1 of MyClass1");  // ①
    }

    internal class MyClass2 : MyClass1, MyInterface2
    {
        void MyInterface1.Method1_1() => Debug.WriteLine(" Method1_1 of MyClass2");  // ②
    }
#endif

#if false // ③
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