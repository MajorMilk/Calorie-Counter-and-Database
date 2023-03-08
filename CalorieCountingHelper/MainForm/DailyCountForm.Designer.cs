namespace CalorieCountingHelper
{
    partial class DailyCountForm
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.DataReadoutBox = new System.Windows.Forms.RichTextBox();
            this.AddMealButtom = new System.Windows.Forms.Button();
            this.RemoveMealButton = new System.Windows.Forms.Button();
            this.MealBox = new System.Windows.Forms.TextBox();
            this.EditMealButton = new System.Windows.Forms.Button();
            this.NumMealsBox = new System.Windows.Forms.TextBox();
            this.TotalCalsBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // DataReadoutBox
            // 
            this.DataReadoutBox.Location = new System.Drawing.Point(257, 18);
            this.DataReadoutBox.Name = "DataReadoutBox";
            this.DataReadoutBox.ReadOnly = true;
            this.DataReadoutBox.Size = new System.Drawing.Size(517, 371);
            this.DataReadoutBox.TabIndex = 2;
            this.DataReadoutBox.Text = "";
            // 
            // AddMealButtom
            // 
            this.AddMealButtom.Location = new System.Drawing.Point(18, 277);
            this.AddMealButtom.Name = "AddMealButtom";
            this.AddMealButtom.Size = new System.Drawing.Size(160, 50);
            this.AddMealButtom.TabIndex = 4;
            this.AddMealButtom.Text = "Add Meal";
            this.AddMealButtom.UseVisualStyleBackColor = true;
            this.AddMealButtom.Click += new System.EventHandler(this.AddMealButtom_Click);
            // 
            // RemoveMealButton
            // 
            this.RemoveMealButton.Location = new System.Drawing.Point(18, 333);
            this.RemoveMealButton.Name = "RemoveMealButton";
            this.RemoveMealButton.Size = new System.Drawing.Size(92, 25);
            this.RemoveMealButton.TabIndex = 5;
            this.RemoveMealButton.Text = "Remove Meal";
            this.RemoveMealButton.UseVisualStyleBackColor = true;
            this.RemoveMealButton.Click += new System.EventHandler(this.RemoveMealButton_Click);
            // 
            // MealBox
            // 
            this.MealBox.Location = new System.Drawing.Point(116, 350);
            this.MealBox.Name = "MealBox";
            this.MealBox.Size = new System.Drawing.Size(62, 20);
            this.MealBox.TabIndex = 6;
            // 
            // EditMealButton
            // 
            this.EditMealButton.Location = new System.Drawing.Point(18, 364);
            this.EditMealButton.Name = "EditMealButton";
            this.EditMealButton.Size = new System.Drawing.Size(92, 25);
            this.EditMealButton.TabIndex = 7;
            this.EditMealButton.Text = "Edit Meal";
            this.EditMealButton.UseVisualStyleBackColor = true;
            this.EditMealButton.Click += new System.EventHandler(this.EditMealButton_Click);
            // 
            // NumMealsBox
            // 
            this.NumMealsBox.Location = new System.Drawing.Point(10, 429);
            this.NumMealsBox.Name = "NumMealsBox";
            this.NumMealsBox.ReadOnly = true;
            this.NumMealsBox.Size = new System.Drawing.Size(46, 20);
            this.NumMealsBox.TabIndex = 8;
            // 
            // TotalCalsBox
            // 
            this.TotalCalsBox.Location = new System.Drawing.Point(700, 428);
            this.TotalCalsBox.Name = "TotalCalsBox";
            this.TotalCalsBox.ReadOnly = true;
            this.TotalCalsBox.Size = new System.Drawing.Size(72, 20);
            this.TotalCalsBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total Calories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Number of Meals";
            // 
            // DailyCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TotalCalsBox);
            this.Controls.Add(this.NumMealsBox);
            this.Controls.Add(this.EditMealButton);
            this.Controls.Add(this.MealBox);
            this.Controls.Add(this.RemoveMealButton);
            this.Controls.Add(this.AddMealButtom);
            this.Controls.Add(this.DataReadoutBox);
            this.Controls.Add(this.monthCalendar1);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "DailyCountForm";
            this.Text = "Daily Count";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DailyCountForm_FormClosing);
            this.Load += new System.EventHandler(this.DailyCountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.RichTextBox DataReadoutBox;
        private System.Windows.Forms.Button AddMealButtom;
        private System.Windows.Forms.Button RemoveMealButton;
        private System.Windows.Forms.TextBox MealBox;
        private System.Windows.Forms.Button EditMealButton;
        private System.Windows.Forms.TextBox NumMealsBox;
        private System.Windows.Forms.TextBox TotalCalsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

