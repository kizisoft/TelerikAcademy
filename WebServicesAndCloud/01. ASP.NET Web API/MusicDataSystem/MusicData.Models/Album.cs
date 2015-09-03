namespace MusicData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
            this.Artists = new HashSet<Artist>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Title { get; set; }

        public DateTimeOffset? Year { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}