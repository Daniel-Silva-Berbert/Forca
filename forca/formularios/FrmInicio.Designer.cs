namespace forca
{
    partial class FrmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            jogar = new Button();
            sair = new Button();
            inicio = new FlowLayoutPanel();
            button1 = new Button();
            inicio.SuspendLayout();
            SuspendLayout();
            // 
            // jogar
            // 
            jogar.BackColor = SystemColors.ActiveCaptionText;
            jogar.Font = new Font("Cascadia Mono", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jogar.ForeColor = SystemColors.Control;
            jogar.Location = new Point(3, 54);
            jogar.Name = "jogar";
            jogar.Size = new Size(298, 45);
            jogar.TabIndex = 0;
            jogar.Text = "COMO JOGAR";
            jogar.UseVisualStyleBackColor = false;
            jogar.Click += ComoJogar_Click;
            // 
            // sair
            // 
            sair.BackColor = SystemColors.ActiveCaptionText;
            sair.Font = new Font("Cascadia Mono", 20.25F, FontStyle.Bold);
            sair.ForeColor = SystemColors.Control;
            sair.Location = new Point(3, 105);
            sair.Name = "sair";
            sair.Size = new Size(298, 45);
            sair.TabIndex = 1;
            sair.Text = "SAIR";
            sair.UseVisualStyleBackColor = false;
            sair.Click += Sair_Click;
            // 
            // inicio
            // 
            inicio.Anchor = AnchorStyles.None;
            inicio.BackColor = Color.Transparent;
            inicio.Controls.Add(button1);
            inicio.Controls.Add(jogar);
            inicio.Controls.Add(sair);
            inicio.Location = new Point(248, 169);
            inicio.Name = "inicio";
            inicio.Size = new Size(302, 154);
            inicio.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.Font = new Font("Cascadia Mono", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(298, 45);
            button1.TabIndex = 2;
            button1.Text = "JOGAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Jogar_Click;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(800, 450);
            Controls.Add(inicio);
            Name = "FrmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            WindowState = FormWindowState.Maximized;
            inicio.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button jogar;
        private Button sair;
        private FlowLayoutPanel inicio;
        private Button button1;
    }
}
