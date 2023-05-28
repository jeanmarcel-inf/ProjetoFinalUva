namespace Uva.ProjetoFinal.Models
{
    public class ListClientsViewModel
    {
        public IEnumerable<ClientModel> Clients { get; set; }
        public IEnumerable<AddressModel> Addresses { get; set; }
        public IEnumerable<BrowsingHistoryModel> BrowsingHistory { get; set; }
        public IEnumerable<EmailModel> Emails{ get; set; }
    }
}
