using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.Compartilhado
{
    public class RepositorioArquivoBase<TEntidade> /*: IRepositorioBase<TEntidade>*/
        where TEntidade : EntidadeBase<TEntidade>
    {

        private static int contador;

        protected List<TEntidade> listaRegistros = new List<TEntidade>();

        protected string NOME_ARQUIVO = "";

        public virtual void Inserir(TEntidade novoRegistro)
        {
            contador++;
            novoRegistro.id = contador;
            listaRegistros.Add(novoRegistro);

            GravarRegistrosEmArquivo();
        }

        public virtual void Editar(int id, TEntidade registroAtualizado)
        {
            EntidadeBase<TEntidade> registroSelecionada = SelecionarPorId(id);

            registroSelecionada.AtualizarInformacoes(registroAtualizado);

            GravarRegistrosEmArquivo();
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            listaRegistros.Remove(registroSelecionado);

            GravarRegistrosEmArquivo();
        }

        public virtual TEntidade SelecionarPorId(int id)
        {
            if (listaRegistros.Exists(registro => registro.id == id))
                return listaRegistros.FirstOrDefault(registro => registro.id == id);

            return null;
        }

        public virtual List<TEntidade> SelecionarTodos()
        {
            return listaRegistros.OrderByDescending(x => x.id).ToList();
        }

        private void AtualizarContador()
        {
            contador = listaRegistros.Max(x => x.id);
        }

        protected void CarregarRegistrosDoArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            byte[] registroEmBytes = File.ReadAllBytes(NOME_ARQUIVO);

            MemoryStream registroStream = new MemoryStream(registroEmBytes);

            listaRegistros = (List<TEntidade>)serializador.Deserialize(registroStream);

            AtualizarContador();
        }

        protected void GravarRegistrosEmArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream registroStream = new MemoryStream();

            serializador.Serialize(registroStream, listaRegistros);

            byte[] registrosEmBytes = registroStream.ToArray();

            File.WriteAllBytes(NOME_ARQUIVO, registrosEmBytes);
        }

        #region//RegistrosEmJason
        //private void GravarRegistroEmArquivoJson()
        //{
        //    JsonSerializerOptions opcoes = new JsonSerializerOptions();
        //    opcoes.IncludeFields = true;
        //    opcoes.WriteIndented = true;

        //    string registrosJson = JsonSerializer.Serialize(listaRegistros, opcoes);

        //    File.WriteAllText(NOME_ARQUIVO, registrosJson);
        //}

        //private void CarregarCompromissosDoArquivoJson()
        //{
        //    JsonSerializerOptions opcoes = new JsonSerializerOptions();
        //    opcoes.IncludeFields = true;

        //    string registrosJson = File.ReadAllText(NOME_ARQUIVO);

        //    if (registrosJson.Length > 0)
        //        listaRegistros = JsonSerializer.Deserialize<List<TEntidade>>(registrosJson, opcoes);
        //}
        #endregion

        #region//RegistrosEmXML

        //private void CarregarRegistrosDoArquivoXML()
        //{
        //    XmlSerializer serializador = new XmlSerializer(typeof(List<Compromisso>));

        //    MemoryStream registroStream = new MemoryStream();

        //    serializador.Serialize(registroStream, listaRegistros);

        //    byte[] compromissosEmBytes = registroStream.ToArray();

        //    File.WriteAllBytes(NOME_ARQUIVO, compromissosEmBytes);
        //}

        //private void CarregarCompromissosDoArquivoXml()
        //{
        //    XmlSerializer serializador = new XmlSerializer(typeof(List<Compromisso>));

        //    byte[] compromissoEmBytes = File.ReadAllBytes(NOME_ARQUIVO);

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
