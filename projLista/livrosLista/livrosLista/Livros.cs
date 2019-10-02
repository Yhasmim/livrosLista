using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrosLista
{
    class Livros
    {
       private List<Livro> acervo;
       public List<Livro> Acervo { get => acervo; set => acervo = value; }

        public Livros()
        {
            this.acervo = new List<Livro>();
        }

        public void adicionar(Livro a)
        {
            this.acervo.Add(a);
        }

        public Livro pesquisar(Livro a)
        {
            return this.acervo.FirstOrDefault(item => item.Equals(a));
        }
    }
}
