using System.ComponentModel.DataAnnotations.Schema;

namespace Wallets.DataAccess.Entities
{
    public class Wallet
    {
        public int Id { get; set; }

        public string Address { get; set; }

        [NotMapped]
        public string Balance { get; set; }
    }
}
