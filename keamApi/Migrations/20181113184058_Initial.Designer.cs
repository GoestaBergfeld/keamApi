﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using keamApi.Models;

namespace keamApi.Migrations
{
    [DbContext(typeof(keamApiContext))]
    [Migration("20181113184058_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("keamApi.Entities.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DataType");

                    b.Property<string>("Description");

                    b.Property<bool>("MultipleAllowed");

                    b.Property<string>("Name");

                    b.Property<bool>("Required");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("keamApi.Entities.AttributeNodeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeId");

                    b.Property<int>("NodeTypeId");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("NodeTypeId");

                    b.ToTable("AttributeNodeTypes");
                });

            modelBuilder.Entity("keamApi.Entities.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("NodeTypeId");

                    b.HasKey("Id");

                    b.HasIndex("NodeTypeId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("keamApi.Entities.NodeAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeId");

                    b.Property<int>("NodeId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("NodeId");

                    b.ToTable("NodeAttributes");
                });

            modelBuilder.Entity("keamApi.Entities.NodeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorCode");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("NodeTypes");

                    b.HasData(
                        new { Id = 1, ColorCode = "red", Name = "Information System" },
                        new { Id = 2, ColorCode = "blue", Name = "Business Object" },
                        new { Id = 3, ColorCode = "cyan", Name = "Infrastructure" }
                    );
                });

            modelBuilder.Entity("keamApi.Entities.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("EndNodeId");

                    b.Property<int>("RelationTypeId");

                    b.Property<int>("StartNodeId");

                    b.HasKey("Id");

                    b.HasIndex("EndNodeId");

                    b.HasIndex("RelationTypeId");

                    b.HasIndex("StartNodeId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("keamApi.Entities.RelationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RelationTypes");
                });

            modelBuilder.Entity("keamApi.Entities.AttributeNodeType", b =>
                {
                    b.HasOne("keamApi.Entities.Attribute", "Attribute")
                        .WithMany("AttributeNodeTypes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("keamApi.Entities.NodeType", "NodeType")
                        .WithMany("AttributeNodeTypes")
                        .HasForeignKey("NodeTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("keamApi.Entities.Node", b =>
                {
                    b.HasOne("keamApi.Entities.NodeType", "NodeType")
                        .WithMany("Nodes")
                        .HasForeignKey("NodeTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("keamApi.Entities.NodeAttribute", b =>
                {
                    b.HasOne("keamApi.Entities.Attribute", "Attribute")
                        .WithMany("NodeAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("keamApi.Entities.Node", "Node")
                        .WithMany("NodeAttributes")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("keamApi.Entities.Relation", b =>
                {
                    b.HasOne("keamApi.Entities.Node", "EndNode")
                        .WithMany("EndRelations")
                        .HasForeignKey("EndNodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("keamApi.Entities.RelationType", "RelationType")
                        .WithMany()
                        .HasForeignKey("RelationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("keamApi.Entities.Node", "StartNode")
                        .WithMany("StartRelations")
                        .HasForeignKey("StartNodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}