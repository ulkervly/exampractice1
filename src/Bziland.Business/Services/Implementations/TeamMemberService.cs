using Bizland.Core.Entities;
using Bizland.Core.Repositories;
using Bziland.Business.Exceptions.Common;
using Bziland.Business.Exceptions.TeamMemberExceptions;
using Bziland.Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bziland.Business.Services.Implementations
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }
        public Task CreateAsync(TeamMember teamMember)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if(id < 0) throw new IdBelowZeroException();
            var teamMember = await _teamMemberRepository.GetSingleAsync(x=>x.Id==id);
            if(teamMember is  null) throw new TeamMemberNotFoundException();
            _teamMemberRepository.Delete(teamMember);
            await _teamMemberRepository.CommitAsync();
            
        }

        public async Task<List<TeamMember>> GetAllAsync(Expression<Func<TeamMember, bool>> expression, params string[] includes)
        {
            return await _teamMemberRepository.GetAllWhere(expression,includes).ToListAsync();
        }

        public async Task<TeamMember> GetByExpression(Expression<Func<TeamMember, bool>> expression, params string[] includes)
        {
            return await _teamMemberRepository.GetSingleAsync(expression,includes);
        }

        public async Task SoftDelete(int id)
        {
            if (id < 0) throw new IdBelowZeroException();
            var teamMember = await _teamMemberRepository.GetSingleAsync(x => x.Id == id);
            if (teamMember is null) throw new TeamMemberNotFoundException();
            teamMember.Isdeleted=!teamMember.Isdeleted;
            await _teamMemberRepository.CommitAsync();

        }

        public Task UpdateAsync(TeamMember teamMember)
        {
            throw new NotImplementedException();
        }
    }
}
