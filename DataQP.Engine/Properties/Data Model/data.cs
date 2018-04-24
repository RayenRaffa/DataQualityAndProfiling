using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DATAQP
{
    public class Data
    {

        public int row_count;
        public int contains_null_count;
        public List<Column> columns;
        public DataTable Table;
        public DataTable Table_clone; 
        public Data()
        {
            this.row_count = 0;
            this.contains_null_count = 0;
            this.columns = new List<Column>();
            this.Table = new DataTable();
            this.Table_clone = new DataTable(); 
        }
        public void add_new_col(string name)
        {
            DataColumn dc = new DataColumn(name, typeof(string));
            Table.Columns.Add(dc);
            columns.Add(new Column(name, this));
        }
        public void add_new_row(List<String> new_row)
        {
            int counter = 0;
            foreach (string entery in new_row)
            {
                this.columns[counter].process_entery(entery);
                counter++;
            }
            object[] objArr = new object[new_row.Count];
            for (int i = 0; i < new_row.Count; i++)
            {
                if (new_row[i] != null)
                    objArr[i] = new_row[i];
                else
                    objArr[i] = DBNull.Value;
            }
            this.Table.Rows.Add(objArr);
        }
        public void convert_col_type(String Col_name, int new_type)
        {
            DataColumn dc= new DataColumn(Col_name + "_new", typeof(string));
            switch(new_type)
            {
                case 0:
                    dc = new DataColumn(Col_name + "_new", typeof(int)); 
                    break;
                case 1:
                    dc = new DataColumn(Col_name + "_new", typeof(double)); 
                    break;
                case 2:
                    dc = new DataColumn(Col_name + "_new", typeof(DateTime));
                    break; 
            
            }
            int ordinal = this.Table.Columns[Col_name].Ordinal;
            this.Table_clone.Columns.Add(dc);
            dc.SetOrdinal(ordinal);
            int n = new int();
            double x = new double();
            DateTime y = new DateTime();
            bool b = false; 
            foreach (DataRow dr in this.Table_clone.Rows) // main loop 
            {
                if (dr[Col_name] != DBNull.Value)
                {
                    switch (new_type)
                    {
                        case 0:
                            b = int.TryParse(dr[Col_name].ToString(), out n);
                            break; 
                        case 1:
                            b = double.TryParse(dr[Col_name].ToString(), out x);
                            break; 
                        case 2:
                            b = DateTime.TryParse(dr[Col_name].ToString(), out y);
                            break; 
                    }

                    if (b || new_type == 3)
                    {
                        dr[dc.ColumnName] = dr[Col_name]; 
                    }
                    else
                    { 
                        dr[dc.ColumnName] = DBNull.Value;
                    }
                }
                else
                {
                    dr[dc.ColumnName] = DBNull.Value; 
                }
            }
            this.Table_clone.Columns.Remove(Col_name); 
            dc.ColumnName = Col_name;


        }
        public void data_summery()
        {
            Console.Write("row count : ");
            Console.Write(this.row_count);
            Console.WriteLine();
            Console.Write("row with missing value(s) count : ");
            Console.Write(this.contains_null_count);
            Console.WriteLine();
            Console.Write("columns count : ");
            Console.Write(this.columns.Count);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Columns summery : ");
            Console.WriteLine();
            foreach (Column col in this.columns)
            {
                col.column_summery();
            }
        }
    }

}