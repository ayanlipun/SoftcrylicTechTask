using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftcrylicTech.Library.DBEntities
{
    [Table("tblSpeaker")]
    public class tblSpeakerEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string SocialLinks { get; set; }
    }
}
