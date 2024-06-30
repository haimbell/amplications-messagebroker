using Service1.Infrastructure;

namespace Service1.APIs;

public class UsService : UsServiceBase
{
    public UsService(Service1DbContext context)
        : base(context) { }
}
