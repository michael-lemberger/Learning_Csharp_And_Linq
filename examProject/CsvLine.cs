using System;

namespace examProject
{
	public class CsvLine
	{
		public string Name { get; set; }
		public string DIY { get; set; }
		public int Buy { get; set; }
		public int Sell { get; set; }
		public string Color1 { get; set; }
		public string Color2 { get; set; }
		public string Source { get; set; }
		public string Source_Notes { get; set; } 
		public double Version { get; set; }
		public string Villager_Equippable { get; set; }
		public string Catalog { get; set; }
		public string Internal_ID { get; set; }
		public string Unique_Entry_ID { get; set; }

        internal static CsvLine ParseRow(string row)
        {
			var columns = row.Split(',');
			return new CsvLine()
			{
				Name = columns[0],
				DIY = columns[1],
				Buy = int.Parse(columns[2]),
				Sell = int.Parse(columns[3]),
				Color1 = columns[4],
				Color2 = columns[5],
				Source = columns[6],
				Source_Notes = columns[7],
				Version = Double.Parse(columns[8]),
				Villager_Equippable = columns[9],
				Catalog = columns[10],
				Internal_ID = columns[11],
				Unique_Entry_ID = columns[12]
			};
        }
    }
}
