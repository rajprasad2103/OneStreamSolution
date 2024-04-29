//< summary >
// constructor class.
//</ summary >
//< author> Rajendra Jaradoddi</ author >

namespace Assessment2
{

    class A
    {
        // Craete a and b properties
        public int a { get; set; }
        public int b { get; set; }
    }

    class B
    {
        // Constant field value must be initialized and can not be changed.
        // Assigning a value in the constructor of class B, 
        // public const A a; -- OLD CODE
        public A a = new A(); // Craete object for Class A

        public B()
        {
            a.a = 10;
        }
    }

    //------- OLD CODE -------------

    //class A
    //{
    //    public int a { get; set; }
    //    public int b { get; set; }
    //}

    //class B
    //{
    //    public const A a;
    //    public B() { a.a = 10; }
    //}

    //int main()
    //{
    //    B b = new B();
    //    Console.WriteLine("%d %d\n", b.a.a, b.a.b); return 0;
    //}


}
