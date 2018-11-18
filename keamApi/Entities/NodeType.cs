using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keamApi.Entities
{
    public class NodeType : BaseEntity
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public string ColorCode { get; set; }
		public virtual ICollection<Node> Nodes { get; set; } = new List<Node>();
		public virtual ICollection<AttributeNodeType> AttributeNodeTypes { get; set; } = new List<AttributeNodeType>();
	}
}
