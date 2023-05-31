using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloTarefa
{
    public class RepositorioTarefaEmArquivo : RepositorioArquivoBase<Tarefa>, IRepositorioTarefa
    {
        public RepositorioTarefaEmArquivo(List<Tarefa> tarefas)
        {
            NOME_ARQUIVO = "C:\\temp\\tarefas\\dados-tarefas.bin";

            listaRegistros = tarefas;

            if (File.Exists(NOME_ARQUIVO))
                CarregarRegistrosDoArquivo();
        }

        public List<Tarefa> SelecionarConcluidas()
        {
            return listaRegistros
                    .Where(x => x.percentualConcluido == 100)
                    .ToList();
        }

        public List<Tarefa> SelecionarPendentes()
        {
            return listaRegistros
                    .Where(x => x.percentualConcluido < 100)
                    .ToList();
        }

        public List<Tarefa> SelecionarTodosOrdenadosPorPrioridade()
        {
            return listaRegistros
                    .OrderByDescending(x => x.prioridade)
                    .ToList();
        }

    }
}

