using System;
using System.Threading;

namespace projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@$"
==============================================================================
|            Bem vindo ao sistema de cadastro de Pessoas fisicas e juridicas |
|                                                                            |
|                                   :)                                       |
==============================================================================
            ");


            BarraCarregamento("Carregando");

            string resposta;

            Console.ResetColor();
            do
            {
                Console.WriteLine(@$"


=================================================================================
|                       Escolha uma das opcoes abaixo!                          |
|===============================================================================|
|                           1 - Pessoa Fisica                                   |
|                           2 - Pessoa Juridica                                 |
|                           3 - Sair                                            |
=================================================================================            
            ");

                resposta = Console.ReadLine();

                switch (resposta)
                {
                    case "1":
                        PessoaFisica pfMetodos = new PessoaFisica();

                        PessoaFisica novaPf = new PessoaFisica();

                        Endereco novoEnd = new Endereco();

                        novaPf.dataNascimento = new DateTime(2003, 01, 07);
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
    Data valida : {pfMetodos.ValidarDataDeNascimento(novaPf.dataNascimento)}
    Rua : {novaPf.endereco.logradouro}
    Numero : {novaPf.endereco.numero}
    Complemento : {novaPf.endereco.complemento}
    Comercial : {novaPf.endereco.enderecoComercial}            
        ");
                        Thread.Sleep(2000);

                        break;
                    case "2":
                        PessoaJuridica pjMetodos = new PessoaJuridica();

                        PessoaJuridica novaPj = new PessoaJuridica();

                        Endereco novoEndPj = new Endereco();


                        novaPj.razaoSocial = "Nova pj";
                        novaPj.nome = "Henrico";
                        novaPj.cnpj = "01362776000114";

                        novoEndPj.logradouro = "Avenida Alemanha";
                        novoEndPj.numero = 212;
                        novoEndPj.complemento = "JOrginha floricultura";
                        novoEndPj.enderecoComercial = true;

                        novaPj.endereco = novoEndPj;
                        novaPj.rendimento = 5000.00f;

                        Console.WriteLine(@$"

                

    Nome : {novaPj.nome}
    Cnpj : {novaPj.cnpj}
    Razao social : {novaPj.razaoSocial}	              
    Cnpj valido : {pjMetodos.ValidarCnpj(novaPj.cnpj)}              
    Rua : {novaPj.endereco.logradouro} 
    Numero : {novaPj.endereco.numero}                           
    Complemento : {novaPj.endereco.complemento}                                          
    Comercial : {novaPj.endereco.enderecoComercial}              
                ");
                        Thread.Sleep(2000);
                        break;
                    case "3":
                        Console.WriteLine($"                        Obrigado por utilizar nosso sistema         ");
                        System.Console.WriteLine();
                        BarraCarregamento("FInalizando");
                        break;
                    default:
                        Console.WriteLine($"Opcao invalida por favor digite uma opcao valida");
                        Thread.Sleep(2000);
                        break;
                }
            } while (resposta != "3");
        }
        static void BarraCarregamento(string texto)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write($"{texto} . . . . . . . . . . . .");
            Thread.Sleep(500);

            for (var i = 0; i < 6; i++)
            {
                Console.Write(" . . . . ");
                Thread.Sleep(500);
            }
        }
    }
}