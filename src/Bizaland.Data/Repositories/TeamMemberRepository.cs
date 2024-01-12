using Bizaland.Data.DAL;
using Bizland.Core.Entities;
using Bizland.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizaland.Data.Repositories;

public class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRepository
{
    public TeamMemberRepository(AppDbContext context) : base(context)
    {
    }
}
