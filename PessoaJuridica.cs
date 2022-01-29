using System.Collections.Generic;
using System.IO;

namespace projeto
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string razaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.05f;
            }
            else if (rendimento > 6000 && rendimento <= 10000)
            {
                return rendimento * 0.07f;
            }
            else
            {
                return rendimento * 0.09f;
            }
        }

        public bool ValidarCnpj(string cnpj)
        {

            if (cnpj.Length == 14 && cnpj.Substring(8, 4) == "0001")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string PrepararLinhaCsv(PessoaJuridica pj)
        {
            return $"{pj.nome};{pj.razaoSocial};{pj.cnpj}";
        }

        public void Inserir(PessoaJuridica pj)
        {

            string[] linhas = {PrepararLinhaCsv(pj)};

            File.AppendAllLines(caminho, linhas);
        }

        public List<PessoaJuridica> Ler()
        {
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");

                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.nome = atributos[0];
                cadaPj.razaoSocial = atributos[1];
                cadaPj.cnpj = atributos[2];

                listaPj.Add(cadaPj);
            }

            return listaPj;
        }

        
    }
}