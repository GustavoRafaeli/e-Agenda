using e_Agenda.WinApp.Compartilhado;

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
