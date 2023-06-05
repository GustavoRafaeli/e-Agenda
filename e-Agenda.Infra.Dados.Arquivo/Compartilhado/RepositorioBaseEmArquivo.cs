using e_Agenda.Dominio.Compartilhado;

namespace e_Agenda.Infra.Dados.Arquivo.Compartilhado
{
    public abstract class RepositorioArquivoBase<TEntidade> /*: IRepositorioBase<TEntidade>*/
        where TEntidade : EntidadeBase<TEntidade>
    {
        private int contador;
        protected ContextoDados contextoDados;

        //protected List<TEntidade> listaRegistros = new List<TEntidade>();

        //protected string NOME_ARQUIVO = "";

        public RepositorioArquivoBase(ContextoDados contextoDados)
        {
            //NOME_ARQUIVO = "ModuloContato/Contatos.json";

            //if (File.Exists(ObterNomeArquivo()))
            //    CarregarRegistrosDoArquivoJson();

            this.contextoDados = contextoDados;

            AtualizarContador();
        }

        //protected abstract string ObterNomeArquivo();

        public abstract List<TEntidade> ObterRegistros(); 

        public virtual void Inserir(TEntidade novoRegistro)
        {
            List<TEntidade> registros = ObterRegistros();

            contador++;
            novoRegistro.id = contador;
            registros.Add(novoRegistro);

            contextoDados.GravarEmArquivosJson();
        }

        public virtual void Editar(int id, TEntidade registroAtualizado)
        {
            TEntidade registroSelecionada = SelecionarPorId(id);

            registroSelecionada.AtualizarInformacoes(registroAtualizado);

            contextoDados.GravarEmArquivosJson();
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            List<TEntidade> registros = ObterRegistros();

            registros.Remove(registroSelecionado);

            contextoDados.GravarEmArquivosJson();
        }

        public virtual TEntidade SelecionarPorId(int id)
        {
            List<TEntidade> registros = ObterRegistros();

            return registros.FirstOrDefault(x => x.id == id);
        }

        public virtual List<TEntidade> SelecionarTodos()
        {
            return ObterRegistros();
        }

        private void AtualizarContador()
        {
            if(ObterRegistros().Count > 0)
            {
                contador = ObterRegistros().Max(x => x.id);
            }
        }

        #region//RegistrosBinarios

        //protected void CarregarRegistrosDoArquivoBin()
        //{
        //    BinaryFormatter serializador = new BinaryFormatter();

        //    byte[] registroEmBytes = File.ReadAllBytes(ObterNomeArquivo());

        //    MemoryStream registroStream = new MemoryStream(registroEmBytes);

        //    listaRegistros = (List<TEntidade>)serializador.Deserialize(registroStream);

        //    AtualizarContador();
        //}
        //protected void GravarRegistrosEmArquivoBin()
        //{
        //    BinaryFormatter serializador = new BinaryFormatter();

        //    MemoryStream registroStream = new MemoryStream();

        //    serializador.Serialize(registroStream, listaRegistros);

        //    byte[] registrosEmBytes = registroStream.ToArray();

        //    File.WriteAllBytes(ObterNomeArquivo(), registrosEmBytes);
        //}
        #endregion

        #region//RegistrosEmJason

        //protected void GravarRegistroEmArquivoJson()
        //{
        //    JsonSerializerOptions opcoes = new JsonSerializerOptions();
        //    opcoes.IncludeFields = true;
        //    opcoes.WriteIndented = true;

        //    string registrosJson = JsonSerializer.Serialize(listaRegistros, opcoes);

        //    File.WriteAllText(ObterNomeArquivo(), registrosJson);
        //}

        //protected void CarregarRegistrosDoArquivoJson()
        //{
        //    JsonSerializerOptions opcoes = new JsonSerializerOptions();
        //    opcoes.IncludeFields = true;


        //    string registrosJson = File.ReadAllText(ObterNomeArquivo());


        //    if (registrosJson.Length > 10)
        //        listaRegistros = JsonSerializer.Deserialize<List<TEntidade>>(registrosJson, opcoes);
        //}
        #endregion

        #region//RegistrosEmXML
        //Testado em "CONTATOS"
        //protected void GravarRegistrosDoArquivoXML()
        //{
        //    XmlSerializer serializador = new XmlSerializer(typeof(List<TEntidade>));

        //    MemoryStream registroStream = new MemoryStream();

        //    serializador.Serialize(registroStream, listaRegistros);

        //    byte[] compromissosEmBytes = registroStream.ToArray();

        //    File.WriteAllBytes(ObterNomeArquivo(), compromissosEmBytes);
        //}

        //protected void CarregarCompromissosDoArquivoXml()
        //{
        //    XmlSerializer serializador = new XmlSerializer(typeof(List<TEntidade>));

        //    byte[] compromissoEmBytes = File.ReadAllBytes(ObterNomeArquivo());

        //    MemoryStream registroStream = new MemoryStream(compromissoEmBytes);

        //    if (registroStream.Length > 10)
        //    {
        //        listaRegistros = (List<TEntidade>)serializador.Deserialize(registroStream);
        //        AtualizarContador();
        //    }
        //}
        #endregion
    }
}
