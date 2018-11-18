using keamApi.Entities;
using keamApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace keamApi.Controllers
{
	[Route("odata/nodes")]
	public class NodesController: ODataController
    {

		private readonly keamApiContext _context;

		public NodesController(keamApiContext context)
		{
			this._context = context;
		}

		// GET: odata/entity
		[HttpGet]
		[EnableQuery]
		public IActionResult Get()
		{
			return Ok(_context.Nodes);
		}

		// GET: odata/entity(key)
		[HttpGet("{key}")]
		[EnableQuery]
		public IActionResult Get(int key)
		{
			var entity = _context.Nodes.FirstOrDefault(c => c.Id == key);

			if (entity == null)
			{
				return NotFound();
			}

			return Ok(entity);

		}

		// POST: odata/entity
		[HttpPost]
		[EnableQuery]
		public IActionResult Post([FromBody]Node entity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.Nodes.Add(entity);
			_context.SaveChanges();

			SaveNodeAttributes(entity);

			return Ok(entity);
		}


		// PUT: odata/entity(key)
		[HttpPut("{key}")]
		[EnableQuery]
		public IActionResult Put(int key, [FromBody]Node entity)
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

			SaveNodeAttributes(entity);

            _context.Entry(entity).Reload();
			return Ok(entity);
		}

		// DELETE: odata/entity(key)
		[HttpDelete("{key}")]
		public IActionResult Delete(int key)
		{
			var entity = _context.Nodes.FirstOrDefault(c => c.Id == key);

			if (entity == null)
			{
				return NotFound();
			}

			_context.Nodes.Remove(entity);
			_context.SaveChanges();

			return Ok(key);
		}

		private void SaveNodeAttributes(Node node)
		{
			var attributeIds = new List<int>();

			// update & insert
			foreach (var nodeAttribute in node.NodeAttributes)
			{
				if (nodeAttribute.Id == 0)
				{
					_context.NodeAttributes.Add(nodeAttribute);
				}
				else
				{
					_context.Entry(nodeAttribute).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				}
				attributeIds.Add(nodeAttribute.AttributeId);
			}

			// delete
			//var attributes = _context.Attributes.Where(p => p.AttributeNodeTypes.Contains())
			//var deleteItems = _context.AttributeNodeTypes.Where(p => p.AttributeId == attribute.Id && nodeTypes.Contains(p.NodeTypeId)).ToList();

			//foreach (var deleteItem in deleteItems)
			//{
			//	_context.AttributeNodeTypes.Remove(deleteItem);
			//}

			_context.SaveChanges();
		}

    }
}
