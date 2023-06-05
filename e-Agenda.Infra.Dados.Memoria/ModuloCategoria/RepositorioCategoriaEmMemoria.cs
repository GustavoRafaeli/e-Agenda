using e_Agenda.Dominio.ModuloCategoria;

namespace e_Agenda.Infra.Dados.Memoria.ModuloCategoria
{
    public class RepositorioCategoriaEmMemoria : RepositorioBaseEmMemoria<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaEmMemoria(List<Categoria> listaCategorias)
        {
            listaRegistros = listaCategorias;
        }
    }
}
