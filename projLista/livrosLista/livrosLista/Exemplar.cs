using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrosLista
{
    class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;

        public Exemplar()
        {
            
            this.emprestimos = new List<Emprestimo>();
        }

        public Exemplar(int a)
        {
            this.tombo = a;
            this.emprestimos = new List<Emprestimo>();
        }

        public int Tombo
        {
            get { return this.tombo; }
            set { this.tombo = value; }
        }

        public List<Emprestimo> Emprestimos
        {
            get { return this.emprestimos; }
            set { this.emprestimos = value; }
        }


        public bool emprestar()
        {
            if (this.disponivel())
            {
                this.emprestimos.Add(new Emprestimo(DateTime.Now, new DateTime()));
                return true;
            }
            return false;
        }

        public bool devolver()
        {
            if (!this.disponivel())
            {
                this.emprestimos[this.emprestimos.Count - 1].DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool disponivel()
        {         
            return (this.qtdeEmprestimos() == 0 || this.emprestimos[this.qtdeEmprestimos() - 1].DtDevolucao > DateTime.MinValue);
        }

        public int qtdeEmprestimos()
        {
            return this.emprestimos.Count();
        }

        public override bool Equals(Object obj)
        {
            if (obj.GetType() == this.GetType())
                return this.tombo == ((Exemplar)obj).Tombo;
            return false;
        }

    }
}
