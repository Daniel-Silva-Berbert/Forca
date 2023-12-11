using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forca.formularios
{
    public partial class FormNomes : Form
    {
        private TextBox nome1TextBox;
        private TextBox nome2TextBox;
        private Button adicionarNomesButton;
        public string nome1;
        public string nome2;

        public FormNomes()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Configuração da janela principal
            Text = "Inserir Nomes";
            Size = new System.Drawing.Size(300, 150);

            // Configuração da primeira caixa de texto
            nome1TextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 20)
            };
            nome1TextBox.PlaceholderText = "Nome do 1º jogador";

            // Configuração da segunda caixa de texto
            nome2TextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(200, 20)
            };
            nome2TextBox.PlaceholderText = "Nome do 2º jogador";
            

            // Configuração do botão
            adicionarNomesButton = new Button
            {
                Text = "Adicionar Nomes",
                Location = new System.Drawing.Point(20, 80)
            };

            // Configuração do evento de clique do botão
            adicionarNomesButton.Click += AdicionarNomesButton_Click;

            // Adiciona os controles à janela principal
            Controls.Add(nome1TextBox);
            Controls.Add(nome2TextBox);
            Controls.Add(adicionarNomesButton);
        }

        private void AdicionarNomesButton_Click(object sender, EventArgs e)
        {
            // Ao clicar no botão, exibe uma mensagem com os nomes inseridos
            nome1 = nome1TextBox.Text;
            nome2 = nome2TextBox.Text;

            // Define o resultado do formulário como OK
            this.DialogResult = DialogResult.OK;

            // Fecha o formulário
            Close();
        }
    }
}
