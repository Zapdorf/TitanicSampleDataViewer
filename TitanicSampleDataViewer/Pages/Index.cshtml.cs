using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TitanicSampleDataViewer.Models;

namespace TitanicSampleDataViewer.Pages
{
    public class IndexModel : PageModel
    {
        public List<Passenger> PassengerList { get; set; } = new List<Passenger>();
        
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            PassengerList.Add(new Passenger() { Id = 4 });
            PopulatePassengerListTable();
        }

        private void PopulatePassengerListTable()
        {

        }
    }
}
