using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keamApi.Entities
{
	public class AttributeNodeType : BaseEntity
	{
		public int AttributeId { get; set; }
		public int NodeTypeId { get; set; }
		public virtual Attribute Attribute { get; set; }
		public virtual NodeType NodeType { get; set; }
		
    }
}
