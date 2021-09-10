﻿namespace Application.TodoList.Queries
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Exceptions;
    using FluentValidation;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Persistence;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetTodoItemByIdQuery : IRequest<TodoItemDto>
    {
        public int ListId { get; set; }

        public int TodoId { get; set; }
    }
    
    public class GetTodoItemInListQueryValidator : AbstractValidator<GetTodoItemByIdQuery>
    {
        public GetTodoItemInListQueryValidator()
        {
            RuleFor(x => x.ListId).GreaterThan(0);
            
            RuleFor(x => x.TodoId).GreaterThan(0);
        }
    }
    
    public class GetTodoItemInListQueryHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoItemInListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<TodoItemDto> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var todo = await _context.TodoItems
                .AsNoTracking()
                .Where(x => x.ListId == request.ListId && x.Id == request.TodoId)
                .ProjectTo<TodoItemDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (todo == null)
            {
                throw new NotFoundException();
            }

            return todo;
        }
    }
}