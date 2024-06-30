using Microsoft.AspNetCore.Mvc;

namespace Service1.APIs;

[ApiController()]
public class UsController : UsControllerBase
{
    public UsController(IUsService service)
        : base(service) { }
}
