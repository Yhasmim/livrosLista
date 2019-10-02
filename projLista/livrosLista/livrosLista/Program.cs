using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrosLista
{
    class Program
    {
        static Livros lvs = new Livros();
        static void Main(string[] args)
        {
            
            int opc;
            do
            {

                Console.WriteLine("------------------- MENU -------------------");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Pesquisar Livro (sintético)");
                Console.WriteLine("3. Pesquisar Livro (analítico)");
                Console.WriteLine("4. Adicionar Exemplar");
                Console.WriteLine("5. Resgistrar Empréstimo");
                Console.WriteLine("6. Resgistrar Devolução");
                Console.WriteLine("\nDigite uma opção: ");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 0:
                        Console.Write("Programa finalizado!");
                        break;

                    case 1:
                        adicionarLivro();
                        break;

                    case 2:
                        listaSintetica();
                        break;

                    case 3:
                        listaAnalitica();
                        break;

                    case 4:
                        adicionarExemplar();
                        break;

                    case 5:
                        registrarEmprestimo();
                        break;

                    case 6:
                        registrarDevolucao();
                        break;

                    default:
                        Console.Write("Opção invalida, digite novamente: ");
                        break;
                } //switch

            } while (opc != 0);
            Console.ReadKey();
        }

        static void adicionarLivro()
        {
            int isbnA;
            string titulo;
            string autor;
            string editora;

            Console.WriteLine("\n Adicionar Livro . . .  ");
            Console.Write("Insira o Isbn do Livro:  ");
            isbnA = int.Parse(Console.ReadLine());
            if (lvs.pesquisar(new Livro(isbnA)) != null) throw new Exception("Já existe um livro com esse ISBN");
            Console.Write("Insira a Titulo: ");
            titulo = Console.ReadLine();
            Console.Write("Insira a Autor:  ");
            autor = Console.ReadLine();
            Console.Write("Insira a Editora: ");
            editora = Console.ReadLine();
            lvs.adicionar(new Livro(isbnA, titulo, autor, editora));
            Console.WriteLine("Exemplar cadastrado com sucesso!");
        }

        static void listaSintetica()
        {
            Console.Write("Informe o ISBN: ");
            int isbnB = int.Parse(Console.ReadLine());
            Livro livro = lvs.pesquisar(new Livro(isbnB));
            if (livro == null) throw new Exception("Livro não encontrado.");

            Console.WriteLine("Total de Exemplares: " + livro.qtdeExemplares());
            Console.WriteLine("Total de Exemplares disponíveis: " + livro.qtdeDisponiveis());
            Console.WriteLine("Total de empréstimos: " + livro.qtdeEmprestimos());
            Console.WriteLine("Percentual de disponibilidade: " + livro.percDisponibilidade().ToString("0.00") + "%");
        }

        static void listaAnalitica()
        {
            Console.Write("\nDigite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());
            Livro livroB = lvs.pesquisar(new Livro(isbn));
            if (livroB == null) throw new Exception("Livro não encontrado.");

            Console.WriteLine("Total de exemplares: " + livroB.qtdeExemplares());
            Console.WriteLine("Total de exemplares disponíveis: " + livroB.qtdeDisponiveis());
            Console.WriteLine("Total de empréstimos: " + livroB.qtdeEmprestimos());
            Console.WriteLine("Percentual de disponibilidade: " + livroB.percDisponibilidade().ToString("0.00") + "%");

            livroB.Exemplares.ForEach(i => {
                Console.WriteLine("=========================================================");
                Console.WriteLine("Tombo: " + i.Tombo);
                i.Emprestimos.ForEach(j => {
                    String devolucao = (j.DtDevolucao != DateTime.MinValue) ? j.DtDevolucao.ToString() : "-------------------";
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Data Empréstimo: " + j.DtEmprestimo);
                    Console.WriteLine("Data Devolução:  " + devolucao);
                });
            });
        }

        static void adicionarExemplar()
        {
            Console.Write("\nDigite o ISBN: ");
            int isbnC = Int32.Parse(Console.ReadLine());

            Livro livroC = lvs.pesquisar(new Livro(isbnC));
            if (livroC == null) { throw new Exception("Livro não encontrado."); Console.ReadKey(); }

            Console.Write("Digite o Tombo: ");
            int tombo = Int32.Parse(Console.ReadLine());
            livroC.adicionarExemplar(new Exemplar(tombo));
            Console.WriteLine("Exemplar cadastrado com sucesso!");
            Console.ReadKey();
        }
        static void registrarEmprestimo()
        {
            Console.Write("\nDigite o ISBN: ");
            int isbnD = Int32.Parse(Console.ReadLine());

            Livro livroD = lvs.pesquisar(new Livro(isbnD));
            if (livroD == null) throw new Exception("Livro não encontrado.");

            Exemplar exemplar = livroD.Exemplares.FirstOrDefault(i => i.emprestar());
            if (exemplar != null) Console.WriteLine("Exemplar " + exemplar.Tombo + " emprestado com sucesso!");
            else throw new Exception("Não há exemplares disponíveis.");


        }
        static void registrarDevolucao()
        {
            Console.Write("\nDigite o ISBN: ");
            int isbnE = Int32.Parse(Console.ReadLine());

            Livro livroE = lvs.pesquisar(new Livro(isbnE));
            if (livroE == null) throw new Exception("Livro não encontrado.");

            Exemplar exemplarE = livroE.Exemplares.FirstOrDefault(i => i.devolver());
            if (exemplarE != null) Console.WriteLine("Exemplar " + exemplarE.Tombo + " devolvido com sucesso!");
            else Console.WriteLine("Não há exemplares emprestados.");

        }

    }//class 
}
