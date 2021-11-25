using System;
namespace projeto
{
    public class PessoaFisica : Pessoa
    {

        public string cpf { get; set; }

        public DateTime dataNascimento { get; set; }

        public bool ValidarDataDeNascimento(DateTime dataNasc)
        {    
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if (anos >= 18)
            {
                return true;
            }
            return false;
        }

        public override float PagarImposto(float rendimento)
        {
            throw new System.NotImplementedException();
        }
    }
}