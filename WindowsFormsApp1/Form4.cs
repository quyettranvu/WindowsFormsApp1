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
    public partial class Form4 : Form
    {
        public BindingList<User> users;
        public static string encryptedText = "";
        public Form4(BindingList<User> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in users)
            {
                //if first time user logged in then need to show confirmed password
                if (item.first == true)
                {
                    if (Username.Text == item.username)
                    {
                        label3.Show();
                        SubmitPass.Show();
                        break;
                    }
                    else
                    {
                        label3.Hide();
                        SubmitPass.Hide();
                        break;
                    }
                }
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            foreach (var item in users)
            {
                if (Username.Text == item.username)
                {
                    //if the first time user logged in 
                    if (item.first==true)
                    {
                        if (item.restrict == true) 
                        {
                            //check password is valid with the restrictions
                            bool res = false;
                            res = User.Restrict(Password.Text);
                            if (res == false)
                            {
                                MessageBox.Show("Пароль не следует ограничениям");
                                break;
                            }
                        }

                        item.password = Password.Text;
                        if (item.password == SubmitPass.Text)
                        {
                            //if confirmed password is like current password then add user in the list
                            users.RemoveAt(users.IndexOf(item));
                            users.Add(new User(item.username,item.password,item.block,item.restrict, false));
                            label3.Visible = false;
                            SubmitPass.Visible = false;
                            MessageBox.Show("Пароль успешно установлен");
                            break;
                        }
                        else
                        {
                            //if confirmed password is not the same then show that they are not the same
                            MessageBox.Show("Пароли не совпадают");
                            break;
                        }
                    }
                    //if from second time then just check password
                    else
                    {
                        if (item.password == Password.Text)
                        {
                            if (item.block == true)
                            {
                                //if account is blocked then show message that account is currently locked
                                MessageBox.Show("Ваш аккаунт заблокирован");
                                break ;
                            }

                            //Take password, encrypt it and get into main window
                            string cipherText = Password.Text.Trim();
                            encryptedText = CryptoEngine.Encrypt(cipherText, true);
                            StreamWriter encryptedPass = new StreamWriter("encryptedpass.txt");
                            //Write a line of text
                            encryptedPass.WriteLine(encryptedText);
                            encryptedPass.Close();
                            Form3 userWindow = new Form3(item.username, users);
                            userWindow.Show();
                            this.Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль");
                            break;
                        }
                    }
                }
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
