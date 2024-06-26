﻿using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Category;
public partial class NewCategory : IRequest<CategoryData>
{
    public class Handler : IRequestHandler<NewCategory, CategoryData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CategoryData> Handle(NewCategory request, CancellationToken cancellationToken)
        {
            try
            {
                var space = await _dbContext.Spaces.FirstOrDefaultAsync(m => m.Id == request.SpaceId);
                if (space == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "Space not found."));

                }
                var category = _mapper.Map<Domain.Category>(request);
                await _dbContext.Categories.AddAsync(category, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return _mapper.Map<CategoryData>(category);

            }
            catch (Exception ex)
            {
                throw;

            }


        }


    }
}
