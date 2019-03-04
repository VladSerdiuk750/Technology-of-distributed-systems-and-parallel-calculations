using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    delegate void MyEventHandler();
    //8 task complete
    class MyEvent
    {
        MyEventHandler[] events = new MyEventHandler[3];
        public event MyEventHandler SomeEvent
        {
            add
            {
                int i;
                for (i = 0; i < 3; i++)
                {
                    if (events[i] == null)
                    {
                        events[i] = value;
                        break;
                    }
                }
                if (i == 3) Console.WriteLine("List of handlers is full");
            }
            remove
            {
                int i;
                for (i = 0; i < 3; i++)
                {
                    if (events[i] == value)
                    {
                        events[i] = null;
                        break;
                    }
                }
                if (i == 3) Console.WriteLine("Event handler not found");
            }
        }
        public void OnSomeEvent()
        {
            for (int i = 0; i < 3; i++)
            {
                if (events[i] != null) events[i]();
            }
        }
    }

    class W
    {
        public void Whandler()
        {
            Console.WriteLine("W event was received");
        }
    }

    class X
    {
        public void Xhandler()
        {
            Console.WriteLine("X event was received");
        }
    }
    class Y
    {
        public void Yhandler()
        {
            Console.WriteLine("Y event was received");
        }
    }

    class Z
    {
        public void Zhandler()
        {
            Console.WriteLine("Z event was received");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "   Пример №2";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            var ev = new MyEvent();
            Console.WriteLine("Adding events handlers");
            var xOb = new X();
            ev.SomeEvent += new MyEventHandler(new W().Whandler);
            ev.SomeEvent += new MyEventHandler(xOb.Xhandler);
            ev.SomeEvent += new MyEventHandler(new Y().Yhandler);
            ev.SomeEvent += new MyEventHandler(new Z().Zhandler);
            Console.WriteLine();
            ev.OnSomeEvent();
            Console.WriteLine();
            Console.WriteLine("Deleting handler X");
            ev.SomeEvent -= new MyEventHandler(xOb.Xhandler);
            ev.OnSomeEvent();
            Console.WriteLine();
            Console.WriteLine("Trying to remove X");
            ev.SomeEvent -= new MyEventHandler(xOb.Xhandler);
            ev.OnSomeEvent();
            Console.WriteLine();
            Console.WriteLine("Adding handler Z");
            ev.SomeEvent += new MyEventHandler(new Z().Zhandler);
            ev.OnSomeEvent();
            //Console.WriteLine();
            //ev.SomeEvent -= new MyEventHandler(xOb.Xhandler);
            //ev.OnSomeEvent();
            Console.WriteLine("Для завершение работы приложение нажмите клавишу <Enter>");
            Console.Read();
        }
    }
}
