using e_Agenda.Dominio.ModuloCategoria;
using e_Agenda.Dominio.ModuloDespesas;

namespace e_Agenda.Infra.Dados.Arquivo.ModuloDespesas
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
