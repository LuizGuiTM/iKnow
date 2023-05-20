using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace CadastroAlunoV1.Controllers
{
    public class HelperControllers
    {
        public static Boolean VerificaUserLogado(ISession session)
        {
            string logado = session.GetString("Logado");
            if (logado == null)
                return false;
            else
                return true;
        }

        public static Boolean VerificaFuncionarioRH(ISession session)
        {
            string FuncionarioRH = session.GetString("FuncionarioRH");
            if (FuncionarioRH == null)
                return false;
            else
                return true;
        }
    }
}
