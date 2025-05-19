namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numericUpDown_depth = new NumericUpDown();
            button_start = new Button();
            richTextBox_output = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_depth).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown_depth
            // 
            numericUpDown_depth.Location = new Point(12, 12);
            numericUpDown_depth.Name = "numericUpDown_depth";
            numericUpDown_depth.Size = new Size(120, 23);
            numericUpDown_depth.TabIndex = 0;
            // 
            // button_start
            // 
            button_start.Location = new Point(188, 12);
            button_start.Name = "button_start";
            button_start.Size = new Size(89, 33);
            button_start.TabIndex = 1;
            button_start.Text = "start";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += start_Click;
            // 
            // richTextBox_output
            // 
            richTextBox_output.Location = new Point(12, 72);
            richTextBox_output.Name = "richTextBox_output";
            richTextBox_output.Size = new Size(776, 366);
            richTextBox_output.TabIndex = 2;
            richTextBox_output.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox_output);
            Controls.Add(button_start);
            Controls.Add(numericUpDown_depth);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown_depth).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown numericUpDown_depth;
        private Button button_start;
        private RichTextBox richTextBox_output;
    }
}
