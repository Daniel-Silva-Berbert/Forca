namespace forca.formularios
{
    partial class FormComoJogar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComoJogar));
            manual = new RichTextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // manual
            // 
            manual.BackColor = SystemColors.Control;
            manual.BorderStyle = BorderStyle.None;
            manual.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            manual.ForeColor = SystemColors.ActiveCaptionText;
            manual.Location = new Point(244, 176);
            manual.Name = "manual";
            manual.Size = new Size(480, 607);
            manual.TabIndex = 0;
            manual.Text = "";
            manual.TextChanged += Manual_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.Font = new Font("Cascadia Mono", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(328, 789);
            button1.Name = "button1";
            button1.Size = new Size(298, 45);
            button1.TabIndex = 3;
            button1.Text = "VOLTA";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Volta_Click;
            // 
            // FormComoJogar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1095, 926);
            Controls.Add(button1);
            Controls.Add(manual);
            Name = "FormComoJogar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Como Jogar?";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox manual;
        private Button button1;
    }
}