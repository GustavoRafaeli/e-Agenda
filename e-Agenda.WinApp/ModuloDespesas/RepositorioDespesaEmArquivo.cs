using e_Agenda.WinApp.ModuloCategoria;
using e_Agenda.WinApp.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloDespesas
{
    public class RepositorioDespesaEmArquivo : RepositorioArquivoBase<Despesa>, IRepositorioDespesa
    {
        public RepositorioDespesaEmArquivo(List<Despesa> despesas)
        {
            NOME_ARQUIVO = "C:\\Users\\Itachi\\Desktop\\C#Projects\\e-Agenda-2023-master\\Arquivos\\despesa-bin";

            listaRegistros = despesas;

            if (File.Exists(NOME_ARQUIVO))
                CarregarRegistrosDoArquivo();
        }
        public List<Despesa> ListarDespesasPorCategorias(Categoria categoria)
        {
            return listaRegistros.Where(d => d.CategoriasDaDespesa.Contains(categoria)).ToList();
        }
    }
}
