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
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                float taxa = (rendimento / 100) * 2;
                return taxa;
            }
            else if (rendimento > 3500 && rendimento <= 6000)
            {
                float taxa = (rendimento / 100) * 3.5f;
                return taxa;
            }
            else
            {
                float taxa = (rendimento / 100) * 5;
                return taxa;
            }
        }
        public override string ToString()
        {
            return @$"
            Nome : {nome},
            Cpf : {cpf},
            Data de Nascimento : {dataNascimento},
            Data valida : {ValidarDataDeNascimento(dataNascimento)},
            Rua : {endereco.logradouro},
            Numero : {endereco.numero},
            Complemento : {endereco.complemento},
            Comercial : {endereco.enderecoComercial},
            Rendimento: {rendimento},
            Taxa de rendimento: {PagarImposto(rendimento).ToString("C")}

            ";
        }

    }
}