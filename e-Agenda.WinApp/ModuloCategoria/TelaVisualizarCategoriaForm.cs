using e_Agenda.Dominio.ModuloCategoria;
using e_Agenda.Dominio.ModuloDespesas;

namespace e_Agenda.WinApp.ModuloCategoria
{
    public partial class TelaVisualizarCategoriaForm : Form
    {
        public TelaVisualizarCategoriaForm(List<Despesa> lista)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            AtualizarLista(lista);
        }

        private void AtualizarLista(List<Despesa> lista)
        {
            listDespesasDaCategoria.Items.Clear();

            foreach (Despesa despesa in lista)
            {
                listDespesasDaCategoria.Items.Add(despesa);
            }
        }
        public void CarregarLabel(Categoria categoria)
        {
            lblCategoriaSelecionada.Text = categoria.Titulo;
        }
    }
}
