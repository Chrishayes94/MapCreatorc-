using MapCreator.WorldView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCreator.GUI.WorldTree
{
    public class WorldDataTable : DataTable
    {

        public MapData CurrentMap { get; set; }

        public WorldDataTable(string tableName) : base(tableName)
        {
            CurrentMap = new MapData(0, null);

            DataColumn nameColumn = new DataColumn("Name");
            nameColumn.DataType = typeof(string);
            nameColumn.DefaultValue = "Empty Map";

            this.Columns.Add(nameColumn);
        }

        public DataRow CreateDataRow(string name)
        {
            DataRow row = this.NewRow();
            row["Name"] = name;

            return row;
        }
    }
}
