using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public BindingList<User> users;
        public string name;
        public Form2(BindingList<User> users, string name)
        {
            InitializeComponent();
            this.users = users;
            this.name = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in users)
            {
                if (name == item.username)
                {
                    //first check whether old password is correct
                    if (textBox1.Text == item.password)
                    {
                        if (item.restrict == true)
                        {
                            bool res = false;
                            res = User.Restrict(textBox2.Text);
                            if (res == false)
                            {
                                MessageBox.Show("Пароль не следует ограничениям");
                                break;
                            }
                        }

                        if (textBox2.Text == textBox3.Text)
                        {
                            if (textBox1.Text == textBox2.Text)
                            {
                                MessageBox.Show("Старый и новый пароли не должны совпадать");
                                break;
                            }
                            item.password = textBox2.Text;
                            users.RemoveAt(users.IndexOf(item)); //remove old one and add new one at the new line
                            users.Add(new User(item.username, item.password, item.block, item.restrict, false));
                            MessageBox.Show("Пароль успешно изменил");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают");
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введен неправильный старый пароль");
                        break;
                    }
                }
            }
            this.Close();
        }
    }
}
