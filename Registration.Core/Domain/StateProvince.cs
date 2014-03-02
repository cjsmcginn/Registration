using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Domain
{
    public partial class StateProvince : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Abbereviation { get; set; }
        public virtual Country Country { get; set; }
        public virtual Guid CountryId { get; set; }
    }
}
