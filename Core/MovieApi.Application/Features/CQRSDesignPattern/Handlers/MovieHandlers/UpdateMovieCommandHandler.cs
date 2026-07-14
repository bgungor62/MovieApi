using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly ApiContext _context;

        public UpdateMovieCommandHandler(ApiContext context)
        {
            _context = context;
        }

        public async void Handle(UpdateMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.Id);
            
            value.Rating = command.Rating;
            value.Status = command.Status;
            value.Duration = command.Duration;
            value.Title = command.Title;
            value.CoverImageUrl= command.CoverImageUrl;
            value.Description = command.Description;
            value.ReleaseDate = command.ReleaseDate;
            value.CreatedYear = command.CreatedYear;
            await _context.SaveChangesAsync();
        }
    }
}
