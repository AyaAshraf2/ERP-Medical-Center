using System;
using System.Collections.Generic;
using System.Data;

namespace ERPMedicalCenter.Models.ViewModel
{
    public class DropDownList
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public List<DropDownList> downLists(DataTable data, string ValueColumn, string TextColumn)
        {
            List<DropDownList> result = new List<DropDownList>();
            DropDownList list = new DropDownList();
            foreach (DataRow item in data.Rows)
            {
                list = new DropDownList();
                if (item[ValueColumn] == DBNull.Value || string.IsNullOrWhiteSpace(item[ValueColumn].ToString()))
                {
                    list.Value = 0;
                }
                else
                {
                    list.Value = Convert.ToInt32(item[ValueColumn]);
                }
                if (item[TextColumn] == DBNull.Value || string.IsNullOrWhiteSpace(item[TextColumn].ToString()))
                {
                    list.Text = "";
                }
                else
                {
                    list.Text = item[TextColumn].ToString();
                }
                result.Add(list);
            }
            return result;
        }
        public List<DropDownList> downLists(DataRow[] data, string ValueColumn, string TextColumn)
        {
            List<DropDownList> result = new List<DropDownList>();
            DropDownList list = new DropDownList();
            foreach (DataRow item in data)
            {
                list = new DropDownList();
                if (item[ValueColumn] == DBNull.Value || string.IsNullOrWhiteSpace(item[ValueColumn].ToString()))
                {
                    list.Value = 0;
                }
                else
                {
                    list.Value = Convert.ToInt32(item[ValueColumn]);
                }
                if (item[TextColumn] == DBNull.Value || string.IsNullOrWhiteSpace(item[TextColumn].ToString()))
                {
                    list.Text = "";
                }
                else
                {
                    list.Text = item[TextColumn].ToString();
                }
                result.Add(list);
            }
            return result;
        }
    }
}
