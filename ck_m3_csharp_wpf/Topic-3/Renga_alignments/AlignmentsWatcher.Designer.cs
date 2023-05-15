namespace Renga_alignments
{
    partial class AlignmentsWatcher
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
            this.alignm_form = new System.Windows.Forms.TreeView();
            this.update_routes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Форма отображения трасс инженерных сетей:";
            // 
            // alignm_form
            // 
            this.alignm_form.Location = new System.Drawing.Point(15, 25);
            this.alignm_form.Name = "alignm_form";
            this.alignm_form.Size = new System.Drawing.Size(486, 181);
            this.alignm_form.TabIndex = 1;
            this.alignm_form.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.alignm_form_AfterSelect);
            // 
            // update_routes
            // 
            this.update_routes.Location = new System.Drawing.Point(408, 226);
            this.update_routes.Name = "update_routes";
            this.update_routes.Size = new System.Drawing.Size(75, 23);
            this.update_routes.TabIndex = 2;
            this.update_routes.Text = "Обновить";
            this.update_routes.UseVisualStyleBackColor = true;
            this.update_routes.Click += new System.EventHandler(this.update_routes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Обновить список трасс:";
            // 
            // AlignmentsWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(513, 273);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.update_routes);
            this.Controls.Add(this.alignm_form);
            this.Controls.Add(this.label1);
            this.Name = "AlignmentsWatcher";
            this.Text = "AlignmentsWatcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView alignm_form;
        private System.Windows.Forms.Button update_routes;
        private System.Windows.Forms.Label label2;
    }
}