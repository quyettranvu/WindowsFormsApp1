using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool block { get; set; }
        public bool restrict { get; set; }
        public bool first { get; set; }

        public User(string username, string password, bool block, bool restrict, bool first)
        {
            this.username = username;
            this.password = password;
            this.block = block;
            this.restrict = restrict;
            this.first = first;
        }

        public static bool Restrict(string password)
        {
            //Regex r = new Regex(@"/^([0-9][a-zA-Z])+$/");
            Regex r = new Regex("^([0-9][a-zA-Z][0-9])+$");
            if ((r.IsMatch(password))== true)
            {
                return true;
            }
            return false;
        }
       
    }
}
