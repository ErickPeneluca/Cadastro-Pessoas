using System;

namespace projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoaFisica pfMetodos = new PessoaFisica();

            PessoaFisica novaPf = new PessoaFisica();

            Endereco novoEnd = new Endereco();

            novaPf.dataNascimento = new DateTime (2003,01,07);
            novaPf.nome = "Erick";
            novaPf.cpf = "512.132.124-90";

            novoEnd.logradouro = "Avenida Brasil";
            novoEnd.numero = 777;
            novoEnd.complemento = "Carminha floricultura";
            novoEnd.enderecoComercial = true;
            
            novaPf.endereco = novoEnd;
            novaPf.rendimento = 5000.00f;

    
            Console.WriteLine(@$"
            Nome : {novaPf.nome}
            Cpf : {novaPf.cpf}
            Data de Nascimento : {novaPf.dataNascimento}	
            {pfMetodos.ValidarDataDeNascimento(novaPf.dataNascimento)}
            Rua : {novaPf.endereco.logradouro}
            Numero : {novaPf.endereco.numero}
            Complemento : {novaPf.endereco.complemento}
            Comercial : {novaPf.endereco.enderecoComercial}            
            ");
        }
    }
}
