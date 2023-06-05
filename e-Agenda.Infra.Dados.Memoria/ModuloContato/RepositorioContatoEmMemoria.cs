using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.WinApp.ModuloContato
{
    public class RepositorioContatoEmMemoria : RepositorioBaseEmMemoria<Contato>
    {
        public RepositorioContatoEmMemoria(List<Contato> contatos)
        {
            this.listaRegistros = contatos;
        }
    }
}
