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
    public class ViewDepartmentsVM : BaseVm
    {

        public List<Departments> Departments
        {
            get => Departments;
            set
            {
                Departments = value;
                Signal();
            }
        }
        public Enrolle SelectedEnrolle { get; set; }

        public ViewDepartmentsVM(Departments selectedDepartment)
        {
            //SqlModel sqlModel = SqlModel.GetInstance();
            //Departments = sqlModel.SelectDisciplinesRange(0, 100);

        }
    }
}

