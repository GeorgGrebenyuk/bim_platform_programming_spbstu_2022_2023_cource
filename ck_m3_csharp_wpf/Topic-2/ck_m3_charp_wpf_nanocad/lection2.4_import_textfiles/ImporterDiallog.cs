using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teigha.DatabaseServices;
using System.Windows.Forms.VisualStyles;

namespace lection2._4_import_textfiles
{
	public partial class ImporterDialog1 : Form
	{
		//private string file_path;
		private string[] file_data;
		private Dictionary<int, string> delimeter_identify = new Dictionary<int, string>()
		{
			{0, "," },
			{1, ";" },
			{2, "\t" },
			{3, "|" }
		};
		public ImporterDialog1(string file_path)
		{
			//this.file_path = file_path;
			file_data = File.ReadAllLines(file_path);
			InitializeComponent();
			delimeters_list.SelectedIndex = 0;
			this.as_points.Checked = true;

			//block_list create
			var block_names = ncad_tools.GetBlockNames();
			foreach (var block_name in block_names )
			{
				this.block_list.Items.Add( block_name.Value );
			}
			this.block_list.SelectedIndex = 0;

			reInsertPointsToTable();
		}
		private void reInsertPointsToTable()
		{
			this.points_table.Rows.Clear();
			char delim = Convert.ToChar(delimeter_identify[this.delimeters_list.SelectedIndex]);
			if (this.file_data[0].Contains(delim))
			{
				this.points_table.ColumnCount = file_data[0].
				Split(delim).Length;

				this.select_x.Items.Clear();
				this.select_y.Items.Clear();
				for (int c_counter = 0; c_counter < this.points_table.ColumnCount; c_counter++)
				{
					string c_name = "Колонка №" + c_counter.ToString();
					this.points_table.Columns[c_counter].Name = c_name;
					this.points_table.Columns[c_counter].Width = 50;

					this.select_x.Items.Add(c_counter);
					this.select_y.Items.Add(c_counter);
				}
			}
			else
			{
				this.points_table.ColumnCount = 1;
				this.points_table.Columns[0].Name = "Колонка №1";
				this.points_table.Columns[0].Width = 200;
				this.select_x.Items.Add(0);
				this.select_y.Items.Add(0);
			}


			foreach (string row_data_string in this.file_data)
			{
				if (row_data_string.Contains(delim))
				{
					string[] arr = row_data_string.Split(delim);
					this.points_table.Rows.Add(arr);
				}
				else this.points_table.Rows.Add(new string[1] { row_data_string });
			}

			
			this.select_x.SelectedIndex = 0;
			this.select_y.SelectedIndex = 0;

		}
		private void points_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void delimeters_list_SelectedIndexChanged(object sender, EventArgs e)
		{
			reInsertPointsToTable();
		}

		private void as_block_refs_CheckedChanged(object sender, EventArgs e)
		{
			if (as_block_refs.Checked)
			{
				this.block_list.Enabled = true;
			}
			else
			{
				this.block_list.Enabled = false;
			}
		}

		private void as_points_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void block_list_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void start_Click(object sender, EventArgs e)
		{
			//
			List<double[]> p_coords = new List<double[]>();
			char delim = Convert.ToChar(delimeter_identify[this.delimeters_list.SelectedIndex]);

			int row_start = 0;
			if (this.ignore_headers.Checked) row_start = 1;

			foreach (string row_data_string in this.file_data.Skip(row_start))
			{
				if (row_data_string.Contains(delim))
				{
					string[] arr = row_data_string.Split(delim);
					string x_str = arr[this.select_x.SelectedIndex];
					string y_str = arr[this.select_y.SelectedIndex];
					
					double x = Convert.ToDouble(x_str);
					double y = Convert.ToDouble(y_str);
					p_coords.Add(new double[2] { x, y });
				}
			}

			bool as_blocks;
			if (this.as_block_refs.Checked)  as_blocks = true;
			else as_blocks = false;
			ncad_tools.Insertdata(ref p_coords, as_blocks, this.block_list.SelectedItem.ToString());

			this.Close();

		}

		private void select_x_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void select_y_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void ignore_headers_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
