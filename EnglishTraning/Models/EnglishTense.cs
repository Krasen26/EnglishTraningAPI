using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishTraning.Models
{
    [Table("EnglishTenses")]
    public class EnglishTense
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string BulgarianSentence { get; set; }

        [MaxLength(250)]
        public string EnglishSentence { get; set; }

        public int TensesType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
