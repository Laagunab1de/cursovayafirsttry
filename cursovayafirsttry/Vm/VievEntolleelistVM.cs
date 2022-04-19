using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using cursovayafirsttry.DTO;
using cursovayafirsttry.Vm;
using cursovayafirsttry.Pages;
using cursovayafirsttry.model;
using MySql.Data.MySqlClient;

namespace cursovayafirsttry.Vm
{
    class VievEnrollelistVM : BaseVm    
    {
        private Discipline selectedDiscipline;
        private List<Enrolle> enrolleBySelectedDiscipline;

        public List<Discipline> Disciplines { get; set; }
        public Discipline SelectedDiscipline
        {
            get => selectedDiscipline;
            set
            {
                selectedDiscipline = value;
                EnrollesBySelectedDiscipline = SqlModel.GetInstance().SelectEnrollesByDiscipline(selectedDiscipline);
                Signal();
            }
        }
        public List<Enrolle> EnrollesBySelectedDiscipline
        {
            get => enrolleBySelectedDiscipline;
            set
            {
                enrolleBySelectedDiscipline = value;
                Signal();
            }
        }
        public Enrolle SelectedEnrolle { get; set; }

        public VievEnrollelistVM(Discipline selectedDiscipline)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Disciplines = sqlModel.SelectDisciplinesRange(0, 100);
            
        }
    }
}
