﻿using e_Agenda.WinApp.ModuloCategoria;
using e_Agenda.WinApp.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloDespesas
{
    public class ControladorDespesa : ControladorBase
    {
        IRepositorioDespesa repositorioDespesa;
        ListagemDespesaControl listagemDespesa;
        IRepositorioCategoria repositorioCategoria;
        public ControladorDespesa(IRepositorioDespesa repositorioDespesa, IRepositorioCategoria repositorioCategoria)
        {
            this.repositorioDespesa = repositorioDespesa;
            this.repositorioCategoria = repositorioCategoria;
        }

        public override string ToolTipInserir => "Inserir Nova Despesa";

        public override string ToolTipEditar => "Editar Despesa";

        public override string ToolTipExcluir => "Excluir Despesa";

        public override void Inserir()
        {
            TelaDespesaForm telaDespesa = new TelaDespesaForm(repositorioCategoria.SelecionarTodos());

            DialogResult opcaoEscolhida = telaDespesa.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Despesa novaDespesa = telaDespesa.ObterDespesa();

                repositorioDespesa.Inserir(novaDespesa);

            }

            CarregarDespesas();
        }
        public void CarregarDespesas()
        {
            List<Despesa> despesas = repositorioDespesa.SelecionarTodos();

            listagemDespesa.AtualizarRegistros(despesas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {despesas.Count} despesa(s)");
        }

        public override void Editar()
        {
            Despesa despesaSelecionada = listagemDespesa.ObterDespesaSelecionada();


            if(despesaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro", "Edição de Tarefa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaDespesaForm telaDespesa = new TelaDespesaForm(repositorioCategoria.SelecionarTodos());

            telaDespesa.ConfigurarTela(despesaSelecionada);

            DialogResult opcaoEscolhida = telaDespesa.ShowDialog();

            if(opcaoEscolhida == DialogResult.OK)
            {
                Despesa despesa = telaDespesa.ObterDespesa();

                repositorioDespesa.Editar(despesa.id, despesa);

                CarregarDespesas();
            }
        }
        public override void Excluir()
        {
            Despesa despesa = listagemDespesa.ObterDespesaSelecionada();

            if (despesa == null)
            {
                MessageBox.Show($"Selecione uma despesa primeiro!",
                    "Exclusão de despesas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a despesa {despesa.Descricao}?", "Exclusão de Despesas",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioDespesa.Excluir(despesa);

                CarregarDespesas();
            }
        }

        public override UserControl ObterListagem()
        {
            if(listagemDespesa == null)
            {
                listagemDespesa = new ListagemDespesaControl();
            }

            CarregarDespesas();

            return listagemDespesa;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro Despesas";
        }
    }
}
