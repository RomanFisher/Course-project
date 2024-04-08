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
using Word = Microsoft.Office.Interop.Word;

namespace курсовий_проект_100.Forms
{
    public partial class Despancer : Form
    {
        List<Hvoryi> hvoryis = new List<Hvoryi>();
        Doctor doctor = new Doctor();
        public Despancer()
        {
            InitializeComponent();
            UpDat_cookies();
            textBox2.Enabled = false;
            textBox2.Visible = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Visible = false;
            UpDat();
            int kk = 0;
            for (int i = 0; i < hvoryis.Count; i++)
            {
                if (hvoryis[i].getIDdoc() == doctor.getID())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[kk].Cells[0].Value = Convert.ToString(hvoryis[i].getID());
                    dataGridView1.Rows[kk].Cells[1].Value = hvoryis[i].getSurname();
                    dataGridView1.Rows[kk].Cells[2].Value = hvoryis[i].getName();
                    dataGridView1.Rows[kk].Cells[3].Value = hvoryis[i].getPatrn();
                    dataGridView1.Rows[kk].Cells[4].Value = hvoryis[i].getDateB().ToString("dd-MM-yyyy");
                    dataGridView1.Rows[kk].Cells[5].Value = hvoryis[i].getDateG().ToString("dd-MM-yyyy");
                    dataGridView1.Rows[kk].Cells[6].Value = hvoryis[i].getHomeadres();
                    dataGridView1.Rows[kk].Cells[7].Value = hvoryis[i].getStat();
                    int k = DateTime.Now.Year - hvoryis[i].getDateB().Year;
                    dataGridView1.Rows[kk].Cells[8].Value = Convert.ToString(k);
                    dataGridView1.Rows[kk].Cells[9].Value = hvoryis[i].getGromad();

                    dataGridView1.Rows[kk].Cells[10].Value = hvoryis[i].getDoc();
                    dataGridView1.Rows[kk].Cells[11].Value = hvoryis[i].getNumDoc();
                    dataGridView1.Rows[kk].Cells[12].Value = hvoryis[i].getGkrow();
                    dataGridView1.Rows[kk].Cells[13].Value = hvoryis[i].getRkrow();
                    dataGridView1.Rows[kk].Cells[14].Value = hvoryis[i].getDiagnozKlin();
                    dataGridView1.Rows[kk].Cells[15].Value = hvoryis[i].getDiagnozHospital();
                    dataGridView1.Rows[kk].Cells[16].Value = hvoryis[i].getKymNaprav();
                    dataGridView1.Rows[kk].Cells[17].Value = hvoryis[i].getNumP();
                    if (hvoryis[i].getDateV() == DateTime.MinValue)
                    {
                        dataGridView1.Rows[kk].Cells[18].Value = "";
                        dataGridView1.Rows[kk].Cells[19].Value = "";
                    }
                    else
                    {
                        dataGridView1.Rows[kk].Cells[18].Value = hvoryis[i].getDateV().ToString("dd-MM-yyyy");
                        dataGridView1.Rows[kk].Cells[19].Value = Convert.ToString((hvoryis[i].getDateV() - hvoryis[i].getDateG()).Days);
                    }
                    kk++;
                }

            }
        }
        private readonly string TempleteFileName = "D:\\Visual Studio2019\\3 курс\\курсовий_проект_100\\bin\\Debug\\Історіяя.docx";
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
                using (FileStream fileStream = new FileStream("Диспансерна_група.dat", FileMode.OpenOrCreate))
                {

                    hvoryis = (List<Hvoryi>)binaryFormatter.Deserialize(fileStream);

                }

            }
            catch { }

        }
        private void ReplaceWordStud(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введіть ID пацієнта");
            }
            else
            {
                int k = Convert.ToInt32(textBox1.Text);
                
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
                        { MessageBox.Show("Мабуть сталася непередбачувана помилка, спробуйте пізніше", "Процес", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                         
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5)
            {
                textBox2.Enabled = true;
                textBox2.Visible = true;
                dateTimePicker1.Enabled = false;
                dateTimePicker1.Visible = false;
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Visible = false;
                dateTimePicker1.Enabled = true;
                dateTimePicker1.Visible = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string t;
            int kk;
            if (comboBox1.SelectedIndex == 0)
            {
                kk = 0;
                t = textBox2.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getIDdoc() == doctor.getID() && hvoryis[i].getSurname().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                kk = 0;
                t = textBox2.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getIDdoc() == doctor.getID() && hvoryis[i].getName().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                kk = 0;
                t = textBox2.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getIDdoc() == doctor.getID() && hvoryis[i].getHomeadres().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                kk = 0;
                t = textBox2.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getIDdoc() == doctor.getID() && hvoryis[i].getStat().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                kk = 0;
                t = textBox2.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getIDdoc() == doctor.getID() && hvoryis[i].getGromad().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                kk = 0;
                t = textBox2.Text;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getIDdoc() == doctor.getID() && hvoryis[i].getNumDoc().ToLower().Contains(t.ToLower()))
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
        }
        private void DatSetToGrid(int a, int i)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[a].Cells[0].Value = Convert.ToString(hvoryis[i].getID());
            dataGridView1.Rows[a].Cells[1].Value = hvoryis[i].getSurname();
            dataGridView1.Rows[a].Cells[2].Value = hvoryis[i].getName();
            dataGridView1.Rows[a].Cells[3].Value = hvoryis[i].getPatrn();
            dataGridView1.Rows[a].Cells[4].Value = hvoryis[i].getDateB().ToString("dd-MM-yyyy");
            dataGridView1.Rows[a].Cells[5].Value = hvoryis[i].getDateG().ToString("dd-MM-yyyy");
            dataGridView1.Rows[a].Cells[6].Value = hvoryis[i].getHomeadres();
            dataGridView1.Rows[a].Cells[7].Value = hvoryis[i].getStat();
            int k = DateTime.Now.Year - hvoryis[i].getDateB().Year;
            dataGridView1.Rows[a].Cells[8].Value = Convert.ToString(k);
            dataGridView1.Rows[a].Cells[9].Value = hvoryis[i].getGromad();

            dataGridView1.Rows[a].Cells[10].Value = hvoryis[i].getDoc();
            dataGridView1.Rows[a].Cells[11].Value = hvoryis[i].getNumDoc();
            dataGridView1.Rows[a].Cells[12].Value = hvoryis[i].getGkrow();
            dataGridView1.Rows[a].Cells[13].Value = hvoryis[i].getRkrow();
            dataGridView1.Rows[a].Cells[14].Value = hvoryis[i].getDiagnozKlin();
            dataGridView1.Rows[a].Cells[15].Value = hvoryis[i].getDiagnozHospital();
            dataGridView1.Rows[a].Cells[16].Value = hvoryis[i].getKymNaprav();
            dataGridView1.Rows[a].Cells[17].Value = hvoryis[i].getNumP();
            if (hvoryis[i].getDateV() == DateTime.MinValue)
            {
                dataGridView1.Rows[a].Cells[18].Value = "";
                dataGridView1.Rows[a].Cells[19].Value = "";
            }
            else
            {
                dataGridView1.Rows[a].Cells[18].Value = hvoryis[i].getDateV().ToString("dd-MM-yyyy");
                dataGridView1.Rows[a].Cells[19].Value = Convert.ToString((hvoryis[i].getDateV() - hvoryis[i].getDateG()).Days);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int kk;
            if (comboBox1.SelectedIndex == 6)
            {
                kk = 0;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getIDdoc() == doctor.getID() && dateTimePicker1.Value.Date == hvoryis[i].getDateG().Date)
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                kk = 0;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < hvoryis.Count; i++)
                {
                    if (hvoryis[i].getIDdoc() == doctor.getID() && dateTimePicker1.Value.Date == hvoryis[i].getDateV().Date)
                    {
                        DatSetToGrid(kk, i);
                        kk++;
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    List<Hvoryi> temp = new List<Hvoryi>();
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.OpenOrCreate))
                    {

                        temp = (List<Hvoryi>)binaryFormatter.Deserialize(fileStream);

                    }
                    int k = Convert.ToInt32(textBox1.Text);

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (k == Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value))
                        {
                            temp.Add(hvoryis[i]);
                            BinaryFormatter binaryFormatter1 = new BinaryFormatter();
                            using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.Create))
                                binaryFormatter1.Serialize(fileStream, temp);
                            hvoryis.Remove(hvoryis[i]);
                            BinaryFormatter binaryFormatter2 = new BinaryFormatter();
                            using (FileStream fileStream = new FileStream("Диспансерна_група.dat", FileMode.Create))
                                binaryFormatter2.Serialize(fileStream, hvoryis);
                        }
                    }
                    int kk = 0;
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < hvoryis.Count; i++)
                    {
                        if (hvoryis[i].getIDdoc() == doctor.getID())
                        {
                            DatSetToGrid(kk, i);
                            kk++;
                        }

                    }
                }
                catch { MessageBox.Show("Пацієнта з таким ID не існує", "Зауваження", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else MessageBox.Show("Введіть ІD пацієнта", "Зауваження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.Match(Symbol, @"[0-9]").Success) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }
    }
}
