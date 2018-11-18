using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace keamApi.Entities
{
    public class Node : BaseEntity
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual NodeType NodeType { get; set; }
		public int NodeTypeId { get; set; }
		public virtual ICollection<NodeAttribute> NodeAttributes { get; set; } = new List<NodeAttribute>();
		[InverseProperty("StartNode")]
		public virtual ICollection<Relation> StartRelations { get; set; } = new List<Relation>();
		[InverseProperty("EndNode")]
		public virtual ICollection<Relation> EndRelations { get; set; } = new List<Relation>();
  }
}
