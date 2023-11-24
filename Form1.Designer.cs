namespace MooreMachine
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 32);
            label1.Name = "label1";
            label1.Size = new Size(339, 20);
            label1.TabIndex = 0;
            label1.Text = "Sonlu Durumlar Kümesinin Eleman Sayısını Giriniz:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(367, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(102, 27);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 76);
            label2.Name = "label2";
            label2.Size = new Size(166, 20);
            label2.TabIndex = 2;
            label2.Text = "Alfebe Kümesini Giriniz:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 113);
            label3.Name = "label3";
            label3.Size = new Size(282, 20);
            label3.TabIndex = 3;
            label3.Text = "Olası Çıktı Kümesinin Elemanlarını Giriniz:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(367, 69);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(102, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(367, 110);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(102, 27);
            textBox3.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(182, 186);
            button1.Name = "button1";
            button1.Size = new Size(137, 29);
            button1.TabIndex = 6;
            button1.Text = "Tablo Oluştur";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 239);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
    }
}