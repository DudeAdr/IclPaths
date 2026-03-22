using AutoMapper;
using AutoMapper.QueryableExtensions;
using IclPaths.API.Domain.Interfaces.WalkPathInterfaces;
using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.WalkDTOs;
using IclPaths.API.Models.DTO.WalkPathDTOs;
using IclPaths.API.Persistance;
using Microsoft.EntityFrameworkCore;

namespace IclPaths.API.Domain.Repositories.WalkPathRepository

{
    public class WalkPathRepository : IWalkPathRepository
    {
        private readonly IMapper _mapper;
        private readonly IclPathsDbContext _dbContext;

        public WalkPathRepository(IMapper mapper, IclPathsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<WalkPathDto> AddWalkAsync(AddWalkPathDto addWalkPathRequestDto)
        {
            var mappedWalkPath = _mapper.Map<WalkPath>(addWalkPathRequestDto);
            await _dbContext.AddAsync(mappedWalkPath);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<WalkPathDto>(mappedWalkPath);
        }

        public async Task<WalkPathDto?> DeleteWalkPathAsync(Guid id)
        {
            var walkPath = await _dbContext.Paths.FirstOrDefaultAsync(x => x.Id == id);
            if (walkPath == null)
            {
                return null;
            }
            _dbContext.Paths.Remove(walkPath);
            await _dbContext.SaveChangesAsync();
            var mappedWalkPath = _mapper.Map<WalkPathDto>(walkPath);
            return mappedWalkPath;
        }

        public async Task<IEnumerable<WalkPathDto>> GetWalkPathsAsync(Guid? regionId, Guid? difficultyId)
        {
            var query = _dbContext.Paths
                .Include(p => p.Region)
                .Include(p => p.Difficulty)
                .AsQueryable();

            if (regionId.HasValue)
                query = query.Where(p => p.RegionId == regionId.Value);

            if (difficultyId.HasValue)
                query = query.Where(p => p.DifficultyId == difficultyId.Value);

            var entities = await query.ToListAsync();
            var mapped = _mapper.Map<IEnumerable<WalkPathDto>>(entities);
            return mapped;
        }


        public async Task<WalkPathDto?> GetWalkPathByIdAsync(Guid id)
        {
            var walkPath = await _dbContext.Paths
                .Include(p => p.Difficulty)
                .Include(p => p.Region)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (walkPath == null)
            {
                return null;
            }
            var mappedWalkPath = _mapper.Map<WalkPathDto>(walkPath);
            return mappedWalkPath;
        }

        public async Task<WalkPathDto?> UpdateWalkPathAsync(Guid id, UpdateWalkPathDto updateWalkPathRequestDto)
        {
            var walkPath = await _dbContext.Paths
                .Include(p => p.Difficulty)
                .Include(p => p.Region)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (walkPath == null)
            {
                return null;
            }
            walkPath.Name = updateWalkPathRequestDto.Name;
            walkPath.Description = updateWalkPathRequestDto.Description;
            walkPath.LengthInKm = updateWalkPathRequestDto.LengthInKm;
            walkPath.PathImageUrl = updateWalkPathRequestDto.PathImageUrl;
            walkPath.RegionId = updateWalkPathRequestDto.RegionId;
            walkPath.DifficultyId = updateWalkPathRequestDto.DifficultyId;

            await _dbContext.SaveChangesAsync();

            var mappedWalkPath = await _dbContext.Paths
                .Where(p => p.Id == walkPath.Id)
                .Include(p => p.Region)
                .Include(p => p.Difficulty)
                .ProjectTo<WalkPathDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return mappedWalkPath;
        }

        public async Task<IEnumerable<WalkPathDto>> GetAllWalkPathsAsync()
        {
            var walkPaths = await _dbContext.Paths
                .Include(p => p.Region)
                .Include(p => p.Difficulty)
                .ToListAsync();
            var mappedWalkPaths = _mapper.Map<IEnumerable<WalkPathDto>>(walkPaths);
            return mappedWalkPaths;
        }
    }
}
