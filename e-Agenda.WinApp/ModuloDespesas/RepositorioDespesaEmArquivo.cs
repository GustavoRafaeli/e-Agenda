using e_Agenda.WinApp.ModuloCategoria;
using e_Agenda.WinApp.ModuloContato;
using e_Agenda.WinApp.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloDespesas
{
    public class RepositorioDespesaEmArquivo : RepositorioArquivoBase<Despesa>, IRepositorioDespesa
    {
        public RepositorioDespesaEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {

        }

        public List<Despesa> ListarDespesasPorCategorias(Categoria categoria)
        {
            return ObterRegistros().Where(d => d.CategoriasDaDespesa.Contains(categoria)).ToList();
        }

        public override List<Despesa> ObterRegistros()
        {
            return contextoDados.despesas;
        }
    }
}
