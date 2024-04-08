using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовий_проект_100.Forms
{
        [Serializable]
        public class People
        {
            private string name;
            private string surname;
            private string patrn;
            private DateTime dateB;
            private string homeadres;
            private string gromad;
            private string Gkrow;
            private string Rkrow;
            private string doc;
            private string numDoc;
            public People()
            {

            }
            public void setDateB(DateTime a)
            {
                dateB = a;
            }
            public DateTime getDateB()
            {
                return dateB;
            }
            public void setNumDoc(string a)
            {
                numDoc = a;
            }
            public string getNumDoc()
            {
                return numDoc;
            }
            public void setDoc(string a)
            {
                doc = a;
            }
            public string getDoc()
            {
                return doc;
            }
            public void setRkrow(string a)
            {
                Rkrow = a;
            }
            public string getRkrow()
            {
                return Rkrow;
            }
            public void setGkrow(string a)
            {
                Gkrow = a;
            }
            public string getGkrow()
            {
                return Gkrow;
            }
            public void setName(string a)
            {
                name = a;
            }
            public string getName()
            {
                return name;
            }
            public void setSurname(string a)
            {
                surname = a;
            }
            public string getSurname()
            {
                return surname;
            }
            public void setPatrn(string a)
            {
                patrn = a;
            }
            public string getPatrn()
            {
                return patrn;
            }
            public void setHomeadres(string a)
            {
                homeadres = a;
            }
            public string getHomeadres()
            {
                return homeadres;
            }
            public void setGromad(string a)
            {
                gromad = a;
            }
            public string getGromad()
            {
                return gromad;
            }
        }
}
