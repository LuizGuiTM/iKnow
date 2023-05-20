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
            //string strCon = "Data Source=LOCALHOST; Database=iKnow; user id=sa; password=123456";
            //string strCon = @"Data Source=DESKTOP-MMNHGJS\SQLEXPRESS;Initial Catalog=iKnow;integrated security=true";
            //string strCon = "Data Source=LG\\SQLEXPRESS;Initial Catalog=iKnow2;Trusted_connection=true;encrypt=false";
            string strCon = "Data Source=LOCALHOST\\SQLEXPRESS; Database=iKnow; integrated security=true";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
