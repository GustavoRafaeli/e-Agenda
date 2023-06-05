using e_Agenda.Dominio.ModuloCategoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.Dominio.ModuloDespesas
{
    public interface IRepositorioDespesa : IRepositorioBase<Despesa>
    {
        public List<Despesa> ListarDespesasPorCategorias(Categoria categoria);
    }
}
