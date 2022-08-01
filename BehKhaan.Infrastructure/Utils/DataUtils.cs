using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Utils
{
    public static class DataUtils
    {

        public static string DataTableToString(DataTable table)
        {
            string result = string.Empty;
            StringBuilder resultBuilder = new StringBuilder();

            if (table != null && table.Rows != null && table.Columns != null && table.Columns.Count > 0)
            {
                int lastItemIndex = table.Columns.Count - 1;
                int index = 0;

                resultBuilder.Append("\n" + table.TableName);
                resultBuilder.Append("\n\t");

                foreach (DataColumn column in table.Columns)
                {
                    resultBuilder.Append(column.ColumnName);

                    if (index < lastItemIndex)       
                        resultBuilder.Append(", "); 

                    index++;
                }

                resultBuilder.AppendLine();  

                foreach (DataRow dataRow in table.Rows)
                {
                    lastItemIndex = dataRow.ItemArray.Length - 1;
                    index = 0;
                    resultBuilder.Append("\t");
                    foreach (object item in dataRow.ItemArray)
                    {
                        resultBuilder.Append(item);

                        if (index < lastItemIndex)       
                            resultBuilder.Append(", ");  

                        index++;
                    }

                    resultBuilder.AppendLine();  
                }

                result = resultBuilder.ToString();
            }

            return result;
        }
    }
}
