using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.Instance;
            Singleton singleton2 = Singleton.Instance;

            singleton.DoWork();
        }
    }
}
