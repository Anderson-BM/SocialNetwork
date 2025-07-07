using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Post : AuditableBaseEntity
    {
        public string? Content { get; set; }

        public string? ImagePath { get; set; }
        public string? VideoUrl { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public ICollection<Comentarios>? Comments { get; set; }

        public User? User { get; set; }

        public int UserId { get; set; }
    }
}
