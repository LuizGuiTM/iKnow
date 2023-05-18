using System.Data.SqlClient;

namespace iKnow.DAO
{
    public static class ConexaoBD
    {
        /// <summary>
        /// Método Estático que retorna um conexao aberta com o BD
        /// </summary>
        /// <returns>Conexão aberta</returns>
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=LG\\SQLEXPRESS;Initial Catalog=iKnow;Trusted_connection=true;encrypt=false";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
