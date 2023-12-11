using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using forca.formularios;

namespace forca.formularios
{
    public partial class FormComoJogar : Form
    {
        public FormComoJogar()
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

        private void Manual_TextChanged(object sender, EventArgs e)
        {
            // Define o texto no RichTextBox
            manual.Text = "1 - Clique no botão ‘Jogar’ para iniciar o jogo.\r\n\r\n2 - Digite os nomes dos jogadores no campo apropriado. Certifique-se de que cada nome esteja correto para evitar confusões durante o jogo.\r\n\r\n3 - Escolha uma letra para começar o jogo. É importante ressaltar que não são permitidos números, letras acentuadas ou o caractere ‘Ç’. Certifique-se de escolher apenas letras do alfabeto não acentuadas.\r\n\r\n4 - Se você acredita que sabe a palavra, pode escrevê-la no campo apropriado. No entanto, tenha cuidado, pois se a palavra estiver errada, você perderá o jogo. Portanto, pense bem antes de fazer sua jogada.";

            // Seleciona todo o texto no RichTextBox
            manual.SelectAll();

            // Define o alinhamento do texto como justificado
            manual.SelectionAlignment = HorizontalAlignment.Left;

            // Limpa a seleção
            manual.DeselectAll();
        }

        private void Volta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            // Opcionalmente, você pode ocultar o formulário atual se não precisar mais dele
            this.Close();
        }
    }
}
