using DIDemoLib;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class App
    {
        public App(IMessages messages)
        {
            _messages = messages;
        }

        public IMessages _messages { get; }

        public void Run()
        {
            Console.WriteLine(_messages.SayHello());
            Console.WriteLine(_messages.SayGoodbye());

            Console.ReadLine();
        }
    }
}
