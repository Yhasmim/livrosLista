using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrosLista
{
    class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        public Emprestimo(DateTime a, DateTime b)
        {
            this.dtEmprestimo = a;
            this.dtDevolucao = b;
        }

        public DateTime DtEmprestimo
        {
            get {return this.dtEmprestimo; }
            set {this.dtDevolucao = value; }
        }

        public DateTime DtDevolucao
        {
            get { return this.dtDevolucao; }
            set { this.dtDevolucao = value; }
        }

    }
}
