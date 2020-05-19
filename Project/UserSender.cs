using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class UserSender
    {
        public UserSender(VenturiControl obj)
        {
            obj.CreateEvent += Usermsg;
            obj.CalculateEvent += Usermsg;
            obj.SaveEvent += Usermsg;
            obj.LetterEvent += Usermsg;
        }
        private void Usermsg(object sender, NewVentEventArgs e)
        {
            Console.WriteLine($"{e.Msg}");
        }
    }
}
