using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_api5.Data
{
    [Table("Work")]
    public class Work
    {
        [Key]
        public int ID { get; set; }
        public string Workname { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }

    }
}
