using e_Agenda.WinApp.ModuloCompromisso;
using e_Agenda.WinApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloCategoria
{
    public class RepositorioCategoriaEmArquivo : RepositorioArquivoBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {

        }

        public override List<Categoria> ObterRegistros()
        {
            return contextoDados.categorias;
        }
    }
}
