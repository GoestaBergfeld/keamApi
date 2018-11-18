using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keamApi.Entities
{
    public class Attribute : BaseEntity
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public AttributeDataType DataType { get; set; }
		public bool Required { get; set; }
		public bool MultipleAllowed { get; set; }
		public virtual ICollection<AttributeNodeType> AttributeNodeTypes { get; set; } = new List<AttributeNodeType>();
		public virtual ICollection<NodeAttribute> NodeAttributes { get; set; } = new List<NodeAttribute>();
	}

	public enum AttributeDataType
	{
		OneLineText,
		MultiLineText,
		Date,
		Boolean ,
		Number,
		Lookup,
		LookupEntity,
		Enum,
		EnumName,
		ColorCode,
		Actions
	}
}
