using Bizland.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bziland.Business.Services.Interfaces
{
    public interface ITeamMemberService
    {
        Task CreateAsync(TeamMember teamMember);
        Task UpdateAsync(TeamMember teamMember);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<TeamMember> GetByExpression(Expression<Func<TeamMember,bool>>expression,params string[] includes);
        Task<List<TeamMember>> GetAllAsync(Expression<Func<TeamMember, bool>> expression, params string[] includes);

    }
}
