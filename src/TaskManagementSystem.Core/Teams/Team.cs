using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Attachments;
using TaskManagementSystem.Authorization.Users;

namespace TaskManagementSystem.Teams
{
    public class Team : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public long TeamLeaderId { get; set; }
        [ForeignKey("TeamLeaderId")]
        public User TeamLeader { get; set; }
    }
}
