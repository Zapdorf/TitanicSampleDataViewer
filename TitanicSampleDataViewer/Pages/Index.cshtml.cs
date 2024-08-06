using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TitanicSampleDataViewer.Models;
using Dapper;
using System.Data.Odbc;

namespace TitanicSampleDataViewer.Pages
{
    public class IndexModel : PageModel
    {
        public List<Passenger> PassengerList { get; set; } = new List<Passenger>();

        //private const string _connectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=";
        
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "TitanicData.accdb");
            //string combo = _connectionString + filePath;

            string start = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            start += filePath;



            //var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\SHODAN\Documents\Databases\TitanicData.accdb;";
            var connectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\\Users\\SHODAN\\Documents\\Databases\\TitanicData.accdb;";

            //var connectionString = @$"{start};";
            using (var connection = new OdbcConnection(connectionString))
            {
                // Create a query that retrieves all books with an author name of "John Smith"    
                var sql = "SELECT * FROM Passengers";

                // Use the Query method to execute the query and return a list of objects    
                PassengerList = connection.Query<Passenger>(sql).ToList();
            }

            //PassengerList.Add(new Passenger() { Id = 4 });
            PopulatePassengerListTable();
        }

        private void PopulatePassengerListTable()
        {

        }
    }
}
