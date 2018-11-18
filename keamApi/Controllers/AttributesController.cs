using keamApi.Entities;
using keamApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keamApi.Controllers
{
	[Route("odata/attributes")]
	public class AttributesController : ODataController
	{

		keamApiContext _context;

		public AttributesController(keamApiContext context)
		{
			_context = context;
		}

		// GET: odata/entity
		[HttpGet]
		[EnableQuery]
		public IActionResult Get()
		{
			return Ok(_context.Attributes);
		}

		// GET: odata/entity(key)
		[HttpGet("{key}")]
		[EnableQuery]
		public IActionResult Get(int key)
		{
			var entity = _context.Attributes.FirstOrDefault(c => c.Id == key);

			if (entity == null)
			{
				return NotFound();
			}

			return Ok(entity);

		}

		// POST: odata/entity
		[HttpPost]
		[EnableQuery]
		public IActionResult Post([FromBody]Attribute entity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.Attributes.Add(entity);
			_context.SaveChanges();

			SaveAttributeNodeTypes(entity);

			_context.Entry(entity).Reload();

			return Ok(entity);
		}

		// PUT: odata/entity(key)
		[HttpPut("{key}")]
		[EnableQuery]
		public IActionResult Put(int key, [FromBody]Attribute entity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (key != entity.Id)
			{
				return BadRequest();
			}

			_context.Entry(entity).State = EntityState.Modified;
			_context.SaveChanges();

			SaveAttributeNodeTypes(entity);

			_context.Entry(entity).Reload();
			return Ok(entity);
		}

		private void SaveAttributeNodeTypes(Attribute attribute) 
		{
			var nodeTypeIds = new List<int>();
	
			// update & insert
			foreach (var attributeNodeType in attribute.AttributeNodeTypes)
			{
				if (attributeNodeType.Id == 0)
				{
					_context.AttributeNodeTypes.Add(attributeNodeType);
				}
				else
				{
					_context.Entry(attributeNodeType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				}
				nodeTypeIds.Add(attributeNodeType.NodeTypeId);
			}

			// delete
			var nodeTypes = _context.NodeTypes.Where(p => !nodeTypeIds.Contains(p.Id)).Select(p => p.Id).ToList();
			var deleteItems = _context.AttributeNodeTypes.Where(p => p.AttributeId == attribute.Id && nodeTypes.Contains(p.NodeTypeId)).ToList();

			foreach(var deleteItem in deleteItems) 
			{
				_context.AttributeNodeTypes.Remove(deleteItem);
			}

			_context.SaveChanges();
		}

		// DELETE: odata/entity(key)
		[HttpDelete("{key}")]
		public IActionResult Delete(int key)
		{
			var entity = _context.Attributes.FirstOrDefault(c => c.Id == key);

			if (entity == null)
			{
				return NotFound();
			}

			_context.Attributes.Remove(entity);
			_context.SaveChanges();

			return Ok(key);
		}

	}
}
