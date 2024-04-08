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

namespace курсовий_проект_100.Forms
{
    public partial class Home : Form
    {
        Doctor doctor = new Doctor();
        public Home()
        {
            InitializeComponent();
            UpDat_cookies();
            label2.Text = doctor.getSurname() + " " + doctor.getName();
        }
        private void UpDat_cookies()
        {

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("cookies.dat", FileMode.OpenOrCreate))
                {

                    doctor = (Doctor)binaryFormatter.Deserialize(fileStream);

                }

            }
            catch { MessageBox.Show("Не вдалося підгрузити поточного лікаря!!!"); }

        }
    }
}
