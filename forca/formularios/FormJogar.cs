using forca.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forca.formularios
{
    public delegate void CheckLetter(string letter);
    public partial class FormJogar : Form
    {
        //Um evento que é invocado a cada vez quando um tecla (letra) é pressionada
        event CheckLetter ChkLtr;

        private SoundPlayer _player;

        string input;
        string letras_Informadas = "";

        //procura uma palavra
        string palavraAEcontrar = "";

        //estado atual das letras encontradas na palavra
        string palavraAExibir = "";

        //array de caracteres da palavra
        char[] arrayPalavraAEncontrar;
        int[] palavraAEncontrarPosicaoLetras;
        bool isLetraEncontrada = false;

        Palavras palavra = new Palavras();

        //jogadores
        Jogadores jogador1;
        Jogadores jogador2;

        //variavel de controle
        private bool vez = false;

        public FormJogar(string nome1, string nome2)
        {
            InitializeComponent();

            //verificacao de teclas
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FormJogar_KeyDown);

            //estado da janela como normal
            this.WindowState = FormWindowState.Normal;
            //Obtem a área de trabalho
            Rectangle areaTrabalho = Screen.GetWorkingArea(this);
            //não cobrir a barra de tarefa
            this.Size = new Size(1024, 1024);
            // canto superior
            this.Location = areaTrabalho.Location;


            this.ChkLtr += new CheckLetter(ChecarLetra);

            //jogadores
            jogador1 = new Jogadores(nome1);
            jogador2 = new Jogadores(nome2);
            //musica
            _player = new SoundPlayer("music.wav");
            _player.Play();


            IniciarJogo();
        }


        private void ChecarLetra(string letra)
        {
            try
            {

                if (jogador1.getTentativas() != 0 || jogador2.getTentativas() != 0)
                {
                    //verificar se a letra foi encontrada
                    isLetraEncontrada = false; //Variavel de controle
                    for (int i = 0; i < arrayPalavraAEncontrar.Length; i++)
                    {
                        if (letra[0] == arrayPalavraAEncontrar[i])
                        {
                            palavraAEncontrarPosicaoLetras[i] = 1;
                            isLetraEncontrada = true;
                        }
                    }

                    //ERROU
                    if (isLetraEncontrada == false)
                    {
                        letras_Informadas += letra + ", ";
                        if (vez == false)
                        {
                            jogador1.setTentativas(jogador1.getTentativas() - 1);
                            Pontos1.Text = (jogador1.getTentativas()).ToString();
                            Jogador1.BackColor = Color.Black;
                            Jogador2.BackColor = Color.Red;
                            vez = true;
                        }
                        else
                        {
                            jogador2.setTentativas(jogador2.getTentativas() - 1);
                            Pontos2.Text = (jogador2.getTentativas()).ToString();
                            Jogador2.BackColor = Color.Black;
                            Jogador1.BackColor = Color.Red;
                            vez = false;
                        }
                    }

                    palavraAExibir = "";
                    for (int i = 0; i < arrayPalavraAEncontrar.Length; i++)
                    {
                        if (palavraAEncontrarPosicaoLetras[i] == 1)
                        {
                            palavraAExibir += arrayPalavraAEncontrar[i].ToString();
                        }
                        else
                        {
                            palavraAExibir += "-";
                        }
                    }

                    label_palavra.Text = palavraAExibir.ToUpper();
                    label_letras.Text = letras_Informadas;

                    if (palavraAEncontrarPosicaoLetras.All(e => e == 1))
                    {
                        if (vez == false)
                        {
                            MessageBox.Show($"{jogador1.getNome()} ACERTOU A PALAVRA.", "RESULTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"{jogador2.getNome()} ACERTOU A PALAVRA.", "RESULTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    if (vez == false)
                    {
                        MessageBox.Show($"{jogador1.getNome()} gastou todas as tentativas.\n{jogador2.getNome()} Ganhou." + "\nA palavra correta é: " + palavraAEcontrar, "RESULTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"{jogador2.getNome()} gastou todas as tentativas.\n{jogador1.getNome()} Ganhou." + "\nA palavra correta é: " + palavraAEcontrar, "RESULTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        

        private void IniciarJogo()
        {
            try
            {
                //nomes dos jogadores
                Jogador1.Text = jogador1.getNome();
                Jogador2.Text = jogador2.getNome();
                //indica quem comeca
                Jogador1.BackColor = Color.Red;
                Jogador2.BackColor = Color.Black;
                //palavra
                palavraAEcontrar = palavra.NovaPalavra();
                //deixando ela em maiscula
                palavraAEcontrar = palavraAEcontrar.ToUpper();
                arrayPalavraAEncontrar = palavraAEcontrar.ToCharArray();

                palavraAEncontrarPosicaoLetras = new int[palavraAEcontrar.Length];

                input = "";
                palavraAExibir = "";
                for (int i = 0; i < palavraAEcontrar.Length; i++)
                {
                    palavraAExibir += "-";
                }

                letras_Informadas = "";

                label_palavra.Text = palavraAExibir.ToUpper();
                label_letras.Text = letras_Informadas;
                jogador1.setTentativas(5);
                jogador2.setTentativas(5);
                Pontos1.Text = jogador1.getTentativas().ToString();
                Pontos2.Text = jogador2.getTentativas().ToString();
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //volta
        private void Volta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            _player.Stop();
            
            this.Close();
        }
        //jogar de novo
        private void JogarDeNovo_Click(object sender, EventArgs e)
        {
            IniciarJogo();
        }

        private void button_A_Click(object sender, EventArgs e)
        {
            input = "A";
            ChkLtr(input);
        }

        private void button_B_Click(object sender, EventArgs e)
        {
            input = "B";
            ChkLtr(input);
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            input = "C";
            ChkLtr(input);
        }

        private void button_D_Click(object sender, EventArgs e)
        {
            input = "D";
            ChkLtr(input);
        }

        private void button_E_Click(object sender, EventArgs e)
        {
            input = "E";
            ChkLtr(input);
        }

        private void button_F_Click(object sender, EventArgs e)
        {
            input = "F";
            ChkLtr(input);
        }

        private void button_G_Click(object sender, EventArgs e)
        {
            input = "G";
            ChkLtr(input);
        }

        private void button_H_Click(object sender, EventArgs e)
        {
            input = "H";
            ChkLtr(input);
        }

        private void button_I_Click(object sender, EventArgs e)
        {
            input = "I";
            ChkLtr(input);
        }

        private void button_J_Click(object sender, EventArgs e)
        {
            input = "J";
            ChkLtr(input);
        }

        private void button_K_Click(object sender, EventArgs e)
        {
            input = "K";
            ChkLtr(input);
        }

        private void button_L_Click(object sender, EventArgs e)
        {
            input = "L";
            ChkLtr(input);
        }

        private void button_M_Click(object sender, EventArgs e)
        {
            input = "M";
            ChkLtr(input);
        }

        private void button_N_Click(object sender, EventArgs e)
        {
            input = "N";
            ChkLtr(input);
        }

        private void button_O_Click(object sender, EventArgs e)
        {
            input = "O";
            ChkLtr(input);
        }

        private void button_P_Click(object sender, EventArgs e)
        {
            input = "P";
            ChkLtr(input);
        }

        private void button_Q_Click(object sender, EventArgs e)
        {
            input = "Q";
            ChkLtr(input);
        }

        private void button_R_Click(object sender, EventArgs e)
        {
            input = "R";
            ChkLtr(input);
        }

        private void button_S_Click(object sender, EventArgs e)
        {
            input = "S";
            ChkLtr(input);
        }

        private void button_T_Click(object sender, EventArgs e)
        {
            input = "T";
            ChkLtr(input);
        }

        private void button_U_Click(object sender, EventArgs e)
        {
            input = "U";
            ChkLtr(input);
        }

        private void button_V_Click(object sender, EventArgs e)
        {
            input = "V";
            ChkLtr(input);
        }

        private void button_W_Click(object sender, EventArgs e)
        {
            input = "W";
            ChkLtr(input);
        }

        private void button_X_Click(object sender, EventArgs e)
        {
            input = "X";
            ChkLtr(input);
        }

        private void button_Y_Click(object sender, EventArgs e)
        {
            input = "Y";
            ChkLtr(input);
        }

        private void button_Z_Click(object sender, EventArgs e)
        {
            input = "Z";
            ChkLtr(input);
        }

        private void FormJogar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    input = "A";
                    ChkLtr(input);
                    break;
                case Keys.B:
                    input = "B";
                    ChkLtr(input);
                    break;
                case Keys.C:
                    input = "C";
                    ChkLtr(input); 
                    break;
                case Keys.D:
                    input = "D";
                    ChkLtr(input);
                    break;
                case Keys.E:
                    input = "E";
                    ChkLtr(input);
                    break;
                case Keys.F:
                    input = "F";
                    ChkLtr(input);
                    break;
                case Keys.G: 
                    input = "G";
                    ChkLtr(input);
                    break;
                case Keys.H:
                    input = "H";
                    ChkLtr(input);
                    break;
                case Keys.I:
                    input = "I";
                    ChkLtr(input);
                    break;
                case Keys.J:
                    input = "J";
                    ChkLtr(input);
                    break;
                case Keys.K:
                    input = "k";
                    ChkLtr(input);
                    break;
                case Keys.L:
                    input = "L";
                    ChkLtr(input);
                    break;
                case Keys.M:
                    input = "M";
                    ChkLtr(input);
                    break;
                case Keys.N:
                    input = "N";
                    ChkLtr(input);
                    break;
                case Keys.O:
                    input = "O";
                    ChkLtr(input);
                    break;
                case Keys.P:
                    input = "P";
                    ChkLtr(input);
                    break;
                case Keys.Q:
                    input = "Q";
                    ChkLtr(input);
                    break;
                case Keys.R:
                    input = "R";
                    ChkLtr(input);
                    break;
                case Keys.S:
                    input = "S";
                    ChkLtr(input);
                    break;
                case Keys.T:
                    input = "T";
                    ChkLtr(input);
                    break;
                case Keys.U:
                    input = "U";
                    ChkLtr(input);
                    break;
                case Keys.V:
                    input = "V";
                    ChkLtr(input);
                    break;
                case Keys.W:
                    input = "W";
                    ChkLtr(input);
                    break;
                case Keys.X:
                    input = "X";
                    ChkLtr(input);
                    break;
                case Keys.Y:
                    input = "Y";
                    ChkLtr(input);
                    break;
                case Keys.Z:
                    input = "Z";
                    ChkLtr(input);
                    break;
                default:
                    if (vez == false)
                    {
                        MessageBox.Show($"{jogador1.getNome()}, escolha uma letra valida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"{jogador2.getNome()}, escolha uma letra valida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

    }
}
