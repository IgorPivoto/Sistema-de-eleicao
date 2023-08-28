using System;
using System.Collections.Generic;

namespace testedoSr.andery
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomeCandidato;
            List<string> Candidatos = new List<string>();
            int[] votos = new int[100];
            int menuPrincipal;
            int eleição = 1;
            bool trancaCandidato = false;
            bool trancaEleição = false;

            while (true)
            {
                Console.WriteLine("1=> Cadastrar candidato <=1");
                Console.WriteLine("2=> Atualizar quantidade de eleitores <=2");
                Console.WriteLine("3=> Pesquisar candidato <=3");
                Console.WriteLine("4=> Votar <=4");
                Console.WriteLine("5=> Apresentar resultados da eleição <=5");
                menuPrincipal = int.Parse(Console.ReadLine());

                switch (menuPrincipal)
                {
                    case 1:

                        if (trancaCandidato == true)
                        {
                            Console.WriteLine("Essa opção esta bloqueada");
                        }
                        else
                        {
                            Console.WriteLine("Digite o nome do candidato que você quer cadastrar: ");
                            nomeCandidato = Console.ReadLine();
                            if (Candidatos.Contains(nomeCandidato))
                            {
                                Console.WriteLine("Esse candidato ja foi adicionado!");
                            }
                            else
                            {
                                Candidatos.Add(nomeCandidato);
                                Console.WriteLine("Candidato cadastrado!");
                            }
                        }
                        break;

                    case 2:
                        if (trancaEleição == true)
                        {
                            Console.WriteLine("Essa opção esta bloqueada");
                        }
                        else
                        {
                            Console.WriteLine("A quantidade de eleitores é: " + eleição);
                            Console.Write("Digite a nova quantidade de eleitores: ");
                            eleição = int.Parse(Console.ReadLine());
                        }

                        break;

                    case 3:
                        Console.WriteLine("1=> Ver lista de candidato <=1");
                        Console.WriteLine("2=> Pesquisar nome do candidato <=2");
                        int MenuPesquisaCandidato = int.Parse(Console.ReadLine());
                        switch (MenuPesquisaCandidato)
                        {
                            case 1:
                                Console.WriteLine("A lista de candidatos é: ");
                                Candidatos.ForEach(Console.WriteLine);
                                break;
                            case 2:
                                Console.WriteLine("Digite o nome do candidato que você quer pesquisar: ");
                                nomeCandidato = Console.ReadLine();
                                int P = Candidatos.IndexOf(nomeCandidato);
                                if (P == -1)
                                {
                                    Console.WriteLine("Candidato não existe ou não foi encontrado, verifique se escreveu corretamente.");
                                }
                                else
                                {
                                    Console.WriteLine("O número do candidato é {0}.", P + 1);
                                    Console.ReadLine();
                                }

                                break;
                        }
                        break;

                    case 4:

                        if (eleição == 0)
                        {
                            Console.WriteLine("Todos os eleitores ja votaram!");

                        }
                        else if (eleição > 0)
                        {
                            int p = 1;

                            Console.WriteLine("Todos os candidatos cadastrados estão nas linhas a baixo: ");
                            foreach (string nomes in Candidatos)
                            {
                                Console.WriteLine(p + "=> " + nomes + " <=" + p);
                                p++;
                            }
                            for (int i = 0; i < eleição; i++)
                            {
                                Console.WriteLine("Escolha o número do candidato para votar.");
                                int vt = int.Parse(Console.ReadLine());
                                votos[vt - 1]++;
                            }
                            trancaCandidato = true;
                            trancaEleição = true;
                            eleição = 0;
                        }
                        break;

                    case 5:
                        for (int i = 0; i < Candidatos.Count; i++)
                        {
                            int votosCandidato = votos[i];
                            if (votosCandidato > 0)
                            {
                                Console.WriteLine("O candidato(a) " + Candidatos[i] + " teve " + votosCandidato + " votos");
                            }
                        }
                        break;
                }
            }
        }
    }
}