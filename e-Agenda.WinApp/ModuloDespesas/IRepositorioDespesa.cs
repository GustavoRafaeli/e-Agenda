using e_Agenda.WinApp.ModuloCategoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloDespesas
{
    public interface IRepositorioDespesa : IRepositorioBase<Despesa>
    {
        public List<Despesa> ListarDespesasPorCategorias(Categoria categoria);
    }
}
