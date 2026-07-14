using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly ApiContext _context;

        public UpdateCategoryCommandHandler(ApiContext context)
        {
            _context = context;
        }

        public async void Handle(UpdateCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.Id);
            value.Name = command.Name;
            await _context.SaveChangesAsync();

        }
    }
}
