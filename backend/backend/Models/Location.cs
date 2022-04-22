using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("locations")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string City { get; set; } = String.Empty;

        public string Lat { get; set; } = String.Empty;

        public string Lng { get; set; } = String.Empty;

        public string Country { get; set; } = String.Empty;

        public string Admin_Name { get; set; } = String.Empty;

        public int? Population { get; set; } = 0;
    }
}
