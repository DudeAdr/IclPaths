using AutoMapper;
using AutoMapper.QueryableExtensions;
using IclPaths.API.Domain.Interfaces.WalkPathInterfaces;
using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.WalkDTOs;
using IclPaths.API.Models.DTO.WalkPathDTOs;
using IclPaths.API.Models.Enums;
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

        public async Task<IEnumerable<WalkPathDto>> GetAllWalkPathsAsync(
            SortAndFilterBy? filterOn = null,
            string? filterQuery = null,
            SortAndFilterBy? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000)
        {
            var query = _dbContext.Paths
                .Include(p => p.Region)
                .Include(p => p.Difficulty)
                .AsQueryable();

            if (filterOn.HasValue && !string.IsNullOrWhiteSpace(filterQuery))
            {
                query = filterOn.Value switch
                {
                    SortAndFilterBy.Name => query.Where(p => p.Name.Contains(filterQuery)),
                    SortAndFilterBy.Description => query.Where(p => p.Description.Contains(filterQuery)),
                    SortAndFilterBy.Region => query.Where(p => p.Region.Name.Contains(filterQuery)),
                    SortAndFilterBy.Difficulty => query.Where(p => p.Difficulty.Name.Contains(filterQuery)),
                    SortAndFilterBy.Length => query.Where(p => p.LengthInKm.Equals(filterQuery)),
                    _ => query
                };
            }
            if (sortBy.HasValue)
            {
                query = sortBy.Value switch
                {
                    SortAndFilterBy.Name => isAscending ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name),
                    SortAndFilterBy.Description => isAscending ? query.OrderBy(p => p.LengthInKm) : query.OrderByDescending(p => p.LengthInKm),
                    SortAndFilterBy.Region => isAscending ? query.OrderBy(p => p.Region.Name) : query.OrderByDescending(p => p.Region.Name),
                    SortAndFilterBy.Difficulty => isAscending ? query.OrderBy(p => p.Difficulty.Name) : query.OrderByDescending(p => p.Difficulty.Name),
                    SortAndFilterBy.Length => isAscending ? query.OrderBy(p => p.LengthInKm) : query.OrderByDescending(p => p.LengthInKm),
                    _ => query
                };
            }

            var skipResults = (pageNumber - 1) * pageSize;
            var walkPaths = await query.Skip(skipResults).Take(pageSize).ToListAsync();
            var mappedWalkPaths = _mapper.Map<IEnumerable<WalkPathDto>>(walkPaths);

            return mappedWalkPaths;
        }
    }
}
