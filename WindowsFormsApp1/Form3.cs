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
    public partial class Form3 : Form
    {
        public BindingList<User> users;
        public string name;
        public Form3(string name, BindingList<User> users)
        {
            InitializeComponent();
            this.users = users;
            this.name = name;
            //if not admin then no functions(add new user and show users)
            if (name != "ADMIN")
            {
                новыйПользовательToolStripMenuItem.Enabled = false;
                всеПользователиToolStripMenuItem.Enabled = false;
            }
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        
        //about program
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student: Чан Ву Кует \nGroup: ИДБ-19-02 \nTask: Чередование цифр, букв и снова цифр.");
        }

        //get out to the main window(write datas to the file)
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //when get out write all infos of users and clear decrypted file
            this.Close();
            using (StreamWriter accounts = new StreamWriter("accounts.txt", false))
            {
                foreach (var item in users)
                {
                    accounts.WriteLine(item.username + '#' + item.password + '#' + item.block + '#' + item.restrict + '#' + item.first);
                }
            }

            //get out then update accounts_encrypted file
            using (StreamReader accounts = new StreamReader("accounts.txt"))
            {
                StreamWriter accounts_encrypted = new StreamWriter("accounts_encrypted.txt", false);
                string line;
                line = accounts.ReadLine();
                while (line != null)
                {
                    string line_encrypted = CryptoEngine.Encrypt(line, true);
                    accounts_encrypted.WriteLine(line_encrypted);
                    line = accounts.ReadLine();
                }
                accounts_encrypted.Close();
            }

            //delete content of file decryptedpass
            StreamWriter decryptedPass = new StreamWriter("decryptedpass.txt");
            decryptedPass.WriteLine(string.Empty);
            decryptedPass.Close();
        }

        //create new user(show box for adding User with eventhandler click(Submit_Click)
        private void новыйПользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            RemoveBut.Visible = false;
            Username.Visible = true;
            label1.Visible = true;
            Submit.Visible = true;
        }

        //show all users
        private void всеПользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Username.Visible = false;
            label1.Visible = false;
            Submit.Visible = false;
            dataGridView1.Visible = true;
            RemoveBut.Visible = true;
            dataGridView1.DataSource = users; //get datas from users and put into DataSoucr of datagridView
            dataGridView1.Columns["username"].ReadOnly = true;
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["first"].Visible = false;
        }

        //add user
        private void Submit_Click(object sender, EventArgs e)
        {
            users.Add(new User(Username.Text, " ", false, false, true));
            MessageBox.Show("Добавил новый юзер с пустым паролем");
        }

        //remove user
        private void RemoveBut_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        //change password then open Form 2
        private void сменитьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 change = new Form2(users, name);
            change.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
