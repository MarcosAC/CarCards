using CarCards.Droid.Helpers;
using CarCards.Helpers;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConexaoBancoDados))]
namespace CarCards.Droid.Helpers
{
    public class ConexaoBancoDados : IConexaoBancoDados
    {
        public string Conexao(string nomeArquivoBD)
        {
            string caminhoArquivoBD = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(caminhoArquivoBD, nomeArquivoBD);
        }
    }
}