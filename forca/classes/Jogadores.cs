using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forca.classes
{
    internal class Jogadores
    {
        private int tentativas = 0;
        private string nome;

        public Jogadores(string nome)
        {
            setNome(nome);
        }


        //Gets e Sets
        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getNome()
        {
            return this.nome;
        }

        public void setTentativas(int numero)
        {
            this.tentativas = numero;
        }

        public int getTentativas()
        {
            return tentativas;
        }
    }
}
