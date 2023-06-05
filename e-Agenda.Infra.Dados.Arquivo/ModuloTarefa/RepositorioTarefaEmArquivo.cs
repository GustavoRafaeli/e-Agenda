using e_Agenda.Dominio.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.Infra.Dados.Arquivo.ModuloTarefa
{
    public class RepositorioTarefaEmArquivo : RepositorioArquivoBase<Tarefa>, IRepositorioTarefa
    {
        public RepositorioTarefaEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {
        }

        public List<Tarefa> SelecionarConcluidas()
        {
            return ObterRegistros()
                    .Where(x => x.percentualConcluido == 100)
                    .ToList();
        }

        public List<Tarefa> SelecionarPendentes()
        {
            return ObterRegistros()
                    .Where(x => x.percentualConcluido < 100)
                    .ToList();
        }

        public List<Tarefa> SelecionarTodosOrdenadosPorPrioridade()
        {
            return ObterRegistros()
                    .OrderByDescending(x => x.prioridade)
                    .ToList();
        }

        public override List<Tarefa> ObterRegistros()
        {
            return contextoDados.tarefas;
        }
    }
}

