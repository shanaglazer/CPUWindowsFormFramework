﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUWindowsFormFramework
{
    public class WindowsFormUtility
    {
        public static void SetListBinding(ComboBox lst, DataTable sourcedt, DataTable targetdt, string tablename)
        {
            lst.DataSource = sourcedt;
            lst.ValueMember = tablename + "id";
            lst.DisplayMember = lst.Name.Substring(3);
            lst.DataBindings.Add("SelectedValue", targetdt, lst.ValueMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }


        public static void SetControlBinding(Control ctrl, BindingSource bindsource)
        {
            string propertyname = "";
            string controlname = ctrl.Name.ToLower();
            string columnname = controlname.Substring(3);
            string controltype = controlname.Substring(0, 3);

            switch (controltype)
            {
                case "txt":
                case "lbl":
                    propertyname = "Text";
                    break;
                case "dtp":
                    propertyname = "Value";
                    break;
            }

            if (propertyname != "" && columnname != "")
            {
                ctrl.DataBindings.Add(propertyname, bindsource, columnname, true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public static void FormatGrid(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static bool IsFormOpen(Type formtype, int pkvalue = 0)
        {
            bool exists = false;
            foreach (Form frm in Application.OpenForms)
            {
                int frmpkvalue = 0;
                if (frm.Tag != null && frm.Tag is int) 
                {
                    frmpkvalue = (int)frm.Tag;
                }
                if (frm.GetType() == formtype && frmpkvalue == pkvalue)
                {
                    frm.Activate();
                    exists = true;
                    break;
                }
            }
            return exists;
        }

    }
}
