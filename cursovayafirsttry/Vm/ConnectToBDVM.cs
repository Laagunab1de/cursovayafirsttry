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
    class ConnectToBDVM
    {
        PasswordBox passwordBox;

        public string Server { get; set; }
        public string User { get; set; }
        public string BD { get; set; }

        public Command TestConnectionToBD { get; set; }
        public Command SaveConnect { get; set; }

        public ConnectToBDVM(PasswordBox passwordBox)
        {
            this.passwordBox = passwordBox;

            Server = Properties.Settings.Default.server;
            User = Properties.Settings.Default.user;
            BD = Properties.Settings.Default.db;
            passwordBox.Password = Properties.Settings.Default.pass;

            TestConnectionToBD = new Command(() => {
                var db = MySqlDB.GetDB();
                db.InitConnection(Server, User, BD, passwordBox.Password);
                if (db.OpenConnection())
                {
                    db.CloseConnection();
                    System.Windows.MessageBox.Show("Соединение успешно!");
                }
            });

            SaveConnect = new Command(() => {
                Properties.Settings.Default.user = User;
                Properties.Settings.Default.db = BD;
                Properties.Settings.Default.pass = passwordBox.Password;
                Properties.Settings.Default.server = Server;
                Properties.Settings.Default.Save();
                System.Windows.MessageBox.Show("Данные сохранены!");
            });
        }
    }
}
