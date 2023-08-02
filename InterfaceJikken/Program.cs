using System.Diagnostics;

namespace InterfaceJikken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                MyClass1 mc1 = new MyClass1();
                MyInterface1 mi1 = new MyClass1();

                //mc1.Method1_1();
                //mc1.Method1_2();
                //((MyInterface1)mc1).Method1_1();
                //((MyInterface1)mc1).Method1_2();
            }

            {
                MyClass2 mc2 = new MyClass2();
                MyInterface2 mi2 = new MyClass2();

                Debug.WriteLine("mc2");
                mc2.Method1_1();
                mc2.Method1_2();

                Debug.WriteLine("mc2 class");
                ((MyClass1)mc2).Method1_1();
                ((MyClass1)mc2).Method1_2();
                ((MyClass2)mc2).Method1_1();//不要なキャスト
                ((MyClass2)mc2).Method1_2();//不要なキャスト

                Debug.WriteLine("mc2 if");
                ((MyInterface1)mc2).Method1_1();
                ((MyInterface1)mc2).Method1_2();
                ((MyInterface2)mc2).Method1_1();
                ((MyInterface2)mc2).Method1_2();

                Debug.WriteLine("mi2");
                mi2.Method1_1();
                mi2.Method1_2();

                Debug.WriteLine("mi2 class");
                ((MyClass1)mi2).Method1_1();
                ((MyClass1)mi2).Method1_2();
                ((MyClass2)mi2).Method1_1();
                ((MyClass2)mi2).Method1_2();

                Debug.WriteLine("mi2 if");
                ((MyInterface1)mi2).Method1_1();//不要なキャスト
                ((MyInterface1)mi2).Method1_2();//不要なキャスト
                ((MyInterface2)mi2).Method1_1();//不要なキャスト
                ((MyInterface2)mi2).Method1_2();//不要なキャスト
            }
        }
    }

    internal interface MyInterface1
    {
        void Method1_1();
        void Method1_2();
    }
    internal interface MyInterface2 : MyInterface1
    {
        void Method2_1();
    }

    internal class MyClass1 : MyInterface1
    {
        public virtual void Method1_1() => Debug.WriteLine(" Method1_1 of MyClass1");  // ★ココが②と違う
        public void Method1_2()=> Debug.WriteLine(" Method1_2 of MyClass1");
    }

    internal class MyClass2 : MyClass1, MyInterface2
    {
        public override void Method1_1() => Debug.WriteLine(" Method1_1 of MyClass2");  // ★ココが②と違う
        public void Method1_2() => Debug.WriteLine(" Method1_2 of MyClass2");
        public void Method2_1() => Debug.WriteLine(" Method2_1 of MyClass2");
    }
}