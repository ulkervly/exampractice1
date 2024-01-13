using Bizland.Core.Entities;
using Bizland.Core.Repositories;
using Bziland.Business.Exceptions.Common;
using Bziland.Business.Exceptions.TeamMemberExceptions;
using Bziland.Business.Extensions.Helpers;
using Bziland.Business.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _env;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository,IWebHostEnvironment env)
        {
            _teamMemberRepository = teamMemberRepository;
            _env = env;
        }
        public async Task CreateAsync(TeamMember teamMember)
        {
            if (teamMember is null) throw new NullReferenceException();
            if (teamMember.ImageFile is not null)
            {
                if (teamMember.ImageFile.ContentType!="image/jpeg" && teamMember.ImageFile.ContentType!="image/png")
                {
                    throw new TeamMemberInvalidImageFileException("ImageFile","Content type must be jpg or png !");
                }
                if (teamMember.ImageFile.Length>2097167)
                {
                    throw new TeamMemberInvalidImageFileException("ImageFile","Size must be lower  2 mb");
                }
            }
            teamMember.ImageUrl = teamMember.ImageFile.SaveFile(_env.WebRootPath,"uploads/teammembers");
            teamMember.CreatedTime = DateTime.UtcNow;
            teamMember.UpdatedTime = DateTime.UtcNow;
            await _teamMemberRepository.CreateAsync(teamMember);
            await _teamMemberRepository.CommitAsync();
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

        public async Task UpdateAsync(TeamMember teamMember)
        {
            if (teamMember is null) throw new NullReferenceException();
            var existteammember = await _teamMemberRepository.GetSingleAsync(x=>x.Id==teamMember.Id && !x.Isdeleted);
            if (existteammember is null)
            {
                throw new TeamMemberNotFoundException();
            }
            if (teamMember.ImageFile is not null)
            {
                if (teamMember.ImageFile.ContentType != "image/jpeg" && teamMember.ImageFile.ContentType != "image/png")
                {
                    throw new TeamMemberInvalidImageFileException("ImageFile", "Content type must be jpg or png !");
                }
                if (teamMember.ImageFile.Length > 2097167)
                {
                    throw new TeamMemberInvalidImageFileException("ImageFile", "Size must be lower  2 mb");
                }
                FileManager.DeleteFile(_env.WebRootPath, "uploads/teammembers",existteammember.ImageUrl);
                existteammember.ImageUrl = teamMember.ImageFile.SaveFile(_env.WebRootPath, "uploads/teammembers");

            }
            existteammember.FullName = teamMember.FullName;
            existteammember.Profession=teamMember.Profession;
            existteammember.MediaUrls = teamMember.MediaUrls;
            existteammember.UpdatedTime = DateTime.UtcNow;
            await _teamMemberRepository.CommitAsync();
        }
    }
}
