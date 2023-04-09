using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftcrylicTech.Library.DBEntities
{
    [Table("tblEvent")]
    public class tblEventEntity
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ModeOfEvent { get; set; }
        public string Venue { get; set; }
        public string Website { get; set; }
        public string LinkForDetails { get; set; }
        public long SpeakerId { get; set; }
    }
}
