using keamApi.Entities;
using keamApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace keamApi.Controllers
{
	[Route("odata/[controller]")]
	public class BaseController<TEntity> : ODataController where TEntity : BaseEntity
	{
		private readonly keamApiContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public BaseController(keamApiContext context, DbSet<TEntity> dbSet)
		{
			_context = context;
			_dbSet = dbSet;
		}

		// GET: odata/entity
		[HttpGet]
		[EnableQuery]
		public IActionResult Get()
		{
			return Ok(_dbSet);
		}

		// GET: odata/entity(key)
		[HttpGet("{key}")]
		[EnableQuery]
		public IActionResult Get(int key)
		{
			var entity = _dbSet.FirstOrDefault(c => c.Id == key);

			if (entity == null)
			{
				return NotFound();
			}

			return Ok(entity);

		}

		// POST: odata/entity
		[HttpPost]
		[EnableQuery]
		public IActionResult Post([FromBody]TEntity entity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_dbSet.Add(entity);
			_context.SaveChanges();

			return Ok(entity);
		}


		// PUT: odata/entity(key)
		[HttpPut("{key}")]
		[EnableQuery]
		public IActionResult Put(int key, [FromBody]TEntity entity)
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

			_context.Entry(entity).Reload();
			return Ok(entity);
		}

		// DELETE: odata/entity(key)
		[HttpDelete("{key}")]
		public IActionResult Delete(int key)
		{
			var entity = _dbSet.FirstOrDefault(c => c.Id == key);
	
			if (entity == null)
			{
				return NotFound();
			}

			_dbSet.Remove(entity);
			_context.SaveChanges();

			return Ok(key);
		}

	}
}
