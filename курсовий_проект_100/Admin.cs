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
using курсовий_проект_100.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace курсовий_проект_100
{
    public partial class Admin : Form
    {
        private int ID;
        List<Doctor> doctors = new List<Doctor>();
        List<Hvoryi> hvoryis = new List<Hvoryi>();
        private int curentH = 0;
        public Admin()
        {
            this.Text = "Сторінка адміністратора (завідувача відділенням)";
            InitializeComponent();
            ClearPage1();
            UpDat();
            UpDatHV();
            comboBox1.SelectedIndex = 0;
            textBox3.Enabled = false;
            textBox3.Visible = false;
            dateTimePicker3.Enabled = false;
            dateTimePicker3.Visible = false;
            label41.Text = "";
            comboBox7.SelectedIndex = 0;
            textBox16.Text = "";
            int o = doctors.Count - 1;
            UpDat();
            for (int i = 0, k = 0; i < hvoryis.Count; i++, k++)
            {
                    DatSetToGrid(k,i);
            }
            try
            {
                Add_DatInFormVisio(doctors[o]);
                ID = doctors[o].getID() + 1;
            }
            catch
            {
                MessageBox.Show("Лікарі ще не додані, перший запуск програми");
                ID = 1;
            }
            label10.Text = Convert.ToString(ID);

        }
        private void UpDatHV()
        {
            hvoryis.Clear();
            List<Hvoryi> hvoryis_D = new List<Hvoryi>();
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.OpenOrCreate))
                {

                    hvoryis = (List<Hvoryi>)binaryFormatter.Deserialize(fileStream);

                }
                BinaryFormatter binaryFormatter1 = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Диспансерна_група.dat", FileMode.OpenOrCreate))
                {

                    hvoryis_D = (List<Hvoryi>)binaryFormatter1.Deserialize(fileStream);

                }

                for (int i = 0; i < hvoryis_D.Count; i++)
                {
                    hvoryis.Add(hvoryis_D[i]);
                }
                hvoryis_D.Clear();
            }
            catch { }

        }
        private void Add_DatInFormVisio(Doctor doc)
        {
            textBox10.Text = doc.getSurname();
            textBox11.Text = doc.getName();
            textBox9.Text = doc.getPatrn();
            textBox12.Text = doc.getGromad();
            textBox8.Text = doc.getHomeadres();
            comboBox6.Text = doc.getDoc();
            textBox7.Text = doc.getNumDoc();
            dateTimePicker2.Value = doc.getDateB();
           
            textBox6.Text = doc.getGkrow();
            comboBox3.Text = doc.getRkrow();
            textBox13.Text = doc.getStat();
            textBox5.Text = doc.getKvalif();
            textBox4.Text = doc.getPosada();

            label19.Text = doc.getID().ToString();
        }
        private void DatSetToGrid(int k, int i)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[k].Cells[0].Value = Convert.ToString(hvoryis[i].getID());
            dataGridView1.Rows[k].Cells[1].Value = hvoryis[i].getSurname();
            dataGridView1.Rows[k].Cells[2].Value = hvoryis[i].getName();
            dataGridView1.Rows[k].Cells[3].Value = hvoryis[i].getPatrn();
            dataGridView1.Rows[k].Cells[4].Value = hvoryis[i].getDateB().ToString("dd-MM-yyyy");
            dataGridView1.Rows[k].Cells[5].Value = hvoryis[i].getDateG().ToString("dd-MM-yyyy");
            dataGridView1.Rows[k].Cells[6].Value = hvoryis[i].getHomeadres();
            dataGridView1.Rows[k].Cells[7].Value = hvoryis[i].getStat();
            int kk = DateTime.Now.Year - hvoryis[i].getDateB().Year;
            dataGridView1.Rows[k].Cells[8].Value = Convert.ToString(kk);
            dataGridView1.Rows[k].Cells[9].Value = hvoryis[i].getGromad();

            dataGridView1.Rows[k].Cells[10].Value = hvoryis[i].getDoc();
            dataGridView1.Rows[k].Cells[11].Value = hvoryis[i].getNumDoc();
            dataGridView1.Rows[k].Cells[12].Value = hvoryis[i].getGkrow();
            dataGridView1.Rows[k].Cells[13].Value = hvoryis[i].getRkrow();
            dataGridView1.Rows[k].Cells[14].Value = hvoryis[i].getDiagnozKlin();
            dataGridView1.Rows[k].Cells[15].Value = hvoryis[i].getDiagnozHospital();
            dataGridView1.Rows[k].Cells[16].Value = hvoryis[i].getKymNaprav();
            dataGridView1.Rows[k].Cells[17].Value = hvoryis[i].getNumP();
            if (hvoryis[k].getDateV() == DateTime.MinValue)
            {
                dataGridView1.Rows[k].Cells[18].Value = "";
                dataGridView1.Rows[k].Cells[19].Value = "";
            }
            else
            {
                dataGridView1.Rows[k].Cells[18].Value = hvoryis[i].getDateV().ToString("dd-MM-yyyy");
                dataGridView1.Rows[k].Cells[19].Value = Convert.ToString((hvoryis[i].getDateV() - hvoryis[i].getDateG()).Days);
            }
        }
        private void UpDat()
        {
            doctors.Clear();
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Лікарі.dat", FileMode.OpenOrCreate))
                {

                    doctors = (List<Doctor>)binaryFormatter.Deserialize(fileStream);

                }

            }
            catch { }

        }
        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxLog.Text == "" || textBoxPosada.Text == "" || textBoxPass.Text == "" || textBoxSurN.Text == "" || textBoxNam.Text == "" || textBoxPatrn.Text == "" || textBoxHome.Text == "" || textBoxNumDoc.Text == "" || textBoxKval.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заповніть усі поля!!!");
            }
            else
            {
                for(int l = 0; l<doctors.Count;l++)
                {
                    if(doctors[l].getLogin() == textBoxLog.Text)
                    {
                        MessageBox.Show("Такий логін уже існує");
                        break;
                    }
                }
                doctors.Add(createDoc());
                writeAll();
                MessageBox.Show("Лікар доданий");
                UpDat();
                ClearPage1();
                ID++;
                label10.Text = ID.ToString();
            }
        }
        private void ClearPage1()
        {
            textBox2.Text = "";
            textBoxHome.Text = "";
            textBoxKval.Text = "";
            textBoxLog.Text = "";
            textBoxNam.Text = "";
            textBoxNumDoc.Text = "";
            textBoxPass.Text = "";
            textBoxPatrn.Text = "";
            textBoxPosada.Text = "";
            textBoxSurN.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            radioButton1.Checked = true;
        }
        private void writeAll()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("Лікарі.dat", FileMode.OpenOrCreate))
                binaryFormatter.Serialize(fileStream, doctors);
        }
        private Doctor createDoc()
        {
            Doctor doctor = new Doctor();
            doctor.setDateB(dateTimePicker1.Value);
            doctor.setDoc(comboBox2.Text);
            doctor.setGkrow(textBox2.Text);
            doctor.setGromad(comboBox5.Text);
            doctor.setHomeadres(textBoxHome.Text);
            doctor.setID(Convert.ToInt32(label10.Text));
            doctor.setKvalif(textBoxKval.Text);
            doctor.setLogin(textBoxLog.Text);
            doctor.setName(textBoxNam.Text);
            doctor.setNumDoc(textBoxNumDoc.Text);
            doctor.setPasswrd(textBoxPass.Text);
            doctor.setPatrn(textBoxPatrn.Text);
            doctor.setPosada(textBoxPosada.Text);
            doctor.setRkrow(comboBox1.Text);
            if (radioButton1.Checked)
                doctor.setStat(radioButton1.Text);
            else doctor.setStat(radioButton2.Text);
            doctor.setSurname(textBoxSurN.Text);
            return doctor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (curentH == doctors.Count - 1)
                {
                    curentH = 0;
                    Add_DatInFormVisio(doctors[curentH]);
                }
                else
                {
                    curentH++;
                    Add_DatInFormVisio(doctors[curentH]);
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (curentH == 0)
                {
                    curentH = doctors.Count - 1;
                    Add_DatInFormVisio(doctors[curentH]);
                }
                else
                {
                    curentH--;
                    Add_DatInFormVisio(doctors[curentH]);
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
            if (textBox14.Text == "" && textBox1.Text == "") MessageBox.Show("Введіть дані для пошуку");
            else if (textBox14.Text != "" && textBox1.Text == "")
            {
                try
                {
                    int pp = Convert.ToInt32(textBox14.Text) - 1;
                    Add_DatInFormVisio(doctors[pp]);
                    textBox1.Text = "";
                    textBox14.Text = "";
                }
                catch
                {
                    MessageBox.Show("Мабуть такого пацієнта не існує :((");
                    textBox1.Text = "";
                    textBox14.Text = "";
                }
            }
            else
            {
                try
                {
                    x1 = Convert.ToString(textBox1.Text);
                    for (int i = 0; i < doctors.Count; i++)
                    {
                        if (doctors[i].getSurname() == x1)
                        {
                            r += (i + 1).ToString() + "-" + doctors[i].getSurname() + " " + doctors[i].getName() + "\n";
                            k++;
                            posh = true;
                        }
                    }
                    if (!posh)
                    {
                        MessageBox.Show("Такого запису не знайдено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Кількість записів = " + k + r, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    textBox1.Text = "";
                    textBox14.Text = "";
                }
                catch
                {
                    MessageBox.Show("Схоже виникла помилка спробуйте пізніше");
                    textBox1.Text = "";
                    textBox14.Text = "";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (doctors.Count == 0) MessageBox.Show("Лікарі ще не додані","Попередження",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else if (MessageBox.Show("Ви справді бажаєте видалити лікаря цього лікаря?", "Видалення",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                doctors.Remove(doctors[curentH]);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Лікарі.dat", FileMode.Create))
                    binaryFormatter.Serialize(fileStream, doctors);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0 || comboBox4.SelectedIndex == 1 || comboBox4.SelectedIndex == 2 || comboBox4.SelectedIndex == 3 || comboBox4.SelectedIndex == 4 || comboBox4.SelectedIndex == 5)
            {
                textBox3.Enabled = true;
                textBox3.Visible = true;
                dateTimePicker3.Enabled = false;
                dateTimePicker3.Visible = false;
            }
            else
            {
                textBox3.Enabled = false;
                textBox3.Visible = false;
                dateTimePicker3.Enabled = true;
                dateTimePicker3.Visible = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string t;
            int kk;
            if (comboBox4.SelectedIndex == 0)
            {
                kk = 0;
                t = textBox3.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getSurname().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk,i);
                        kk++;
                    }

                }
            }

            else if (comboBox4.SelectedIndex == 1)
            {
                kk = 0;
                t = textBox3.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getName().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                kk = 0;
                t = textBox3.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getHomeadres().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox4.SelectedIndex == 3)
            {
                kk = 0;
                t = textBox3.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getStat().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox4.SelectedIndex == 4)
            {
                kk = 0;
                t = textBox3.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getGromad().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox4.SelectedIndex == 5)
            {
                kk = 0;
                t = textBox3.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getNumDoc().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            int kk;
            if (comboBox4.SelectedIndex == 6)
            {
                kk = 0;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (dateTimePicker3.Value.Date == hvoryis[i].getDateG().Date)
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox4.SelectedIndex == 7)
            {
                kk = 0;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (dateTimePicker3.Value.Date == hvoryis[i].getDateV().Date)
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
        }
        private readonly string TempleteFileName = "D:\\Visual Studio2019\\3 курс\\курсовий_проект_100\\bin\\Debug\\Історіяя.docx";
        private void ReplaceWordStud(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                MessageBox.Show("Введіть ID пацієнта");
            }
            else
            {
                int k = Convert.ToInt32(textBox15.Text);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (k == Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value))
                    {
                        MessageBox.Show("Зачекайте відриття Word, ваш запит на виконанні", "Процес", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var wordApp = new Word.Application();
                        wordApp.Visible = false;
                        var wordDocument = wordApp.Documents.Open(TempleteFileName);
                        try
                        {
                            ReplaceWordStud("{ID}", Convert.ToString(dataGridView1.Rows[i].Cells[0].Value), wordDocument);
                            ReplaceWordStud("{DateB}", Convert.ToString(dataGridView1.Rows[i].Cells[4].Value), wordDocument);
                            ReplaceWordStud("{DateG}", Convert.ToString(dataGridView1.Rows[i].Cells[5].Value), wordDocument);
                            ReplaceWordStud("{Stat}", Convert.ToString(dataGridView1.Rows[i].Cells[7].Value), wordDocument);
                            ReplaceWordStud("{OldYear}", Convert.ToString(dataGridView1.Rows[i].Cells[8].Value), wordDocument);
                            ReplaceWordStud("{Home}", Convert.ToString(dataGridView1.Rows[i].Cells[6].Value), wordDocument);
                            ReplaceWordStud("{Gromadyanstvo}", Convert.ToString(dataGridView1.Rows[i].Cells[9].Value), wordDocument);
                            ReplaceWordStud("{SurnameP}", Convert.ToString(dataGridView1.Rows[i].Cells[1].Value), wordDocument);
                            ReplaceWordStud("{NameP}", Convert.ToString(dataGridView1.Rows[i].Cells[2].Value), wordDocument);
                            ReplaceWordStud("{Patron}", Convert.ToString(dataGridView1.Rows[i].Cells[3].Value), wordDocument);

                            ReplaceWordStud("{TypeDoc}", Convert.ToString(dataGridView1.Rows[i].Cells[10].Value), wordDocument);
                            ReplaceWordStud("{NumDoc}", Convert.ToString(dataGridView1.Rows[i].Cells[11].Value), wordDocument);
                            ReplaceWordStud("{KymNaprav}", Convert.ToString(dataGridView1.Rows[i].Cells[16].Value), wordDocument);
                            ReplaceWordStud("{Dgoz}", Convert.ToString(dataGridView1.Rows[i].Cells[15].Value), wordDocument);
                            ReplaceWordStud("{Dklin}", Convert.ToString(dataGridView1.Rows[i].Cells[14].Value), wordDocument);
                            ReplaceWordStud("{Gk}", Convert.ToString(dataGridView1.Rows[i].Cells[12].Value), wordDocument);
                            ReplaceWordStud("{Rk}", Convert.ToString(dataGridView1.Rows[i].Cells[13].Value), wordDocument);
                            ReplaceWordStud("{Dv}", Convert.ToString(dataGridView1.Rows[i].Cells[18].Value), wordDocument);
                            ReplaceWordStud("{KlDay}", Convert.ToString(dataGridView1.Rows[i].Cells[19].Value), wordDocument);

                            wordDocument.SaveAs2(@"D:\result.docx");
                            wordApp.Visible = true;

                            break;
                        }
                        catch
                        {
                            MessageBox.Show("Виникла помилка!");
                        }

                    }
                }
            }
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool posh = false;
            int k = 0;
            string r = "\n";
            if (textBox16.Text == "") MessageBox.Show("Введіть дані для пошуку");
            else
            {
                try
                {
                    for (int i = 0; i < doctors.Count; i++)
                    {
                        if (doctors[i].getSurname().ToLower().Contains(textBox16.Text.ToLower()))
                        {
                            r += (i + 1).ToString() + "-" + doctors[i].getSurname() + " " + doctors[i].getName() + "\n";
                            k++;
                            posh = true;
                        }
                    }
                    if (!posh)
                    {
                        MessageBox.Show("Такого лікаря не знайдено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Кількість лікарів що підходять = " + k + r, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch
                {
                    MessageBox.Show("Схоже виникла помилка спробуйте пізніше");
                }
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox17.Text), kk=0;
            dataGridView1.Rows.Clear();
            for(int i =0;i<hvoryis.Count;i++)
            {
                if(hvoryis[i].getIDdoc() == x)
                {
                    DatSetToGrid(kk, i);
                    kk++;
                }
            }
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("Схоже що в цього лікаря ще ніхто не лікується", "Зауваження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                for (int i = 0; i < hvoryis.Count; i++, kk++)
                {
                        DatSetToGrid(kk, i);
                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> post = new List<int>();
            List<int> vyp = new List<int>();
            int p = 0, v = 0, kkk = 0, klDay = 0;

            if (comboBox7.SelectedIndex == 0)
            {
                chart1.Series.Clear();
                post.Clear();
                vyp.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 7) v++;
                    if ((DateTime.Now - hvoryis[i].getDateG()).Days < 7) p++;
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 7 && (DateTime.Now - hvoryis[i].getDateV()).Days < 7)
                    {
                        kkk++;
                        klDay += ((hvoryis[i].getDateV() - hvoryis[i].getDateG()).Days);
                    }
                }
                label39.Text = Convert.ToString(p);
                label38.Text = Convert.ToString(v);
                if(kkk!=0) label42.Text = Convert.ToString(klDay / kkk);
                List<DateTime> dateTimes = new List<DateTime>();
                for (int i = -5; i <= 0; i++)
                {
                    dateTimes.Add(Convert.ToDateTime(DateTime.Now.AddDays(i)));
                }
                for (int i = 0; i < dateTimes.Count; i++)
                {
                    v = 0;
                    p = 0;
                    for (int j = 0; j < hvoryis.Count; j++)
                    {
                        if (dateTimes[i].Date == hvoryis[j].getDateG().Date) p++;
                        if (dateTimes[i].Date == hvoryis[j].getDateV().Date) v++;
                    }
                    post.Add(p);
                    vyp.Add(v);
                }
                post.Reverse();
                vyp.Reverse();
                chart1.Series.Add("Нові");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[0].BorderWidth = 5;
                chart1.Series.Add("Виписали");
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[1].BorderWidth = 5;
                for (int i = 0; i < dateTimes.Count; i++)
                {

                    chart1.Series[0].Points.AddXY(dateTimes[i], post[i]);

                    chart1.Series[1].Points.AddXY(dateTimes[i], vyp[i]);
                }


            }
            else if (comboBox7.SelectedIndex == 1)
            {
                chart1.Series.Clear();
                post.Clear();
                vyp.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 31) v++;
                    if ((DateTime.Now - hvoryis[i].getDateG()).Days < 31) p++;
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 31 && (DateTime.Now - hvoryis[i].getDateV()).Days < 31)
                    {
                        kkk++;
                        klDay += ((hvoryis[i].getDateV() - hvoryis[i].getDateG()).Days);
                    }
                }
                label39.Text = Convert.ToString(p);
                label38.Text = Convert.ToString(v);
                if (kkk != 0) label42.Text = Convert.ToString(klDay / kkk);
                List<DateTime> dateTimes = new List<DateTime>();
                for (int i = -33; i <= 0; i++)
                {
                    dateTimes.Add(Convert.ToDateTime(DateTime.Now.AddDays(i)));
                }
                for (int i = 0; i < dateTimes.Count; i++)
                {
                    for (int j = 0; j < hvoryis.Count; j++)
                    {
                        if (dateTimes[i].Date == hvoryis[j].getDateG().Date) p++;
                        if (dateTimes[i].Date == hvoryis[j].getDateV().Date) v++;
                    }
                    if (i % 7 == 0)
                    {
                        post.Add(p);
                        vyp.Add(v);
                        v = 0;
                        p = 0;
                    }

                }
                post.Reverse();
                vyp.Reverse();
                chart1.Series.Add("Нові");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[0].BorderWidth = 5;
                chart1.Series.Add("Виписали");
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[1].BorderWidth = 5;
                for (int i = 0; i < 4; i++)
                {

                    chart1.Series[0].Points.AddXY("Тиждень" + (i + 1), post[i]);

                    chart1.Series[1].Points.AddXY("Тиждень" + (i + 1), vyp[i]);
                }
            }
            else if (comboBox7.SelectedIndex == 2)
            {
                chart1.Series.Clear();
                post.Clear();
                vyp.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 92) v++;
                    if ((DateTime.Now - hvoryis[i].getDateG()).Days < 92) p++;
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 92 && (DateTime.Now - hvoryis[i].getDateV()).Days < 92)
                    {
                        kkk++;
                        klDay += ((hvoryis[i].getDateV() - hvoryis[i].getDateG()).Days);
                    }
                }
                label39.Text = Convert.ToString(p);
                label38.Text = Convert.ToString(v);
                if (kkk != 0) label42.Text = Convert.ToString(klDay / kkk);
                List<DateTime> dateTimes = new List<DateTime>();
                for (int i = -92; i <= 0; i++)
                {
                    dateTimes.Add(Convert.ToDateTime(DateTime.Now.AddDays(i)));
                }
                for (int i = 0; i < dateTimes.Count; i++)
                {
                    for (int j = 0; j < hvoryis.Count; j++)
                    {
                        if (dateTimes[i].Date == hvoryis[j].getDateG().Date) p++;
                        if (dateTimes[i].Date == hvoryis[j].getDateV().Date) v++;
                    }
                    if (i % 31 == 0)
                    {
                        post.Add(p);
                        vyp.Add(v);
                        v = 0;
                        p = 0;
                    }

                }
                post.Reverse();
                vyp.Reverse();
                chart1.Series.Add("Нові");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[0].BorderWidth = 5;
                chart1.Series.Add("Виписали");
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[1].BorderWidth = 5;
                for (int i = 0; i < 3; i++)
                {

                    chart1.Series[0].Points.AddXY("Місяць " + (i + 1), post[i]);

                    chart1.Series[1].Points.AddXY("Місяць " + (i + 1), vyp[i]);
                }
            }
            else if (comboBox7.SelectedIndex == 3)
            {
                chart1.Series.Clear();
                post.Clear();
                vyp.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 182) v++;
                    if ((DateTime.Now - hvoryis[i].getDateG()).Days < 182) p++;
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 182 && (DateTime.Now - hvoryis[i].getDateV()).Days < 182)
                    {
                        kkk++;
                        klDay += ((hvoryis[i].getDateV() - hvoryis[i].getDateG()).Days);
                    }
                }
                label39.Text = Convert.ToString(p);
                label38.Text = Convert.ToString(v);
                if (kkk != 0) label42.Text = Convert.ToString(klDay / kkk);
                List<DateTime> dateTimes = new List<DateTime>();
                for (int i = -182; i <= 0; i++)
                {
                    dateTimes.Add(Convert.ToDateTime(DateTime.Now.AddDays(i)));
                }
                for (int i = 0; i < dateTimes.Count; i++)
                {
                    for (int j = 0; j < hvoryis.Count; j++)
                    {
                        if (dateTimes[i].Date == hvoryis[j].getDateG().Date) p++;
                        if (dateTimes[i].Date == hvoryis[j].getDateV().Date) v++;
                    }
                    if (i % 31 == 0)
                    {
                        post.Add(p);
                        vyp.Add(v);
                        v = 0;
                        p = 0;
                    }

                }
                post.Reverse();
                vyp.Reverse();
                chart1.Series.Add("Нові");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[0].BorderWidth = 5;
                chart1.Series.Add("Виписали");
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[1].BorderWidth = 5;
                for (int i = 0; i < 6; i++)
                {

                    chart1.Series[0].Points.AddXY("Місяць " + (i + 1), post[i]);

                    chart1.Series[1].Points.AddXY("Місяць " + (i + 1), vyp[i]);
                }
            }
            else if (comboBox7.SelectedIndex == 4)
            {
                chart1.Series.Clear();
                post.Clear();
                vyp.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 365) v++;
                    if ((DateTime.Now - hvoryis[i].getDateG()).Days < 365) p++;
                    if ((DateTime.Now - hvoryis[i].getDateV()).Days < 365 && (DateTime.Now - hvoryis[i].getDateV()).Days < 365)
                    {
                        kkk++;
                        klDay += ((hvoryis[i].getDateV() - hvoryis[i].getDateG()).Days);
                    }
                }
                label39.Text = Convert.ToString(p);
                label38.Text = Convert.ToString(v);
                if (kkk != 0) label42.Text = Convert.ToString(klDay / kkk);
                List<DateTime> dateTimes = new List<DateTime>();
                for (int i = -365; i <= 0; i++)
                {
                    dateTimes.Add(Convert.ToDateTime(DateTime.Now.AddDays(i)));
                }
                for (int i = 0; i < dateTimes.Count; i++)
                {
                    for (int j = 0; j < hvoryis.Count; j++)
                    {
                        if (dateTimes[i].Date == hvoryis[j].getDateG().Date) p++;
                        if (dateTimes[i].Date == hvoryis[j].getDateV().Date) v++;
                    }
                    if (i % 92 == 0)
                    {
                        post.Add(p);
                        vyp.Add(v);
                        v = 0;
                        p = 0;
                    }

                }
                post.Reverse();
                vyp.Reverse();
                chart1.Series.Add("Нові");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[0].BorderWidth = 5;
                chart1.Series.Add("Виписали");
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[1].BorderWidth = 5;
                for (int i = 0; i < 4; i++)
                {

                    chart1.Series[0].Points.AddXY("Квартал " + (4 - i), post[i]);

                    chart1.Series[1].Points.AddXY("Квартал " + (4 - i), vyp[i]);
                }
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Ви справді бажаєте НЕЗВОРОТНЬО видалити базу з пацієнтами???","КРАЙНЄ ЗАПИТАННЯ",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                hvoryis.Clear();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.Create))
                    binaryFormatter.Serialize(fileStream, hvoryis);
                BinaryFormatter binaryFormatter1 = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Диспансерна_група.dat", FileMode.Create))
                    binaryFormatter1.Serialize(fileStream, hvoryis);
                dataGridView1.Rows.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxSurN_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxPatrn_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxHome_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' , 0-9 . ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxKval_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' 0-9 ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxPosada_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[+-]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[а-яА-Я іІ їЇ ' ]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void textBoxNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[A-Z 0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }
    }
}
