//< summary >
// Animal Polymorphism overridden class.
//</ summary >
//< author> Rajendra Jaradoddi</ author >

namespace Assessment1
{
    class Animal
    {
        public virtual string speak(int x) { return "silence"; }
    }

    class Cat : Animal
    {
        public string speak(int x) { return "meow"; }
    }

    class Dog : Animal
    {
       
        public string speak(int x) { return "bow-wow"; }

        // Old Code
        // public string speak(short x) { return "bow-wow"; } // Sinature datatype mismatch
    }


}
