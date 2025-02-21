using FTMS.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FTMS
{
    public class FTMSContext : IdentityDbContext<User>
    {
        
    }
}
