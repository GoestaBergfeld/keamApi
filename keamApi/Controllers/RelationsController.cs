using keamApi.Entities;
using keamApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace keamApi.Controllers
{
  [Route("odata/relations")]
  public class RelationsController : BaseController<Relation>
  {

    public RelationsController(keamApiContext context) : base(context, context.Relations)
    {

    }
  }
}
