using System;
using System.Windows.Forms;
using forca.formularios;

namespace forca
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            //estado da janela como normal
            this.WindowState = FormWindowState.Normal;
            //Obtem a área de trabalho
            Rectangle areaTrabalho = Screen.GetWorkingArea(this);
            //não cobrir a barra de tarefa
            this.Size = new Size(1024, 1024);
            // canto superior
            this.Location = areaTrabalho.Location;
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComoJogar_Click(object sender, EventArgs e)
        {
            
            FormComoJogar formComoJoga = new FormComoJogar();
            this.Hide();
            DialogResult fecha = formComoJoga.ShowDialog();
            if (fecha == DialogResult.OK)
            {
                this.Show();
            };
        }

        private void Jogar_Click(object sender, EventArgs e)
        {
            // Cria uma instância do FormNomes
            FormNomes nomes = new FormNomes();

            
            DialogResult resultado = nomes.ShowDialog();

            // Verifica se o usuário clicou em OK em FormNomes
            if (resultado == DialogResult.OK)
            {
                // Cria uma instância do FormJogar, passando os nomes de FormNomes
                FormJogar formJoga = new FormJogar(nomes.nome1, nomes.nome2);
                this.Hide();
                DialogResult fecha = formJoga.ShowDialog();
                
                if (fecha == DialogResult.OK)
                {
                    this.Show();
                };
            }
        }

    }
}
