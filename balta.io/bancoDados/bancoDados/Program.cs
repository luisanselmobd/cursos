using Microsoft.Data.SqlClient;
using System.Text;
using bancoDados.Models.Dapper;
using bancoDados.Repositories.Dapper;
using bancoDados.Models;

namespace bancoDados
{
    class Program
    {
        static void Main(string[] args)
        {
            var ccd = new CRUDcomDapper();
            ccd.Executar();
        }
    }
}
