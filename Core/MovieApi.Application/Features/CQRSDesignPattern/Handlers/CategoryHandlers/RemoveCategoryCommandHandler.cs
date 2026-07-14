using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly ApiContext _context;

        public RemoveCategoryCommandHandler(ApiContext context)
        {
            _context = context;
        }

        public async void Handle(RemoveCategoryCommand command)
        {
            var value = await _context.Categories.FindAsync(command.Id);
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
