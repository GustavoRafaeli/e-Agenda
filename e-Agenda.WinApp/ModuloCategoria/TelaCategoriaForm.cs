using e_Agenda.Dominio.ModuloCategoria;

namespace e_Agenda.WinApp.ModuloCategoria
{
    public partial class TelaCategoriaForm : Form
    {
        public TelaCategoriaForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Categoria ObterCategoria()
        {
            int id = Convert.ToInt32(txtId.Text);
            string titulo = txtTitulo.Text;

            Categoria categoria = new Categoria(titulo);
            categoria.id = id;

            return categoria;
        }

        public void ConfigurarTela(Categoria categoriaSelecionada)
        {
            txtId.Text = categoriaSelecionada.id.ToString();
            txtTitulo.Text = categoriaSelecionada.Titulo;
        }
    }
}
