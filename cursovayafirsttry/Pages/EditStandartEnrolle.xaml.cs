﻿using System;
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
using cursovayafirsttry.Tools;
using MySql.Data.MySqlClient;

namespace cursovayafirsttry.Pages
{
    /// <summary>
    /// Interaction logic for AddStandartEnrolle.xaml
    /// </summary>
    public partial class EditStandartEnrolle : Page
    {
        public EditStandartEnrolle(EditStandartEnrolleVM vm)
        {           
            InitializeComponent();
            DataContext = vm;
           
          
        }
    }
}
