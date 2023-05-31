using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloTarefa
{
    public interface IRepositorioTarefa : IRepositorioBase<Tarefa>
    {
        List<Tarefa> SelecionarConcluidas();
        List<Tarefa> SelecionarPendentes();
        List<Tarefa> SelecionarTodosOrdenadosPorPrioridade();
    }
}
