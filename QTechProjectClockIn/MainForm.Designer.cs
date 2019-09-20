namespace QTechProjectClockIn
{
    partial class MainForm
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
            this.btn_IN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.projNum_Txt = new System.Windows.Forms.TextBox();
            this.btn_OUT = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_IN
            // 
            this.btn_IN.Enabled = false;
            this.btn_IN.FlatAppearance.BorderSize = 0;
            this.btn_IN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_IN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_IN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_IN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_IN.Location = new System.Drawing.Point(93, 118);
            this.btn_IN.Name = "btn_IN";
            this.btn_IN.Size = new System.Drawing.Size(70, 30);
            this.btn_IN.TabIndex = 0;
            this.btn_IN.Text = "IN";
            this.btn_IN.UseVisualStyleBackColor = true;
            this.btn_IN.Click += new System.EventHandler(this.Btn_IN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Number:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.projNum_Txt);
            this.panel1.Location = new System.Drawing.Point(150, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 25);
            this.panel1.TabIndex = 3;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(-1, 18);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(150, 10);
            this.bunifuSeparator1.TabIndex = 1;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // projNum_Txt
            // 
            this.projNum_Txt.BackColor = System.Drawing.Color.LightGray;
            this.projNum_Txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projNum_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projNum_Txt.Location = new System.Drawing.Point(2, 3);
            this.projNum_Txt.Name = "projNum_Txt";
            this.projNum_Txt.Size = new System.Drawing.Size(149, 16);
            this.projNum_Txt.TabIndex = 0;
            this.projNum_Txt.TextChanged += new System.EventHandler(this.ProjNum_Txt_TextChanged);
            // 
            // btn_OUT
            // 
            this.btn_OUT.Enabled = false;
            this.btn_OUT.FlatAppearance.BorderSize = 0;
            this.btn_OUT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_OUT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_OUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OUT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_OUT.Location = new System.Drawing.Point(187, 118);
            this.btn_OUT.Name = "btn_OUT";
            this.btn_OUT.Size = new System.Drawing.Size(70, 30);
            this.btn_OUT.TabIndex = 4;
            this.btn_OUT.Text = "OUT";
            this.btn_OUT.UseVisualStyleBackColor = true;
            this.btn_OUT.Click += new System.EventHandler(this.Btn_OUT_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(352, 179);
            this.Controls.Add(this.btn_OUT);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_IN);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(368, 218);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(368, 218);
            this.Name = "MainForm";
            this.Text = "Project Time Clocker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_IN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.TextBox projNum_Txt;
        private System.Windows.Forms.Button btn_OUT;
    }
}

