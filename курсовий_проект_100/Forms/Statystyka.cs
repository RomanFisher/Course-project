
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
    public partial class Statystyka : Form
    {
        List<Hvoryi> hvoryis = new List<Hvoryi>();
        List<Hvoryi> hvoryis_D = new List<Hvoryi>();
        Doctor doctor = new Doctor();
        public Statystyka()
        {
            InitializeComponent();
            UpDat_cookies();
            UpDat();
            for(int i=0;i<hvoryis_D.Count;i++)
            {
                if(hvoryis_D[i].getIDdoc() == doctor.getID())
                {
                    hvoryis.Add(hvoryis_D[i]);
                }
            }
            label4.Text = "";
            comboBox1.SelectedIndex = 0;
        }
        private void UpDat()
        {
            hvoryis.Clear();
           
            List<Hvoryi> hvoryis_DD = new List<Hvoryi>();
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Хворі.dat", FileMode.OpenOrCreate))
                {

                    hvoryis_DD = (List<Hvoryi>)binaryFormatter.Deserialize(fileStream);

                }
                BinaryFormatter binaryFormatter1 = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Диспансерна_група.dat", FileMode.OpenOrCreate))
                {

                    hvoryis_D = (List<Hvoryi>)binaryFormatter1.Deserialize(fileStream);

                }
               
                for(int i = 0; i < hvoryis_DD.Count; i++)
                {
                    hvoryis_D.Add(hvoryis_DD[i]);
                }

            }
            catch { }

        }
        private void Statystyka_Load(object sender, EventArgs e)
        { 
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<int> post = new List<int>();
            List<int> vyp = new List<int>();
            int p = 0, v = 0, kkk = 0, klDay = 0;

            if (comboBox1.SelectedIndex == 0)
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
                label7.Text = Convert.ToString(p);
                label8.Text = Convert.ToString(v);
                if (kkk != 0) label4.Text = Convert.ToString(klDay / kkk);
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
                chart1.Series.Add("Нові");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[0].BorderWidth = 5;
                chart1.Series.Add("Виписали");
                chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[1].BorderWidth = 5;
                for (int i = 0; i < dateTimes.Count; i++)
                {
                   
                    chart1.Series[0].Points.AddXY(dateTimes[i],post[i]);
                    
                    chart1.Series[1].Points.AddXY(dateTimes[i],vyp[i]);
                }
               

            }
            else if (comboBox1.SelectedIndex == 1)
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
                label7.Text = Convert.ToString(p);
                label8.Text = Convert.ToString(v);
                if (kkk != 0) label4.Text = Convert.ToString(klDay / kkk);
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
            else if (comboBox1.SelectedIndex == 2)
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
                label7.Text = Convert.ToString(p);
                label8.Text = Convert.ToString(v);
                if (kkk != 0) label4.Text = Convert.ToString(klDay / kkk);
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
            else if (comboBox1.SelectedIndex == 3)
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
                label7.Text = Convert.ToString(p);
                label8.Text = Convert.ToString(v);
                if (kkk != 0) label4.Text = Convert.ToString(klDay / kkk);
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
            else if (comboBox1.SelectedIndex == 4)
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
                label7.Text = Convert.ToString(p);
                label8.Text = Convert.ToString(v);
                if (kkk != 0) label4.Text = Convert.ToString(klDay / kkk);
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

                    chart1.Series[0].Points.AddXY("Квартал " + (1 + i), post[i]);

                    chart1.Series[1].Points.AddXY("Квартал " + (1 + i), vyp[i]);
                }
            }
        }

        private void comboBox1_RightToLeftChanged(object sender, EventArgs e)
        {

        }
    }
}
