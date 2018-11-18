using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using keamApi.Entities;

namespace keamApi.Models
{
    public class keamApiContext : DbContext
    {
        public keamApiContext (DbContextOptions<keamApiContext> options)
            : base(options)
        {
        }

        public DbSet<keamApi.Entities.Attribute> Attributes { get; set; }

        public DbSet<keamApi.Entities.Node> Nodes { get; set; }

        public DbSet<keamApi.Entities.NodeAttribute> NodeAttributes { get; set; }

        public DbSet<keamApi.Entities.NodeType> NodeTypes { get; set; }

        public DbSet<keamApi.Entities.Relation> Relations { get; set; }

        public DbSet<keamApi.Entities.RelationType> RelationTypes { get; set; }

		public DbSet<keamApi.Entities.AttributeNodeType> AttributeNodeTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttributeNodeType>()
						.HasOne(ant => ant.Attribute)
						.WithMany(a => a.AttributeNodeTypes)
						.HasForeignKey(ant => ant.AttributeId);

			modelBuilder.Entity<AttributeNodeType>()
						.HasOne(ant => ant.NodeType)
						.WithMany(nt => nt.AttributeNodeTypes)
						.HasForeignKey(ant => ant.NodeTypeId);

			modelBuilder.Entity<NodeAttribute>()
						.HasOne(na => na.Node)
						.WithMany(n => n.NodeAttributes)
						.HasForeignKey(na => na.NodeId);

			modelBuilder.Entity<NodeAttribute>()
						.HasOne(na => na.Attribute)
						.WithMany(a => a.NodeAttributes)
						.HasForeignKey(na => na.AttributeId);

			modelBuilder.Entity<Node>()
						.HasOne(n => n.NodeType)
						.WithMany(nt => nt.Nodes)
						.HasForeignKey(n => n.NodeTypeId);

      modelBuilder.Entity<Relation>()
                  .HasOne(r => r.StartNode)
                  .WithMany(n => n.StartRelations)
                  .HasForeignKey(r => r.StartNodeId)
                  .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Relation>()
                  .HasOne(r => r.EndNode)
                  .WithMany(n => n.EndRelations)
                  .HasForeignKey(r => r.EndNodeId)
                  .OnDelete(DeleteBehavior.Cascade);

			
			modelBuilder.Entity<NodeType>().HasData(
				new NodeType { Id = 1, Name = "Information System", ColorCode = "red" },
				new NodeType { Id = 2, Name = "Business Object", ColorCode = "blue" },
				new NodeType { Id = 3, Name = "Infrastructure", ColorCode = "cyan" }
			);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// optionsBuilder.
		}
	}
}
