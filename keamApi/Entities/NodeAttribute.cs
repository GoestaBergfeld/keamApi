using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keamApi.Entities
{
    public class NodeAttribute : BaseEntity
    {
		public virtual Node Node { get; set; }
		public int NodeId { get; set; }
		public virtual Attribute Attribute { get; set; }
		public int AttributeId { get; set; }
		public string Value { get; set; }
    }
}
