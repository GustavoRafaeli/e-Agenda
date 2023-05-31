using e_Agenda.WinApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloCompromisso
{
    public class RepositorioCompromissoEmArquivo : RepositorioArquivoBase<Compromisso>, IRepositorioCompromisso
    {
        public RepositorioCompromissoEmArquivo(List<Compromisso> compromissos)
        {
            NOME_ARQUIVO = "C:\\Users\\Itachi\\Desktop\\C#Projects\\e-Agenda-2023-master\\Arquivos\\compromisso-bin";

            listaRegistros = compromissos;

            if (File.Exists(NOME_ARQUIVO))
                CarregarRegistrosDoArquivo();
        }

        public List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicio, DateTime dataFinal)
        {
            return listaRegistros
                .Where(x => x.data > dataInicio)
                .Where(x => x.data < dataFinal)
                .ToList();
        }

        public List<Compromisso> SelecionarCompromissosPassados(DateTime hoje)
        {
            return listaRegistros.Where(x => x.data.Date < hoje.Date).ToList();
        }
    }
}
