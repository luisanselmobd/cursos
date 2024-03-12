using Microsoft.Data.SqlClient;
using System.Text;
using bancoDados.Models.Dapper;
using bancoDados.Repositories.Dapper;
using bancoDados.Models;
using bancoDados.Models.ADO;
using bancoDados.Repositories.ADO;

namespace bancoDados
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ccd = new CRUDcomDapper();
            //ccd.Executar();
            var cca = new CRUDcomADO();       
            cca.Executar();
            
        }
    }
}
