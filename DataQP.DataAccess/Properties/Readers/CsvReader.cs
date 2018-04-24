using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATAQP
{
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }
    class CsvReader : Input
    {
        public CsvReader(string filename) : base(filename)
        {

        }
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                // Special handling for quoted field
                if (row.LineText[pos] == '"')
                {
                    // Skip initial quote
                    pos++;

                    // Parse quoted value
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        // Test for quote character
                        if (row.LineText[pos] == '"')
                        {
                            // Found one
                            pos++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Parse unquoted value
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                // Add field to list
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;

                // Eat up to and including next comma
                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            // Delete any unused items
            while (row.Count > rows)
                row.RemoveAt(rows);

            // Return true if any columns read
            return (row.Count > 0);
        }
        public override Data read_file()
        {
            Data Output_data = new Data();
            CsvRow row = new CsvRow();
            this.ReadRow(row);
            foreach (string col_name in row) // suppose that the first row is the cols name !
            {
                Output_data.add_new_col(col_name);
            }
            while (this.ReadRow(row))
            {
                //int counter = 0; // helps to dectect null values in the row
                int row_contain_null_val = 0;
                Output_data.row_count++;
                List<string> new_row = new List<string>();
                for (int counter = 0; counter < Output_data.columns.Count; counter++)
                {
                    string entery;
                    if (counter < row.Count)
                    {
                        entery = row[counter];
                    }
                    else
                    {
                        entery = "";
                        row_contain_null_val = 1;
                    }
                    if (entery == "")
                    {
                        new_row.Add(null);
                    }
                    else
                    {
                        new_row.Add(entery);
                    }
                    Output_data.contains_null_count += row_contain_null_val;
                }
                Output_data.add_new_row(new_row);
            }
            return Output_data;
        }
    }
}
