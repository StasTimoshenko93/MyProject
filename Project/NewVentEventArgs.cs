using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class NewVentEventArgs : EventArgs
    {
        private readonly string _msg;
       public NewVentEventArgs(string msg)
        {
            _msg = msg;
        }

        public string Msg { get { return _msg; } }
    }
}
