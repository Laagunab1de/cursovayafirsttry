﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace cursovayafirsttry.Vm
{
    public class BaseVm: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Signal([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
