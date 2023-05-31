using e_Agenda.WinApp.ModuloCategoria;
using e_Agenda.WinApp.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Agenda.WinApp.ModuloDespesas
{
    public partial class TelaDespesaForm : Form
    {
        RepositorioCategoriaEmMemoria repositorioCategoria;

        public TelaDespesaForm(List<Categoria> categorias)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            ConfigurarFormaPagamento();
            ConfigurarListaCategorias(categorias);
        }
        public void ConfigurarFormaPagamento()
        {
            FormaPagamentoEnum[] formaPagamentos = Enum.GetValues<FormaPagamentoEnum>();

            foreach (FormaPagamentoEnum formaPagamento in formaPagamentos)
            {
                cmbFormaPagamento.Items.Add(formaPagamento);
            }
        }
        public Despesa ObterDespesa()
        {
            int id = Convert.ToInt32(txtId.Text);
            string descricao = txtDescricao.Text;
            decimal valor = Convert.ToDecimal(txtValor.Text);
            DateTime data = Convert.ToDateTime(txtData.Value);
            FormaPagamentoEnum formaPagamento = (FormaPagamentoEnum)cmbFormaPagamento.SelectedItem;

            
            Despesa despesa = new Despesa(descricao, valor, data, formaPagamento);
            despesa.id = id;

            despesa.CategoriasDaDespesa.AddRange(chListCategorias.CheckedItems.Cast<Categoria>());

            return despesa;
        }
        public void ConfigurarTela(Despesa despesaSelecionada)
        {
            txtId.Text = despesaSelecionada.id.ToString();
            txtDescricao.Text = despesaSelecionada.Descricao;
            txtValor.Text = despesaSelecionada.Valor.ToString();
            txtData.Value = despesaSelecionada.Data;
            cmbFormaPagamento.SelectedItem = despesaSelecionada.TipoPagamento;

            int i = 0;

            for (int j = 0; j < chListCategorias.Items.Count; j++)
            {
                Categoria categoria = (Categoria)chListCategorias.Items[j];

                if (despesaSelecionada.CategoriasDaDespesa.Contains(categoria))
                {
                    chListCategorias.SetItemChecked(i, true);
                }

                i++;
            }
        }
        public void ConfigurarListaCategorias(List<Categoria> categorias)
        {
            chListCategorias.Items.Clear();

            chListCategorias.Items.AddRange(categorias.ToArray());
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            {
                // Obter os valores dos controles de entrada
                string idStr = txtId.Text;
                string descricao = txtDescricao.Text;
                decimal valor = Convert.ToDecimal(txtValor.Text);
                DateTime data = Convert.ToDateTime(txtData.Text);

                // Converter a forma de pagamento selecionada em um valor de enumeração
                string formaPgtoStr = Convert.ToString(cmbFormaPagamento.SelectedItem);
                FormaPagamentoEnum formaPgto;
                bool formaPgtoValida = Enum.TryParse(formaPgtoStr, out formaPgto);

                // Obter as categorias selecionadas
                List<Categoria> categorias = chListCategorias.CheckedItems.Cast<Categoria>().ToList();

                // Criar uma nova instância da Despesa
                Despesa despesa = new Despesa(descricao, valor, data, formaPgto);
                despesa.CategoriasDaDespesa = categorias;

                // Atribuir o ID à despesa
                int id = 0;
                if (!string.IsNullOrEmpty(idStr))
                {
                    id = Convert.ToInt32(idStr);
                }
                despesa.id = id;

                // Validar a despesa e obter os erros, se houver
                List<string> erros = despesa.Validar().ToList();

                // Verificar se existem erros de validação
                if (erros.Any())
                {
                    // Impedir o fechamento do formulário
                    DialogResult = DialogResult.None;

                    // Exibir a primeira mensagem de erro no rodapé
                    TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                }
            }
        }
        
    }
}
