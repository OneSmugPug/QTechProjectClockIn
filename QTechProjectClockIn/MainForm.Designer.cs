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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_IN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OUT = new System.Windows.Forms.Button();
            this.projNumDrp = new Bunifu.Framework.UI.BunifuDropdown();
            this.SuspendLayout();
            // 
            // btn_IN
            // 
            this.btn_IN.Enabled = false;
            this.btn_IN.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
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
            this.btn_IN.MouseEnter += new System.EventHandler(this.Btn_IN_MouseEnter);
            this.btn_IN.MouseLeave += new System.EventHandler(this.Btn_IN_MouseLeave);
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
            // btn_OUT
            // 
            this.btn_OUT.Enabled = false;
            this.btn_OUT.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
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
            this.btn_OUT.MouseEnter += new System.EventHandler(this.Btn_OUT_MouseEnter);
            this.btn_OUT.MouseLeave += new System.EventHandler(this.Btn_OUT_MouseLeave);
            // 
            // projNumDrp
            // 
            this.projNumDrp.BackColor = System.Drawing.Color.Transparent;
            this.projNumDrp.BorderRadius = 3;
            this.projNumDrp.DisabledColor = System.Drawing.Color.Gray;
            this.projNumDrp.ForeColor = System.Drawing.Color.Black;
            this.projNumDrp.Items = new string[0];
            this.projNumDrp.Location = new System.Drawing.Point(152, 50);
            this.projNumDrp.Name = "projNumDrp";
            this.projNumDrp.NomalColor = System.Drawing.Color.White;
            this.projNumDrp.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.projNumDrp.selectedIndex = -1;
            this.projNumDrp.Size = new System.Drawing.Size(170, 31);
            this.projNumDrp.TabIndex = 5;
            this.projNumDrp.onItemSelected += new System.EventHandler(this.ProjNumDrp_onItemSelected);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(352, 179);
            this.Controls.Add(this.projNumDrp);
            this.Controls.Add(this.btn_OUT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_IN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(368, 218);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(368, 218);
            this.Name = "MainForm";
            this.Text = "Project Time Clocker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_IN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OUT;
        private Bunifu.Framework.UI.BunifuDropdown projNumDrp;
    }
}

