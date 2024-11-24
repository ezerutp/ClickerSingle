namespace rcomando
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnDefinir = new Button();
            lbl_posX = new Label();
            lbl_poxY = new Label();
            btnAccion = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDefinir
            // 
            btnDefinir.Location = new Point(153, 12);
            btnDefinir.Name = "btnDefinir";
            btnDefinir.Size = new Size(178, 32);
            btnDefinir.TabIndex = 0;
            btnDefinir.Text = "Desactivar Captura";
            btnDefinir.UseVisualStyleBackColor = true;
            btnDefinir.Click += btnDefinir_Click;
            // 
            // lbl_posX
            // 
            lbl_posX.AutoSize = true;
            lbl_posX.Location = new Point(74, 22);
            lbl_posX.Name = "lbl_posX";
            lbl_posX.Size = new Size(25, 15);
            lbl_posX.TabIndex = 1;
            lbl_posX.Text = "000";
            // 
            // lbl_poxY
            // 
            lbl_poxY.AutoSize = true;
            lbl_poxY.Location = new Point(74, 41);
            lbl_poxY.Name = "lbl_poxY";
            lbl_poxY.Size = new Size(25, 15);
            lbl_poxY.TabIndex = 2;
            lbl_poxY.Text = "000";
            // 
            // btnAccion
            // 
            btnAccion.Location = new Point(153, 50);
            btnAccion.Name = "btnAccion";
            btnAccion.Size = new Size(178, 32);
            btnAccion.TabIndex = 3;
            btnAccion.Text = "Desactivar Accion";
            btnAccion.UseVisualStyleBackColor = true;
            btnAccion.Click += btnAccion_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lbl_posX);
            groupBox1.Controls.Add(lbl_poxY);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(135, 70);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ubicacion";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            label1.Location = new Point(20, 22);
            label1.Name = "label1";
            label1.Size = new Size(40, 13);
            label1.TabIndex = 5;
            label1.Text = "POS_X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            label2.Location = new Point(20, 41);
            label2.Name = "label2";
            label2.Size = new Size(40, 13);
            label2.TabIndex = 6;
            label2.Text = "POS_Y";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 94);
            Controls.Add(groupBox1);
            Controls.Add(btnAccion);
            Controls.Add(btnDefinir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(359, 133);
            MinimumSize = new Size(359, 133);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDefinir;
        private Label lbl_posX;
        private Label lbl_poxY;
        private Button btnAccion;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
    }
}
