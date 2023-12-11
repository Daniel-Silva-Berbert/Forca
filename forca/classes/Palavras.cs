using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forca.classes
{
    internal class Palavras
    {

        //gerador randomico numerico para pegar a palavra randomica da lista
        public Random aleatorio = new Random();

        //Collection de palavras
        public List<string> listaPalavras = new List<string> 
        { 
            //20 paises
            "ANGOLA",
            "ARGENTINA",
            "BAHAMAS",
            "BARBADOS",
            "BELIZE",
            "BRASIL",
            "CHILE",
            "CUBA",
            "DOMINICA",
            "EQUADOR",
            "GRANADA",
            "GUATEMALA",
            "GUIANA",
            "HAITI",
            "HONDURAS",
            "JAMAICA",
            "PARAGUAI",
            "PERU",
            "SURINAME",
            "URUGUAI",
            "VENEZUELA"
        };
        public List<int> palavrasIndiceJaUsada = new List<int>();

        public string NovaPalavra()
        {
            bool IsNovaPalavra = false;
            //Palavra padrão
            string temp = "BRASIL";

            try
            {
                while (IsNovaPalavra == false)
                {
                    //pega a palavra randomica da lista de palavras
                    int index = this.aleatorio.Next();

                    index = index % this.listaPalavras.Count;

                    if (!this.palavrasIndiceJaUsada.Exists(e => e == index))
                    {
                        temp = this.listaPalavras[index];
                        this.palavrasIndiceJaUsada.Add(index);
                        IsNovaPalavra = true;
                        break;
                    }
                    else
                    {
                        IsNovaPalavra = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return temp.ToUpper();
        }

    }
}
