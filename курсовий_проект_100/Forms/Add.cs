using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовий_проект_100.Forms
{
    public partial class Add : Form
    {
        List<Hvoryi> hvoryis = new List<Hvoryi>();
        List<Hvoryi> hvoryis_D = new List<Hvoryi>();
        List<Hvoryi> curr_hvoryis = new List<Hvoryi>();
        private int ID;
        Doctor doctor = new Doctor();

        bool x = true;
        bool x1 = false;
        public Add()
        {
            InitializeComponent();
            comboBox5.SelectedIndex = 0;
            button1.Text = "Додати пацієнта";
            label1.Text = "Прізвище";
            label2.Text = "Ім'я";
            label3.Text = "По батькові";
            label4.Text = "Громадянство";
            label5.Text = "Домашня адреса";
            label6.Text = "Дата народження";
            label7.Text = "Дата госпіталізації";
            label8.Text = "Діагноз клінічний";
            label9.Text = "Діагноз при госпіталізації";
            label10.Text = "Ким направлений хворий";
            label12.Text = "Група крові";
            label11.Text = "Резус-приналежності";
            label13.Text = "Номер документа";
            label14.Text = "Докумен, що посвідчує особу";
            label15.Text = "Номер палати";
            label31.Text = "Введіть прізвище для пошуку";
            label30.Text = "Прізвище";
            label29.Text = "Ім'я";
            label28.Text = "По батькові";
            label27.Text = "Громадянство";
            label26.Text = "Домашня адреса";
            label25.Text = "Дата народження";
            label24.Text = "Дата госпіталізації";
            label23.Text = "Діагноз клінічний";
            label22.Text = "Діагноз при госпіталізації";
            label21.Text = "Ким направлений хворий";
            label20.Text = "Група крові";
            label19.Text = "Резус-приналежності";
            label18.Text = "Номер документа";
            label17.Text = "Докумен, що посвідчує особу";
            label16.Text = "Номер палати";
            label33.Text = "ID пацієнта";
            label36.Text = "ID пацієнта";
            label35.Text = "";
            textBox14.Text = "";
            label37.Text = "Введіть ID";
            groupBox1.Text = "Стать";
            groupBox2.Text = "Група крові";
            groupBox4.Text = "Пошук";
            button5.Visible = false;
            button5.Enabled = false;
            UpDat_cookies();
            UpDat();
            UpdatDD(); int maxID = 0;
            if (hvoryis.Count != 0) maxID = hvoryis[0].getID();
            int o = 0;
            for (int k = 0; k < hvoryis.Count; k++)
            {
                if (maxID < hvoryis[k].getID())
                {
                    o = k;
                }
                if (hvoryis[k].getIDdoc() == doctor.getID() && hvoryis[k].getDateV() == DateTime.MinValue)
                {
                    curr_hvoryis.Add(hvoryis[k]);
                }
            }
            if (curr_hvoryis.Count != 0) Add_DatInFormVisio(curr_hvoryis[0]);
            else MessageBox.Show("Перший запуск програми або всі пацієнти виписані");

            try
            {
                ID = hvoryis[o].getID() + 1;
            }
            catch
            {
                ID = 1;
            }

            label34.Text = ID.ToString();
            groupBox3.Text = "Група крові";
            radioButton1.Text = "Чоловік";
            radioButton2.Text = "Жінка";
            label32.Text = "Стать";
            dateTimePicker2.Value = DateTime.Now;
            comboBox5.Text = "";
            textBoxHome.Text = "";
            textBoxNam.Text = "";
            textBoxPatrn.Text = "";
            textBoxSurN.Text = "";
            richTextBox1.Text = "";
            textBox12.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            button2.Text = "Наступний";
            button3.Text = "Попередній";
            button4.Text = "Знайти";
        }
        private void Add_DatInFormVisio(Hvoryi hvoryi)
        {
            textBox10.Text = hvoryi.getSurname();
            textBox11.Text = hvoryi.getName();
            textBox9.Text = hvoryi.getPatrn();
            textBox8.Text = hvoryi.getGromad();
            textBox7.Text = hvoryi.getHomeadres();
            comboBox3.Text = hvoryi.getDoc();
            textBox5.Text = hvoryi.getNumDoc();
            dateTimePicker4.Value = hvoryi.getDateB();
            dateTimePicker3.Value = hvoryi.getDateG();
            textBox6.Text = hvoryi.getGkrow();
            comboBox4.Text = hvoryi.getRkrow();
            textBox13.Text = hvoryi.getStat();
            richTextBox5.Text = hvoryi.getDiagnozHospital();
            richTextBox6.Text = hvoryi.getDiagnozKlin();
            richTextBox4.Text = hvoryi.getKymNaprav();
            textBox4.Text = hvoryi.getNumP();
            label35.Text = hvoryi.getID().ToString();
        }
        private void Clear_Add_Page2()
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            comboBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox4.Text = "";
            textBox13.Text = "";
            richTextBox6.Text = "";
            richTextBox5.Text = "";
            richTextBox4.Text = "";
        }
        private Hvoryi createHV()
        {
            Hvoryi hvoryi = new Hvoryi();
            hvoryi.setNumP(textBox1.Text);
            hvoryi.setDateB(dateTimePicker1.Value);
            hvoryi.setDateG(dateTimePicker2.Value);
            hvoryi.setDiagnozHospital(richTextBox2.Text);
            hvoryi.setDiagnozKlin(richTextBox1.Text);
            hvoryi.setDoc(comboBox2.Text);
            hvoryi.setGkrow(textBox2.Text);
            hvoryi.setGromad(comboBox5.Text);
            hvoryi.setHomeadres(textBoxHome.Text);
            hvoryi.setKymNaprav(richTextBox3.Text);
            hvoryi.setName(textBoxNam.Text);
            hvoryi.setNumDoc(textBox3.Text);
            hvoryi.setPatrn(textBoxPatrn.Text);
            hvoryi.setRkrow(comboBox1.Text);
            if (radioButton1.Checked)
                hvoryi.setStat(radioButton1.Text);
            else hvoryi.setStat(radioButton2.Text);
            hvoryi.setSurname(textBoxSurN.Text);
            hvoryi.setNumP(textBox1.Text);
            hvoryi.setID(ID);
            hvoryi.setIDdoc(doctor.getID());

            return hvoryi;
        }
        private void ClearPage1()
        {
            comboBox5.SelectedIndex = 0;
            textBoxHome.Text = "";
            textBoxNam.Text = "";
            textBoxPatrn.Text = "";
            textBoxSurN.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void writeAll()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.OpenOrCreate))
                binaryFormatter.Serialize(fileStream, hvoryis);
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
        private void UpDat()
        {
            hvoryis.Clear();

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.OpenOrCreate))
                {

                    hvoryis = (List<Hvoryi>)binaryFormatter.Deserialize(fileStream);

                }

            }
            catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxSurN.Text == "" || textBoxNam.Text == "" || textBoxPatrn.Text == "" || textBoxHome.Text == "" || textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заповніть усі поля!!!");
            }
            else
            {
                hvoryis.Add(createHV());
                writeAll();
                curr_hvoryis.Add(createHV());
                MessageBox.Show("Пацієнт доданий");
                UpDat();
                ClearPage1();
                ID++;
                label34.Text = ID.ToString();
            }
        }
        private int curentH = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (curentH == 0)
                {
                    curentH = curr_hvoryis.Count - 1;
                    Add_DatInFormVisio(curr_hvoryis[curentH]);
                }
                else
                {
                    curentH--;
                    Add_DatInFormVisio(curr_hvoryis[curentH]);
                }
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string x1;

            bool posh = false;
            int k = 0;
            string r = "\n";
            if (textBox14.Text == "" && textBox12.Text == "") MessageBox.Show("Введіть дані для пошуку");
            else if (textBox14.Text != "" && textBox12.Text == "")
            {
                try
                {
                    int pp = Convert.ToInt32(textBox14.Text) - 1;
                    Add_DatInFormVisio(curr_hvoryis[pp]);
                    textBox12.Text = "";
                    textBox14.Text = "";
                }
                catch
                {
                    MessageBox.Show("Мабуть такого пацієнта не існує :((");
                    textBox12.Text = "";
                    textBox14.Text = "";
                }
            }
            else
            {
                try
                {
                    x1 = Convert.ToString(textBox12.Text);
                    for (int i = 0; i < curr_hvoryis.Count; i++)
                    {
                        if (curr_hvoryis[i].getSurname() == x1)
                        {
                            r += (i + 1).ToString() + "-" + curr_hvoryis[i].getSurname() + " " + curr_hvoryis[i].getName() + "\n";
                            k++;
                            posh = true;
                        }
                    }
                    if (!posh)
                    {
                        MessageBox.Show("Такого запису не знайдено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Clear_Add_Page2();
                    }
                    else
                    {
                        MessageBox.Show("Кількість записів = " + k + r, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    textBox12.Text = "";
                    textBox14.Text = "";
                }
                catch
                {
                    MessageBox.Show("Схоже виникла помилка спробуйте пізніше");
                    textBox12.Text = "";
                    textBox14.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (curentH == curr_hvoryis.Count - 1)
                {
                    curentH = 0;
                    Add_DatInFormVisio(curr_hvoryis[curentH]);
                }
                else
                {
                    curentH++;
                    Add_DatInFormVisio(curr_hvoryis[curentH]);
                }
            }
            catch { }
        }


        private void редагуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox13.Enabled = true;

            comboBox3.Enabled = true;
            comboBox4.Enabled = true;

            richTextBox4.Enabled = true;
            richTextBox5.Enabled = true;
            richTextBox6.Enabled = true;

            button5.Visible = true;
            button5.Enabled = true;

            dateTimePicker4.Enabled = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("Заповніть усі поля!!!");
            }
            else
            {
                Hvoryi hvoryi = new Hvoryi();

                hvoryi.setDateB(dateTimePicker4.Value);
                hvoryi.setDateG(dateTimePicker3.Value);
                hvoryi.setDiagnozHospital(richTextBox6.Text);
                hvoryi.setDiagnozKlin(richTextBox5.Text);
                hvoryi.setDoc(comboBox3.Text);
                hvoryi.setGkrow(textBox6.Text);
                hvoryi.setGromad(textBox8.Text);
                hvoryi.setHomeadres(textBox7.Text);
                hvoryi.setKymNaprav(richTextBox4.Text);
                hvoryi.setName(textBox11.Text);
                hvoryi.setNumDoc(textBox5.Text);
                hvoryi.setPatrn(textBox9.Text);
                hvoryi.setRkrow(comboBox4.Text);

                hvoryi.setStat(textBox13.Text);

                hvoryi.setSurname(textBox10.Text);
                hvoryi.setNumP(textBox4.Text);
                hvoryi.setID(curr_hvoryis[curentH].getID());
                hvoryi.setIDdoc(doctor.getID());


                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getID() == curr_hvoryis[curentH].getID())
                    {
                        hvoryis.Remove(hvoryis[i]);
                    }
                }
                hvoryis.Add(hvoryi);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.Create))
                    binaryFormatter.Serialize(fileStream, hvoryis);
                curr_hvoryis[curentH] = hvoryi;
                MessageBox.Show("Дані пацієнта оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox13.Enabled = false;

            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

            richTextBox4.Enabled = false;
            richTextBox5.Enabled = false;
            richTextBox6.Enabled = false;

            button5.Visible = false;
            button5.Enabled = false;

            dateTimePicker4.Enabled = false;

            button5.Visible = false;
            button5.Enabled = false;
        }

        private void виписатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                curr_hvoryis[curentH].setDateV(DateTime.Now);
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getID() == curr_hvoryis[curentH].getID())
                    {
                        hvoryis.Remove(hvoryis[i]);
                    }
                }
                hvoryis.Add(curr_hvoryis[curentH]);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.Create))
                    binaryFormatter.Serialize(fileStream, hvoryis);
                MessageBox.Show("Пацієнта виписано", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Немає пацієнта щоб виписати", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void UpdatDD()
        {

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Диспансерна_група.dat", FileMode.OpenOrCreate))
                {

                    hvoryis_D = (List<Hvoryi>)binaryFormatter.Deserialize(fileStream);

                }

            }
            catch { }
        }
        private void перевестиВДиспансернуГрупуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                curr_hvoryis[curentH].setDateV(DateTime.Now.Date);
                hvoryis_D.Add(curr_hvoryis[curentH]);
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getID() == curr_hvoryis[curentH].getID())
                    {
                        hvoryis.Remove(hvoryis[i]);
                    }
                }
                curr_hvoryis.Remove(curr_hvoryis[curentH]);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.Create))
                    binaryFormatter.Serialize(fileStream, hvoryis);

                BinaryFormatter binaryFormatter4 = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Диспансерна_група.dat", FileMode.OpenOrCreate))
                    binaryFormatter4.Serialize(fileStream, hvoryis_D);
            }
            catch { MessageBox.Show("Немає пацієнта щоб додати в диспансерну група", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[1-4]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯІіЇї']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯіІїЇ']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯіІїЇ']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxSurN_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯіІїЇ']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxNam_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯіІїЇ']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxPatrn_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯіІїЇ']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я їЇІі' , 0-9 . ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я їЇІі' , 0-9 . ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void richTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯіІїЇ .' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxHome_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯіІїЇ , 0-9 .' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[A-Z 0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[1-4]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯіІїЇ']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІїЇ , 0-9 .' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[A-Z 0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯіІїЇ']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void richTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІїЇ , 0-9 .' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void richTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я і ІїЇ , 0-9 .' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void richTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я і ІїЇ . ']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-ЯІіїЇ']").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }
    }
} 
    


