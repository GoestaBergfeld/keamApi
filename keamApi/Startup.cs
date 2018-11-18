using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using keamApi.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using keamApi.Entities;
using Microsoft.AspNet.OData.Extensions;

namespace keamApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddOData();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(
						options =>
						{
						  options.SerializerSettings.ContractResolver = new DefaultContractResolver();
						  options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
						  options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
						}
					);

			services.AddDbContext<keamApiContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("keamApiContext")));

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
			});
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

			app.UseHttpsRedirection();
			app.UseCors("CorsPolicy");
			app.UseMvc(b =>
			{
				b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
				b.MapODataServiceRoute("odata", "odata", GetEdmModel());
				b.EnableDependencyInjection();
			});
		}

		private static IEdmModel GetEdmModel()
		{
			ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
			builder.EntitySet<Node>("Nodes");
			builder.EntitySet<NodeAttribute>("NodeAttributes");
			builder.EntitySet<NodeType>("NodeTypes");
			builder.EntitySet<Entities.Attribute>("Attributes");
			builder.EntitySet<RelationType>("RelationTypes");
			builder.EntitySet<Relation>("Relations");
			builder.EntitySet<AttributeNodeType>("AttributeNodeTypes");
			//builder.EntityType<Attribute>().Collection.Action("PostWithSubdata").EntityParameter<Attribute>("attribute");
			return builder.GetEdmModel();
		}

	}
}
