using e_Agenda.WinApp.ModuloCompromisso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloCategoria
{
    public class RepositorioCategoriaEmArquivo : RepositorioArquivoBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaEmArquivo(List<Categoria> categorias)
        {
            NOME_ARQUIVO = "C:\\Users\\Itachi\\Desktop\\C#Projects\\e-Agenda-2023-master\\Arquivos\\categoria-bin";

            listaRegistros = categorias;

            if (File.Exists(NOME_ARQUIVO))
                CarregarRegistrosDoArquivo();
        }
    }
}
