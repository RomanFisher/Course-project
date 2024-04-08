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

namespace курсовий_проект_100.Forms
{
    public partial class Setting : Form
    {
        Doctor doctor = new Doctor();
        List<Doctor> doctors = new List<Doctor>();
        public Setting()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                BinaryFormatter binaryFormatter0 = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("cookies.dat", FileMode.OpenOrCreate))
                {
                    doctor = (Doctor)binaryFormatter0.Deserialize(fileStream);
                }
            }
            catch { }
            try
            {
                BinaryFormatter binaryFormatter1 = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Лікарі.dat", FileMode.OpenOrCreate))
                {
                    doctors = (List<Doctor>)binaryFormatter1.Deserialize(fileStream);
                }
            }
            catch { }
            if (textBox1.Text == doctor.getPasswrd())
            {
                doctor.setPasswrd(textBox2.Text);
                for (int i = 0; i < doctors.Count; i++)
                {
                    if (doctors[i].getID() == doctor.getID())
                    {
                        doctors.Remove(doctors[i]);
                        break;
                    }
                }
                doctors.Add(doctor);
                MessageBox.Show("Пароль змінено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Лікарі.dat", FileMode.Create))
                    binaryFormatter.Serialize(fileStream, doctors);
            }
            else MessageBox.Show("Попередній пароль не співпадає!!!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
