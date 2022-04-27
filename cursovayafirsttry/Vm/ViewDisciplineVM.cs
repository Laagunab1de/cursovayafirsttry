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
    class ViewDisciplineVM : BaseVm
    {
        public List<Discipline> disciplines;
        private int viewRowsCount;
        public List<Discipline> Disciplines
        {
            get => Disciplines;
            set
            {
                Disciplines = value;
                Signal();
            }
        }
        public int ViewRowsCount
        {
            get => viewRowsCount;
            set
            {
                viewRowsCount = value;
                InitPages();
                Signal();
            }
        }

        public ViewDisciplineVM()
        {
           
            ViewRowsCount = 50;

            InitPages();
        }

        private void InitPages()
        {
            var sqlModel = SqlModel.GetInstance();
           // int pageCount = (sqlModel.GetNumRows(typeof(Group)) / ViewRowsCount) + 1;
           // PageIndexes = new List<int>(Enumerable.Range(1, pageCount));
         //   SelectedIndex = 1;
        }
    }
}
