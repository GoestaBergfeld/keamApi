using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keamApi.Entities
{
    public class Relation : BaseEntity
    {
		public virtual Node StartNode { get; set; }
		public int StartNodeId { get; set; }
		public virtual Node EndNode { get; set; }
		public int EndNodeId { get; set; }
		public virtual RelationType RelationType { get; set; }
		public int RelationTypeId { get; set; }
		public string Description { get; set; }
    }
}
