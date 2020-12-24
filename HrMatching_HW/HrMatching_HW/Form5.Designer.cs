namespace HrMatching_HW
{
    partial class Form5
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addVacancyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yourPostedVacanciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWorkAppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPerCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVacancyToolStripMenuItem,
            this.yourPostedVacanciesToolStripMenuItem,
            this.showWorkAppliersToolStripMenuItem,
            this.searchPerCategoryToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addVacancyToolStripMenuItem
            // 
            this.addVacancyToolStripMenuItem.Name = "addVacancyToolStripMenuItem";
            this.addVacancyToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.addVacancyToolStripMenuItem.Text = "Add Vacancy";
            this.addVacancyToolStripMenuItem.Click += new System.EventHandler(this.addVacancyToolStripMenuItem_Click);
            // 
            // yourPostedVacanciesToolStripMenuItem
            // 
            this.yourPostedVacanciesToolStripMenuItem.Name = "yourPostedVacanciesToolStripMenuItem";
            this.yourPostedVacanciesToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.yourPostedVacanciesToolStripMenuItem.Text = "Your Posted Vacancies";
            this.yourPostedVacanciesToolStripMenuItem.Click += new System.EventHandler(this.yourPostedVacanciesToolStripMenuItem_Click);
            // 
            // showWorkAppliersToolStripMenuItem
            // 
            this.showWorkAppliersToolStripMenuItem.Name = "showWorkAppliersToolStripMenuItem";
            this.showWorkAppliersToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.showWorkAppliersToolStripMenuItem.Text = "Show Work Appliers";
            this.showWorkAppliersToolStripMenuItem.Click += new System.EventHandler(this.showWorkAppliersToolStripMenuItem_Click);
            // 
            // searchPerCategoryToolStripMenuItem
            // 
            this.searchPerCategoryToolStripMenuItem.Name = "searchPerCategoryToolStripMenuItem";
            this.searchPerCategoryToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.searchPerCategoryToolStripMenuItem.Text = "Search Per Category";
            this.searchPerCategoryToolStripMenuItem.Click += new System.EventHandler(this.searchPerCategoryToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "From Menu Above You can Select";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form5";
            this.Text = "Boss Main Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addVacancyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchPerCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWorkAppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem yourPostedVacanciesToolStripMenuItem;
    }
}