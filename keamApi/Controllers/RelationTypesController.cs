using keamApi.Entities;
using keamApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace keamApi.Controllers
{
  [Route("odata/relationtypes")]
  public class RelationTypesController : BaseController<RelationType>
  {

    public RelationTypesController(keamApiContext context) : base(context, context.RelationTypes)
    {

    }
  }
}
