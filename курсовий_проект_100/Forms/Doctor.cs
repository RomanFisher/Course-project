using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовий_проект_100.Forms
{
    [Serializable]
    public class Doctor : People
    {
        private string kvalif;
        private int ID;
        private string posada;
        private string login;
        private string passwrd;
        private string stat;
        public Doctor()
        {

        }
        public void setStat(string a)
        {
            stat = a;
        }
        public string getStat()
        {
            return stat;
        }
        public void setPasswrd(string a)
        {
            passwrd = a;
        }
        public string getPasswrd()
        {
            return passwrd;
        }
        public void setLogin(string a)
        {
            login = a;
        }
        public string getLogin()
        {
            return login;
        }
        public void setKvalif(string a)
        {
            kvalif = a;
        }
        public string getKvalif()
        {
            return kvalif;
        }
        public void setPosada(string a)
        {
            posada = a;
        }
        public string getPosada()
        {
            return posada;
        }
        public void setID(int a)
        {
            ID = a;
        }
        public int getID()
        {
            return ID;
        }
    }
}
