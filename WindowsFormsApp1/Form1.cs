using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //public BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            //while (true)
            //{
            //    try
            //    {
            //        using (StreamReader accounts = new StreamReader("accounts.txt"))
            //        {
            //            string line;
            //            line = accounts.ReadLine();
            //            while (line != null)
            //            {
            //                string[] words = line.Split('#');
            //                users.Add(new User(words[0], words[1], Convert.ToBoolean(words[2]), Convert.ToBoolean(words[3]), Convert.ToBoolean(words[4])));
            //                line = accounts.ReadLine();
            //            }
            //            break;
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        using (StreamWriter accounts = new StreamWriter("accounts.txt", true))
            //        {
            //            accounts.WriteLine("ADMIN# #false#false#true");
            //        }
            //    }
            //}
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student: Чан Ву Кует  \nGroup: ИДБ-19-02 \nTask: Чередование цифр, букв и снова цифр.");
        }

        private void EnterAtSystemButton_Click(object sender, EventArgs e)
        {
            Form5 Decrypt = new Form5();
            Decrypt.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
