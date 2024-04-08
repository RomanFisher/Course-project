using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using курсовий_проект_100.Forms;

namespace курсовий_проект_100
{
    public partial class Form1 : Form
    {
        List<Doctor> doctors = new List<Doctor>();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
            this.Text = "";
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
        }
        private void UpDat()
        {
            
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Лікарі.dat", FileMode.OpenOrCreate))
                {

                   doctors = (List<Doctor>)binaryFormatter.Deserialize(fileStream);

                }
                
            }
            catch {  }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpDat();
            bool tt = true;
            if (textBox1.Text == "admin" && textBox2.Text == "admin1111")
            {
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            else
            {

                for (int l = 0; l < doctors.Count; l++)
                {

                    if (textBox1.Text == doctors[l].getLogin() && textBox2.Text == doctors[l].getPasswrd())
                    {
                        tt = false;
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        using (FileStream fileStream = new FileStream("cookies.dat", FileMode.Create))
                            binaryFormatter.Serialize(fileStream, doctors[l]);
                        Main a = new Main();
                        a.Show();
                        this.Hide();
                        break;
                    }

                   
                }
                if(tt)
                 MessageBox.Show("Неправильний логін або пароль");
            }
            
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.BringToFront();
                textBox2.PasswordChar = '\0';
                linkLabel1.Text = "сховати";
            }
            else
            {
                textBox2.PasswordChar = '*';
               linkLabel1.Text = "показати пароль";
            }

        }
    }
}
