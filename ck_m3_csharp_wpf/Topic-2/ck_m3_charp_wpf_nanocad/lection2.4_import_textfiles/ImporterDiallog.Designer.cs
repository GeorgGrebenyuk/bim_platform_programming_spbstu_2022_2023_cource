namespace lection2._4_import_textfiles
{
	partial class ImporterDialog1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.points_table = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.delimeters_list = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.as_points = new System.Windows.Forms.RadioButton();
			this.as_block_refs = new System.Windows.Forms.RadioButton();
			this.block_list = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.start = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.select_x = new System.Windows.Forms.ListBox();
			this.label7 = new System.Windows.Forms.Label();
			this.select_y = new System.Windows.Forms.ListBox();
			this.ignore_headers = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.points_table)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(268, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Табличное представление импортируемых данных:";
			// 
			// points_table
			// 
			this.points_table.AllowUserToAddRows = false;
			this.points_table.AllowUserToDeleteRows = false;
			this.points_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.points_table.Location = new System.Drawing.Point(16, 38);
			this.points_table.Name = "points_table";
			this.points_table.ReadOnly = true;
			this.points_table.Size = new System.Drawing.Size(501, 181);
			this.points_table.TabIndex = 1;
			this.points_table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.points_table_CellContentClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(514, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Выберите разделитель данных:";
			// 
			// delimeters_list
			// 
			this.delimeters_list.FormattingEnabled = true;
			this.delimeters_list.Items.AddRange(new object[] {
            "Запятая",
            "Точка с запятой",
            "Табулятор (\\t)",
            "Вертикальная черта"});
			this.delimeters_list.Location = new System.Drawing.Point(526, 38);
			this.delimeters_list.Name = "delimeters_list";
			this.delimeters_list.Size = new System.Drawing.Size(214, 69);
			this.delimeters_list.TabIndex = 3;
			this.delimeters_list.SelectedIndexChanged += new System.EventHandler(this.delimeters_list_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 222);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(140, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Выберите режим импорта";
			// 
			// as_points
			// 
			this.as_points.AutoSize = true;
			this.as_points.Location = new System.Drawing.Point(16, 252);
			this.as_points.Name = "as_points";
			this.as_points.Size = new System.Drawing.Size(90, 17);
			this.as_points.TabIndex = 5;
			this.as_points.TabStop = true;
			this.as_points.Text = "В виде точек";
			this.as_points.UseVisualStyleBackColor = true;
			this.as_points.CheckedChanged += new System.EventHandler(this.as_points_CheckedChanged);
			// 
			// as_block_refs
			// 
			this.as_block_refs.AutoSize = true;
			this.as_block_refs.Location = new System.Drawing.Point(113, 252);
			this.as_block_refs.Name = "as_block_refs";
			this.as_block_refs.Size = new System.Drawing.Size(150, 17);
			this.as_block_refs.TabIndex = 6;
			this.as_block_refs.TabStop = true;
			this.as_block_refs.Text = "В виде вхождений блока";
			this.as_block_refs.UseVisualStyleBackColor = true;
			this.as_block_refs.CheckedChanged += new System.EventHandler(this.as_block_refs_CheckedChanged);
			// 
			// block_list
			// 
			this.block_list.FormattingEnabled = true;
			this.block_list.Location = new System.Drawing.Point(280, 252);
			this.block_list.Name = "block_list";
			this.block_list.Size = new System.Drawing.Size(237, 56);
			this.block_list.TabIndex = 7;
			this.block_list.SelectedIndexChanged += new System.EventHandler(this.block_list_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(280, 233);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(154, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Выберите блок для импорта:";
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(665, 285);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(75, 23);
			this.start.TabIndex = 9;
			this.start.Text = "Импорт!";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(537, 282);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 26);
			this.label5.TabIndex = 10;
			this.label5.Text = "Нажмите для\r\nначала импорта";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(523, 110);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Выберите колонку с X";
			// 
			// select_x
			// 
			this.select_x.FormattingEnabled = true;
			this.select_x.Location = new System.Drawing.Point(526, 126);
			this.select_x.Name = "select_x";
			this.select_x.Size = new System.Drawing.Size(88, 95);
			this.select_x.TabIndex = 12;
			this.select_x.SelectedIndexChanged += new System.EventHandler(this.select_x_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(649, 110);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Выберите Y";
			// 
			// select_y
			// 
			this.select_y.FormattingEnabled = true;
			this.select_y.Location = new System.Drawing.Point(649, 126);
			this.select_y.Name = "select_y";
			this.select_y.Size = new System.Drawing.Size(91, 95);
			this.select_y.TabIndex = 14;
			this.select_y.SelectedIndexChanged += new System.EventHandler(this.select_y_SelectedIndexChanged);
			// 
			// ignore_headers
			// 
			this.ignore_headers.AutoSize = true;
			this.ignore_headers.Location = new System.Drawing.Point(540, 252);
			this.ignore_headers.Name = "ignore_headers";
			this.ignore_headers.Size = new System.Drawing.Size(175, 17);
			this.ignore_headers.TabIndex = 15;
			this.ignore_headers.Text = "Игнорировать первую строку";
			this.ignore_headers.UseVisualStyleBackColor = true;
			this.ignore_headers.CheckedChanged += new System.EventHandler(this.ignore_headers_CheckedChanged);
			// 
			// ImporterDialog1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(758, 320);
			this.Controls.Add(this.ignore_headers);
			this.Controls.Add(this.select_y);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.select_x);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.start);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.block_list);
			this.Controls.Add(this.as_block_refs);
			this.Controls.Add(this.as_points);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.delimeters_list);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.points_table);
			this.Controls.Add(this.label1);
			this.Name = "ImporterDialog1";
			this.Text = "ImporterDiallog";
			((System.ComponentModel.ISupportInitialize)(this.points_table)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView points_table;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox delimeters_list;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton as_points;
		private System.Windows.Forms.RadioButton as_block_refs;
		private System.Windows.Forms.ListBox block_list;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ListBox select_x;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ListBox select_y;
		private System.Windows.Forms.CheckBox ignore_headers;
	}
}