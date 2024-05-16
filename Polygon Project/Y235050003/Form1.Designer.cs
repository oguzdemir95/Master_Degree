namespace Y235050003
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
            cntTbX = new TextBox();
            label1 = new Label();
            cntTbY = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lntTb = new TextBox();
            noeTb = new TextBox();
            raTb = new TextBox();
            coorLb = new ListBox();
            pictureBox1 = new PictureBox();
            btnRnd = new Button();
            btnDraw = new Button();
            btnRotate = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cntTbX
            // 
            cntTbX.Location = new Point(165, 44);
            cntTbX.Name = "cntTbX";
            cntTbX.Size = new Size(125, 27);
            cntTbX.TabIndex = 0;
            cntTbX.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 47);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 1;
            label1.Text = "Center Points";
            // 
            // cntTbY
            // 
            cntTbY.Location = new Point(307, 44);
            cntTbY.Name = "cntTbY";
            cntTbY.Size = new Size(125, 27);
            cntTbY.TabIndex = 2;
            cntTbY.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 97);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 3;
            label2.Text = "Length";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 148);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 4;
            label3.Text = "Number of Edges";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 203);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 5;
            label4.Text = "Rotation Angle";
            // 
            // lntTb
            // 
            lntTb.Location = new Point(165, 94);
            lntTb.Name = "lntTb";
            lntTb.Size = new Size(125, 27);
            lntTb.TabIndex = 6;
            lntTb.Text = "5";
            // 
            // noeTb
            // 
            noeTb.Location = new Point(165, 145);
            noeTb.Name = "noeTb";
            noeTb.Size = new Size(125, 27);
            noeTb.TabIndex = 7;
            noeTb.Text = "4";
            // 
            // raTb
            // 
            raTb.Location = new Point(165, 203);
            raTb.Name = "raTb";
            raTb.Size = new Size(125, 27);
            raTb.TabIndex = 8;
            raTb.Text = "30";
            // 
            // coorLb
            // 
            coorLb.FormattingEnabled = true;
            coorLb.Location = new Point(34, 271);
            coorLb.Name = "coorLb";
            coorLb.Size = new Size(256, 124);
            coorLb.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(511, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(380, 350);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // btnRnd
            // 
            btnRnd.Location = new Point(338, 271);
            btnRnd.Name = "btnRnd";
            btnRnd.Size = new Size(149, 29);
            btnRnd.TabIndex = 11;
            btnRnd.Text = "Set Random Value";
            btnRnd.UseVisualStyleBackColor = true;
            btnRnd.Click += btnRnd_Click;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(338, 318);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(149, 29);
            btnDraw.TabIndex = 12;
            btnDraw.Text = "Draw";
            btnDraw.UseVisualStyleBackColor = true;
            btnDraw.Click += btnDraw_Click;
            // 
            // btnRotate
            // 
            btnRotate.Location = new Point(338, 366);
            btnRotate.Name = "btnRotate";
            btnRotate.Size = new Size(149, 29);
            btnRotate.TabIndex = 13;
            btnRotate.Text = "Rotate Angle";
            btnRotate.UseVisualStyleBackColor = true;
            btnRotate.Click += btnRotate_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 248);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 14;
            label5.Text = "Coordinates";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 450);
            Controls.Add(label5);
            Controls.Add(btnRotate);
            Controls.Add(btnDraw);
            Controls.Add(btnRnd);
            Controls.Add(pictureBox1);
            Controls.Add(coorLb);
            Controls.Add(raTb);
            Controls.Add(noeTb);
            Controls.Add(lntTb);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cntTbY);
            Controls.Add(label1);
            Controls.Add(cntTbX);
            Name = "Form1";
            Text = "Polygon Plotter";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox cntTbX;
        private Label label1;
        private TextBox cntTbY;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox lntTb;
        private TextBox noeTb;
        private TextBox raTb;
        private PictureBox pictureBox1;
        private Button btnRnd;
        private Button btnDraw;
        private Button btnRotate;
        private Label label5;
        private ListBox coorLb;
    }
}
