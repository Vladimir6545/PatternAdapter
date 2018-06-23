using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_
{
    class OldSystem
    {
        public string ThinSocket() { return "ThinSocket"; }
    }
    class MySocket
    {
        public string MySocet()
        {
            return "MySocket";
        }
    }
    interface INewSystem
    {
        string WideSocket();
    }
    interface IOldSystem
    {
        string MySocket();
    }
    class Adapter : INewSystem, IOldSystem
    {
        readonly OldSystem _adaptee;
        readonly MySocket _adapt;
        public Adapter(OldSystem adaptee)
        {
            _adaptee = adaptee;
        }
        public Adapter(MySocket m)
        {
            _adapt = m;
        }

        public string MySocket()
        {
            return _adapt.MySocet();
        }

        public string WideSocket()
        {
            return _adaptee.ThinSocket();
        }
    }
    class Program
    {
        public static void ChangeLapTop(INewSystem system)
        {
            Console.WriteLine(system.WideSocket());
        }
        public static void ChangeLapTops(IOldSystem system)
        {
            Console.WriteLine(system.MySocket());
        }
        static void Main(string[] args)
        {
            OldSystem oldSystem = new OldSystem();
            MySocket mmm = new MySocket();
            Adapter adapt = new Adapter(oldSystem);
            Adapter adap = new Adapter(mmm);
            ChangeLapTop(adapt);
            ChangeLapTops(adap);
        }
    }
}
