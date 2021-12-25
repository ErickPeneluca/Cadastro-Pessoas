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
            ..// Pessoa Fisica  ..//

            Nome : {novaPf.nome}
            Cpf : {novaPf.cpf}
            Data de Nascimento : {novaPf.dataNascimento}	
            Data valida : {pfMetodos.ValidarDataDeNascimento(novaPf.dataNascimento)}
            Rua : {novaPf.endereco.logradouro}
            Numero : {novaPf.endereco.numero}
            Complemento : {novaPf.endereco.complemento}
            Comercial : {novaPf.endereco.enderecoComercial}            
            ..// ... ..//");


            // OBJETO PESSOA JURIDICA

            PessoaJuridica pjMetodos = new PessoaJuridica();

            PessoaJuridica novaPj = new PessoaJuridica();
            
            Endereco novoEndPj = new Endereco();


            novaPj.razaoSocial = "Nova pj" ;
            novaPj.nome = "Henrico";
            novaPj.cnpj = "01362776000114";

            novoEndPj.logradouro = "Avenida Alemanha";
            novoEndPj.numero = 212;
            novoEndPj.complemento = "JOrginha floricultura";
            novoEndPj.enderecoComercial = true;
            
            novaPj.endereco = novoEnd;
            novaPj.rendimento = 5000.00f;

            Console.WriteLine(@$"
            ..// Pessoa Juridica  ..//

            Nome : {novaPj.nome}
            Cnpj : {novaPj.cnpj}
            Razao social : {novaPj.razaoSocial}	
            Cnpj valido : {pjMetodos.ValidarCnpj(novaPj.cnpj)}
            Rua : {novaPj.endereco.logradouro}
            Numero : {novaPj.endereco.numero}
            Complemento : {novaPj.endereco.complemento}
            Comercial : {novaPj.endereco.enderecoComercial}            
            ..// ... ..//");
        }
    }
}
