using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDataBindingDemo3_labra_12.Model;

namespace WPFDataBindingDemo3_labra_12.ViewModel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }
        public void LoadStudents ()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            // lisätään esimerkin vuoksi muutama opiskelija, oikeassa sovelluksessa haettaisiin esim tietokannasta.
            students.Add(new Student { FirstName = "Kalle", LastName = "Jalkanen" , AsioID="A3434"});
            students.Add(new Student { FirstName = "Teppo", LastName = "Testaaja", AsioID = "J3332" });
            students.Add(new Student { FirstName = "Tomi", LastName = "Töttenström", AsioID = "S1234" });

            Students = students;
        }
    }
}
