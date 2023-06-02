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
        //protected override string ObterNomeArquivo()
        //{
        //    return "ModuloContato/Contatos.json";
        //}
        public RepositorioContatoEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {

        }

        public override List<Contato> ObterRegistros()
        {
            return contextoDados.contatos;
        }
    }
}
