using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialNetwork.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? ImagePath { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = false;

        public string? TokenActive { get; set; }

        public ICollection<Post>? Posts { get; set; }

        public ICollection<Amigo>? Friends { get; set; }
        public ICollection<Amigo>? FriendsOf { get; set; }
        public ICollection<Comentarios>? Comments { get; set; }
    }
}
