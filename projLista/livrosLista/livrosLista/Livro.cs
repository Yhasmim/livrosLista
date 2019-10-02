using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrosLista
{
    class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;
        public List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro(int i)
        {
            this.isbn = i;
        }

        public Livro(int a, string b, string c, string d)
        {
            this.isbn = a;
            this.titulo = b;
            this.autor = c;
            this.editora = d;
            this.exemplares = new List<Exemplar>();
        }

        public void adicionarExemplar(Exemplar p)
        {
            this.exemplares.Add(p);
        }

        public int qtdeExemplares()
        {
            return this.exemplares.Count();
        }

        public int qtdeDisponiveis()
        {
            int disponiveis = 0;
            this.exemplares.ForEach(item => { if (item.disponivel()) disponiveis++; });
            return disponiveis;
        }

        public int qtdeEmprestimos()
        {
            int emprestados = 0;
            this.exemplares.ForEach(item => emprestados += item.qtdeEmprestimos());
            return emprestados;
        }

        public double percDisponibilidade()
        {
            double exemp = this.qtdeExemplares();
            double disp = this.qtdeDisponiveis();
            return (exemp == 0 || disp == 0) ? 0 : (disp / exemp) * 100;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
                return this.isbn.Equals(((Livro)obj).isbn);
            return false;
        }

    }
}
