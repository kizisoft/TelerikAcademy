namespace MusicData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Song
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Title { get; set; }

        public DateTimeOffset? Year { get; set; }

        public Genre Genre { get; set; }

        [ForeignKey("Album")]
        public int? AlbumID { get; set; }

        public virtual Album Album { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}