using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Domain
{
    public partial class Country : BaseEntity
    {
        private ICollection<StateProvince> _stateProvinces;
        public virtual string Name { get; set; }
        public virtual string TwoLetterIsoCode { get; set; }
        public virtual string ThreeLetterIsoCode { get; set; }

        public virtual ICollection<StateProvince> StateProvinces
        {
            get { return _stateProvinces ?? (_stateProvinces = new List<StateProvince>()); }
            set { _stateProvinces = value; }
        }

    }
}
