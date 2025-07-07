using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Amigo : AuditableBaseEntity
    {
        public User? User { get; set; }
        public int? UserId { get; set; }

        public User? FriendUser { get; set; }
        public int? FriendId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
