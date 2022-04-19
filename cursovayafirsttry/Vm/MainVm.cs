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
using MySql.Data.MySqlClient;



namespace cursovayafirsttry.Vm
{
    class MainVm : BaseVm
    {
        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
       
        }


        public Command ViewEnrollee { get; set; }
        public MainVm()
        {
            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;
            ViewEnrollee = new Command(() => {
                currentPageControl.SetPage(new Enrolleelist(null));
            });         
        }

        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }
    }
}
