using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Domain
{
    public partial class AccountProfile : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string City { get; set; }
        public virtual Guid? CountryId { get; set; }
        public virtual Guid? StateProvinceId { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public virtual Country Country { get; set; }
        public virtual Account Account { get; set; }
        public virtual string Bio { get; set; }

        public virtual bool KeepPrivate { get; set; }
    }
}
