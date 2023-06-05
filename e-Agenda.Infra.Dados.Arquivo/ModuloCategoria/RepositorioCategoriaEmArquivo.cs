using e_Agenda.Dominio.ModuloCategoria;

namespace e_Agenda.Infra.Dados.Arquivo.ModuloCategoria
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
