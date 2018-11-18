using keamApi.Entities;
using keamApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace keamApi.Controllers
{
  [Route("odata/nodetypes")]
  public class NodeTypesController : BaseController<NodeType>
  {

    public NodeTypesController(keamApiContext context) : base(context, context.NodeTypes)
    {

    }
  }
}
