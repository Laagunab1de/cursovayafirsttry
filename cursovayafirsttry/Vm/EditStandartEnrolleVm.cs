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
    public class EditEnrolleVM : BaseVm
    {
        public Enrolle EditEnrolle { get; }
        public Command SaveEnrolle { get; set; }
        public Discipline EnrolleDiscipline
        {
            get => EnrolleDiscipline;
            set
            {
                EnrolleDiscipline = value;
                Signal();
            }
        }

        public List<Discipline> Disciplines { get; set; }

        private CurrentPageControl currentPageControl;
        private Discipline enrolleDiscipline;

        public EditEnrolleVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditEnrolle = new Enrolle();
            Init();
        }

        public EditEnrolleVM(Enrolle editEnrolle, CurrentPageControl currentPageControl)
        {
            EditEnrolle = editEnrolle;
            this.currentPageControl = currentPageControl;
            Init();
            EnrolleDiscipline = Disciplines.FirstOrDefault(s => s.ID == editEnrolle.DisciplineId);
        }

        private void Init()
        {
            Disciplines = SqlModel.GetInstance().SelectDisciplinesRange(0, 100);
            SaveEnrolle = new Command(() => {
                if (EnrolleDiscipline == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать группу для продолжения");
                    return;
                }
                EditEnrolle.DisciplineId = EnrolleDiscipline.ID;
                var model = SqlModel.GetInstance();
                //if (EditEnrolle.ID == 0)
                //    model.Insert(EditEnrolle);
                //else
                //    model.Update(EditEnrolle);
                currentPageControl.SetPage(new Enrolleelist(EnrolleDiscipline));
            });
        }
    }
}
