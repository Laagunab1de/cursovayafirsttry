﻿using System;

namespace cursovayafirsttry.Tools
{
    internal class TableAttribute : Attribute
    {
        public string Table { get; }
        public TableAttribute(string table)
        {
            Table = table;
        }
    }
}