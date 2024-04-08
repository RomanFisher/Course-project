using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using курсовий_проект_100.Forms;
namespace курсовий_проект_100
{
    public partial class Main : Form
    {
        private Form activeForm;
       
        public Main()
        {
            InitializeComponent();
            button1.Text = "Головна";
            button2.Text = "Пацієнти";
            button3.Text = "Диспансерна" + "\n" + " група";
            button4.Text = "Історія";
            button5.Text = "Статистика";
            button6.Text = "Налаштування";
            this.Text = "Електронний облік хворих на Covid-19";
            label1.Text = "Державна прикордонна служба України";
            button1.BackColor = Color.FromArgb(0, 100, 0);
            button2.BackColor = Color.FromArgb(34, 139, 34);
            button3.BackColor = Color.FromArgb(34, 139, 34);
            button4.BackColor = Color.FromArgb(34, 139, 34);
            button5.BackColor = Color.FromArgb(34, 139, 34);
            button6.BackColor = Color.FromArgb(34, 139, 34);
            OpenChildForm(new Forms.Home());

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(childForm);
            this.panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 100, 0);
            button2.BackColor = Color.FromArgb(34, 139, 34);
            button3.BackColor = Color.FromArgb(34, 139, 34);
            button4.BackColor = Color.FromArgb(34, 139, 34);
            button5.BackColor = Color.FromArgb(34, 139, 34);
            button6.BackColor = Color.FromArgb(34, 139, 34);
            OpenChildForm(new Forms.Home());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(34, 139, 34);
            button2.BackColor = Color.FromArgb(0, 100, 0);
            button3.BackColor = Color.FromArgb(34, 139, 34);
            button4.BackColor = Color.FromArgb(34, 139, 34);
            button5.BackColor = Color.FromArgb(34, 139, 34);
            button6.BackColor = Color.FromArgb(34, 139, 34);
            OpenChildForm(new Forms.Add());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(34, 139, 34);
            button2.BackColor = Color.FromArgb(34, 139, 34);
            button3.BackColor = Color.FromArgb(0, 100, 0);
            button4.BackColor = Color.FromArgb(34, 139, 34);
            button5.BackColor = Color.FromArgb(34, 139, 34);
            button6.BackColor = Color.FromArgb(34, 139, 34);
            OpenChildForm(new Forms.Despancer());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(34, 139, 34);
            button2.BackColor = Color.FromArgb(34, 139, 34);
            button3.BackColor = Color.FromArgb(34, 139, 34);
            button4.BackColor = Color.FromArgb(0, 100, 0);
            button5.BackColor = Color.FromArgb(34, 139, 34);
            button6.BackColor = Color.FromArgb(34, 139, 34);
            OpenChildForm(new Forms.History());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(34, 139, 34);
            button2.BackColor = Color.FromArgb(34, 139, 34);
            button3.BackColor = Color.FromArgb(34, 139, 34);
            button4.BackColor = Color.FromArgb(34, 139, 34);
            button5.BackColor = Color.FromArgb(0, 100, 0);
            button6.BackColor = Color.FromArgb(34, 139, 34);
            OpenChildForm(new Forms.Statystyka());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(34, 139, 34);
            button2.BackColor = Color.FromArgb(34, 139, 34);
            button3.BackColor = Color.FromArgb(34, 139, 34);
            button4.BackColor = Color.FromArgb(34, 139, 34);
            button5.BackColor = Color.FromArgb(34, 139, 34);
            button6.BackColor = Color.FromArgb(0, 100, 0);
            OpenChildForm(new Forms.Setting());
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
