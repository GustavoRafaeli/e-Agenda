using e_Agenda.WinApp.ModuloDespesas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloContato
{
    public class RepositorioContatoEmArquivo : RepositorioArquivoBase<Contato>, IRepositorioContato
    {
        public RepositorioContatoEmArquivo(List<Contato> contatos)
        {
            NOME_ARQUIVO = "C:\\Users\\Itachi\\Desktop\\C#Projects\\e-Agenda-2023-master\\Arquivos\\contato-bin";

            listaRegistros = contatos;

            if (File.Exists(NOME_ARQUIVO))
                CarregarRegistrosDoArquivo();
        }
    }
}
