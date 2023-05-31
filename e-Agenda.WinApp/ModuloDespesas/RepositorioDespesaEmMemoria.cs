﻿using e_Agenda.WinApp.ModuloCategoria;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloDespesas
{
    public class RepositorioDespesaEmMemoria : RepositorioBaseEmMemoria<Despesa>
    {
        public RepositorioDespesaEmMemoria(List<Despesa> listaDespesas)
        {
            this.listaRegistros = listaDespesas;
        }

        public List<Despesa> ListarDespesasPorCategorias(Categoria categoria)
        {
            return listaRegistros.Where(d => d.CategoriasDaDespesa.Contains(categoria)).ToList();
        }
    }
}
