using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly ApiContext _context;

        public CreateCategoryCommandHandler(ApiContext context)
        {
            _context = context;
        }

        public async void Handle(CategoryCreateCommand command)
        {
            _context.Categories.Add(new Category
            {
                Name = command.Name,
            });
            await _context.SaveChangesAsync();
        }
    }
}
