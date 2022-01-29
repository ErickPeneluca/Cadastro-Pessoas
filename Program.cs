using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.IO;

namespace projeto
{
    class Program
    {
        static void Main(string[] args)
        {

            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

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
                Console.Clear();
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
                string opcaoPf;
                string opcaoPj;
                switch (resposta)
                {

                    case "1":
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(@$"

=================================================================================
|                       Escolha uma das opcoes abaixo!                          |
|===============================================================================|
|                           1 - Cadastrar Pessoa fisica                         |
|                           2 - Listar Pessoas fisicas                          |
|                           3 - Voltar ao menu                                  |
=================================================================================            
            ");
                            Console.ResetColor();
                            opcaoPf = Console.ReadLine();
                            PessoaFisica pfMetodos = new PessoaFisica();

                            switch (opcaoPf)
                            {
                                case "1":

                                    PessoaFisica novaPf = new PessoaFisica();
                                    Endereco novoEnd = new Endereco();


                                    Console.WriteLine($"Digite o nome");

                                    novaPf.nome = Console.ReadLine();

                                    Console.WriteLine($"Digite o cpf");

                                    novaPf.cpf = Console.ReadLine();



                                    bool dataValida;

                                    do
                                    {
                                        Console.WriteLine($"Digite a data de nascimento Ex: AAAA-MM-DD");
                                        DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                                        dataValida = novaPf.ValidarDataDeNascimento(dataNascimento);
                                        if (novaPf.ValidarDataDeNascimento(dataNascimento))
                                        {
                                            novaPf.dataNascimento = dataNascimento;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Data invalida, por favor digite uma data valida (maior que 18 anos)");
                                            Console.ResetColor();
                                        }
                                    } while (!dataValida);




                                    Console.WriteLine($"Digite o rendimento");

                                    novaPf.rendimento = float.Parse(Console.ReadLine());

                                    Console.WriteLine($"Digite o logradouro");


                                    novoEnd.logradouro = Console.ReadLine();

                                    Console.WriteLine($"Digite o numero");

                                    novoEnd.numero = int.Parse(Console.ReadLine());

                                    Console.WriteLine($"Digite o complemento");

                                    novoEnd.complemento = Console.ReadLine();

                                    Console.WriteLine($"O endereço é comercial ? (S/n)");

                                    string endComercial = Console.ReadLine();

                                    if (endComercial == "S" || endComercial == "s")
                                    {
                                        endComercial = "Comercial";
                                        Console.WriteLine($"{endComercial}");

                                    }
                                    else
                                    {
                                        endComercial = "Residencial";
                                        Console.WriteLine($"{endComercial}");

                                    }

                                    novaPf.endereco = novoEnd;

                                    listaPf.Add(novaPf);


                                    using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                                    {
                                        sw.Write(novaPf);
                                    }
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Essa pessoa foi adicionada com sucesso!");
                                    Console.ResetColor();
                                    break;
                                case "2":
                                    Console.Clear();

                                    if (listaPf.Count == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine($"Por favor insira uma pessoa antes!");
                                        Console.WriteLine($"Pressione enter para continuar");
                                        Console.ReadLine();
                                        Thread.Sleep(2000);
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        foreach (PessoaFisica item in listaPf)
                                        {
                                            Console.WriteLine(@$"

Nome : {item.nome}
Cpf : {item.cpf}
Data de Nascimento : {item.dataNascimento}	
Data valida : {pfMetodos.ValidarDataDeNascimento(item.dataNascimento)}
Rua : {item.endereco.logradouro}
Numero : {item.endereco.numero}
Complemento : {item.endereco.complemento}
Comercial : {item.endereco.enderecoComercial}  
Rendimento: {item.rendimento}
Taxa de rendimento: {pfMetodos.PagarImposto(item.rendimento).ToString("C")}          
");

                                        }
                                    }

                                    Console.WriteLine($"Voce gostaria de ler algum arquivo de texto? (S/n)");

                                    string respostaLerRegistro = Console.ReadLine();

                                    if (respostaLerRegistro == "S" || respostaLerRegistro == "s")
                                    {
                                        Console.WriteLine($"Insira o nome do arquivo");
                                        string nomeDoRegistro = Console.ReadLine();

                                        using (StreamReader sr = new StreamReader(nomeDoRegistro))
                                        {
                                            string linha;

                                            while ((linha = sr.ReadLine()) != null)
                                            {
                                                Console.WriteLine($"{linha}");
                                            }
                                        }
                                    }
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Thread.Sleep(9000);
                                    Console.WriteLine($"Pressione enter para processeguir");
                                    Console.ReadLine();
                                    Console.ResetColor();

                                    break;
                                case "3":

                                    break;
                                default:
                                    Console.WriteLine($"Opcao invalida");
                                    Thread.Sleep(2000);
                                    break;
                            }
                        } while (opcaoPf != "3");



                        Thread.Sleep(2000);

                        break;
                    case "2":
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine(@$"

=================================================================================
|                       Escolha uma das opcoes abaixo!                          |
|===============================================================================|
|                           1 - Cadastrar Pessoa Juridica                       |
|                           2 - Listar Pessoas Juridicas                        |
|                           3 - Voltar ao menu                                  |
=================================================================================            
            ");
                            Console.ResetColor();
                            opcaoPj = Console.ReadLine();
                            PessoaJuridica pjMetodos = new PessoaJuridica();
                            PessoaJuridica novaPj = new PessoaJuridica();
                            switch (opcaoPj)
                            {
                                case "1":


                                    Endereco novoEndPj = new Endereco();

                                    Console.WriteLine($"Digite o nome");

                                    novaPj.nome = Console.ReadLine();



                                    Console.WriteLine($"Digite a razao social");

                                    novaPj.razaoSocial = Console.ReadLine();

                                    bool validarCnpj;

                                    do
                                    {
                                        Console.WriteLine($"Digite um cnpj valido");
                                        string cnpj = Console.ReadLine();
                                        validarCnpj = pjMetodos.ValidarCnpj(cnpj);
                                        if (pjMetodos.ValidarCnpj(cnpj))
                                        {
                                            novaPj.cnpj = cnpj;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"Cnpj Invalido! , por favor insira um cnpj valido");
                                            Console.ResetColor();
                                        }

                                    } while (!validarCnpj);

                                    Console.WriteLine($"Digite o rendimento");

                                    novaPj.rendimento = float.Parse(Console.ReadLine());

                                    Console.WriteLine($"Digite o logradouro");


                                    novoEndPj.logradouro = Console.ReadLine();

                                    Console.WriteLine($"Digite o numero");

                                    novoEndPj.numero = int.Parse(Console.ReadLine());

                                    Console.WriteLine($"Digite o complemento");

                                    novoEndPj.complemento = Console.ReadLine();

                                    Console.WriteLine($"O endereço é comercial ? (S/n)");

                                    string endComercial = Console.ReadLine();

                                    if (endComercial == "S" || endComercial == "s")
                                    {
                                        endComercial = "Comercial";
                                        Console.WriteLine($"{endComercial}");

                                    }
                                    else
                                    {
                                        endComercial = "Residencial";
                                        Console.WriteLine($"{endComercial}");

                                    }

                                    novaPj.endereco = novoEndPj;

                                    pjMetodos.VerificarPastaEArquivo(pjMetodos.caminho);
                                    pjMetodos.Inserir(novaPj);

                                    listaPj.Add(novaPj);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Essa pessoa foi adicionada com sucesso!");
                                    Console.ResetColor();

                                    break;
                                case "2":

                                    Console.Clear();

                                    if (listaPj.Count == 0)
                                    {
                                        List<PessoaJuridica> listaPjMet = pjMetodos.Ler();
                                        if (listaPjMet.Count > 0)
                                        {
                                            foreach (PessoaJuridica cadaPJ in listaPjMet)
                                            {
                                                Console.WriteLine($@"
                                                           
        nome {cadaPJ.nome}
        razao social {cadaPJ.razaoSocial}
        cnpj {cadaPJ.cnpj}
                                                ");

                                                // preciso reswolver esse b.o
                                                                                
                                            }
                                        } else
                                        {
                                            Console.WriteLine($"Lista vazia!");
                                            
                                        }
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine($"Pressione enter para continuar");
                                        Console.ReadLine();
                                        Thread.Sleep(2000);
                                        Console.ResetColor();


                                    }
                                    else
                                    {
                                        foreach (var item in listaPj)
                                        {
                                            Console.WriteLine(@$"
                                                        
                
    Nome : {item.nome}
    Cnpj : {item.cnpj}
    Razao social : {item.razaoSocial}            
    Rua : {item.endereco.logradouro} 
    Numero : {item.endereco.numero}                           
    Complemento : {item.endereco.complemento}                                          
    Comercial : {item.endereco.enderecoComercial}
    rendimento:{item.rendimento}    
    Taxa de imposto:{pjMetodos.PagarImposto(item.rendimento).ToString("C")}          
                
                ");
                                        }
                                        Thread.Sleep(2000);
                                        Console.WriteLine($"Pressione enter para continuar...");
                                        Console.ReadLine();
                                    }

                                    break;
                                case "3":

                                    break;
                                default:
                                    Console.WriteLine($"Opcao invalida");

                                    break;
                            }



                        } while (opcaoPj != "3");











                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(@$"
                    
                    
                    ");
                        Console.WriteLine($"                        Obrigado por utilizar nosso sistema         ");
                        System.Console.WriteLine();
                        BarraCarregamento("FInalizando");
                        Console.Clear();
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