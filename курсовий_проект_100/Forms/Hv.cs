using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовий_проект_100.Forms
{
    [Serializable]
    public class Hvoryi : People
    {
        private int ID;
        private DateTime dateG;
        private DateTime dateVypusky;
        private string stat;
        private string diagnozKlin;
        private string diagnozHospital;
        private string kymNaprav;
        private string NumP;
        private int ID_doc;
        public Hvoryi()
        {

        }
        public void setDateV(DateTime a)
        {
            dateVypusky = a;
        }
        public DateTime getDateV()
        {
            return dateVypusky;
        }
        public void setIDdoc(int a)
        {
            ID_doc = a;
        }
        public int getIDdoc()
        {
            return ID_doc;
        }
        public void setID(int a)
        {
            ID = a;
        }
        public int getID()
        {
            return ID;
        }
        public void setDateG(DateTime a)
        {
            dateG = a;
        }
        public DateTime getDateG()
        {
            return dateG;
        }
        public void setNumP(string a)
        {
            NumP = a;
        }
        public string getNumP()
        {
            return NumP;
        }
        public void setStat(string a)
        {
            stat = a;
        }
        public string getStat()
        {
            return stat;
        }
        public void setDiagnozKlin(string a)
        {
            diagnozKlin = a;
        }
        public string getDiagnozKlin()
        {
            return diagnozKlin;
        }
        public void setDiagnozHospital(string a)
        {
            diagnozHospital = a;
        }
        public string getDiagnozHospital()
        {
            return diagnozHospital;
        }
        public void setKymNaprav(string a)
        {
            kymNaprav = a;
        }
        public string getKymNaprav()
        {
            return kymNaprav;
        }
    }
}
