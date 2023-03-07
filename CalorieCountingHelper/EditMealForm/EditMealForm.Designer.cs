namespace CalorieCountingHelper.EditDayForm
{
    partial class EditMealForm
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
            this.MealDataBox = new System.Windows.Forms.RichTextBox();
            this.RemoveFoodButton = new System.Windows.Forms.Button();
            this.AddFoodButton = new System.Windows.Forms.Button();
            this.FoodBox = new System.Windows.Forms.TextBox();
            this.AddSingleFoodButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MealDataBox
            // 
            this.MealDataBox.Location = new System.Drawing.Point(12, 12);
            this.MealDataBox.Name = "MealDataBox";
            this.MealDataBox.ReadOnly = true;
            this.MealDataBox.Size = new System.Drawing.Size(560, 265);
            this.MealDataBox.TabIndex = 0;
            this.MealDataBox.Text = "";
            // 
            // RemoveFoodButton
            // 
            this.RemoveFoodButton.Location = new System.Drawing.Point(12, 283);
            this.RemoveFoodButton.Name = "RemoveFoodButton";
            this.RemoveFoodButton.Size = new System.Drawing.Size(184, 40);
            this.RemoveFoodButton.TabIndex = 1;
            this.RemoveFoodButton.Text = "Remove One Food item";
            this.RemoveFoodButton.UseVisualStyleBackColor = true;
            this.RemoveFoodButton.Click += new System.EventHandler(this.RemoveFoodButton_Click);
            // 
            // AddFoodButton
            // 
            this.AddFoodButton.Location = new System.Drawing.Point(388, 283);
            this.AddFoodButton.Name = "AddFoodButton";
            this.AddFoodButton.Size = new System.Drawing.Size(184, 77);
            this.AddFoodButton.TabIndex = 2;
            this.AddFoodButton.Text = "Add Food";
            this.AddFoodButton.UseVisualStyleBackColor = true;
            this.AddFoodButton.Click += new System.EventHandler(this.AddFoodButton_Click);
            // 
            // FoodBox
            // 
            this.FoodBox.Location = new System.Drawing.Point(202, 312);
            this.FoodBox.Name = "FoodBox";
            this.FoodBox.Size = new System.Drawing.Size(29, 20);
            this.FoodBox.TabIndex = 3;
            // 
            // AddSingleFoodButton
            // 
            this.AddSingleFoodButton.Location = new System.Drawing.Point(12, 329);
            this.AddSingleFoodButton.Name = "AddSingleFoodButton";
            this.AddSingleFoodButton.Size = new System.Drawing.Size(184, 40);
            this.AddSingleFoodButton.TabIndex = 4;
            this.AddSingleFoodButton.Text = "Add One Food Item";
            this.AddSingleFoodButton.UseVisualStyleBackColor = true;
            this.AddSingleFoodButton.Click += new System.EventHandler(this.AddSingleFoodButton_Click);
            // 
            // EditMealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 391);
            this.Controls.Add(this.AddSingleFoodButton);
            this.Controls.Add(this.FoodBox);
            this.Controls.Add(this.AddFoodButton);
            this.Controls.Add(this.RemoveFoodButton);
            this.Controls.Add(this.MealDataBox);
            this.MaximumSize = new System.Drawing.Size(600, 430);
            this.MinimumSize = new System.Drawing.Size(600, 430);
            this.Name = "EditMealForm";
            this.Text = "Edit Meal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditMealForm_FormClosing);
            this.Load += new System.EventHandler(this.EditDayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox MealDataBox;
        private System.Windows.Forms.Button RemoveFoodButton;
        private System.Windows.Forms.Button AddFoodButton;
        private System.Windows.Forms.TextBox FoodBox;
        private System.Windows.Forms.Button AddSingleFoodButton;
    }
}