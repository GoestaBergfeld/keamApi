using keamApi.Entities;
using keamApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace keamApi.Controllers
{
  [Route("odata/nodeattributes")]
  public class NodeAttributesController : BaseController<NodeAttribute>
  {

    public NodeAttributesController(keamApiContext context) : base(context, context.NodeAttributes)
    {

    }
  }
}
