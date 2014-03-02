using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Domain
{
    public partial class Account : BaseEntity
    {

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual bool Encrypted { get; set; }
        public virtual DateTime CreatedOnUtc { get; set; }
        public virtual DateTime? LastUpdatedUtc { get; set; }
        public virtual bool Active { get; set; }
        public virtual AccountProfile AccountProfile { get; set; }

        public virtual DateTime? LastLogin { get; set; }
        public virtual int RetryCount { get; set; }
        public virtual bool IsLockedOut { get; set; }

        public virtual string RecoveryEmailAddress { get; set; }

    }
}
