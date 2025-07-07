using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Comentarios : AuditableBaseEntity
    {
        public string Message { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public Post? Post { get; set; }

        public int PostId { get; set; }

        public ICollection<Comentarios>? Replies { get; set; } = new List<Comentarios>();

        public int? ParentCommentId { get; set; }

        public Comentarios? ParentComment { get; set; }

        public User? User { get; set; }

        public int? UserId { get; set; }
    }
}
