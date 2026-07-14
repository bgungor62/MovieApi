using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly ApiContext _context;

        public RemoveMovieCommandHandler(ApiContext context)
        {
            _context = context;
        }
        public async void Handle(RemoveMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.Id);
            _context.Movies.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
