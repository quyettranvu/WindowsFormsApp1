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
    public partial class Form5 : Form
    {
        public BindingList<User> users = new BindingList<User>();
        public static string decryptedText = "";
        public Form5()
        {
            InitializeComponent();
            while (true)
            {
                try
                {
                    using (StreamReader accounts = new StreamReader("accounts.txt"))
                    {
                        StreamWriter accounts_encrypted = new StreamWriter("accounts_encrypted.txt");
                        string line;
                        line = accounts.ReadLine();
                        while (line != null)
                        {
                            string line_encrypted= CryptoEngine.Encrypt(line, true);
                            accounts_encrypted.WriteLine(line_encrypted);
                            string[] words = line.Split('#');
                            users.Add(new User(words[0], words[1], Convert.ToBoolean(words[2]), Convert.ToBoolean(words[3]), Convert.ToBoolean(words[4])));
                            line = accounts.ReadLine();
                        }
                        accounts_encrypted.Close();
                        break;
                    }
                }
                catch (Exception)
                {
                    using (StreamWriter accounts = new StreamWriter("accounts.txt", true))
                    {
                        accounts.WriteLine("ADMIN# #false#false#true");
                    }
                }
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string cipherText = Encryptedpass.Text.Trim();
            try
            {
                using (StreamReader encryptedPass = new StreamReader("encryptedpass.txt"))
                {
                    string line;
                    line = encryptedPass.ReadLine();
                    if (cipherText != line)
                    {
                        MessageBox.Show("Неправильная парольная фраза");
                    }
                    else
                    {
                        encryptedPass.Close();
                        decryptedText = CryptoEngine.Decrypt(cipherText, true);
                        using (StreamWriter decryptedPass = new StreamWriter("decryptedpass.txt"))
                        {
                            //Write a line of text
                            decryptedPass.WriteLine(decryptedText);
                            decryptedPass.Close();
                        }
                        
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }

            Form4 Auth = new Form4(users);
            Auth.Show();
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Надо вводить парольную фразу чтобы продолжить");
        }
    }
}
