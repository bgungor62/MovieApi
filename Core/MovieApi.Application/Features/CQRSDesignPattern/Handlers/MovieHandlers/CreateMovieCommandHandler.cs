using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly ApiContext _context;
        public CreateMovieCommandHandler(ApiContext context)
        {
            _context = context;
        }
        public async void Handle(CreateMoviewCommand command)
        {
            _context.Movies.Add(new Movie
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                Duration = command.Duration,
                CreatedYear = command.CreatedYear,
                ReleaseDate = command.ReleaseDate,
                Status = command.Status
            });
            await _context.SaveChangesAsync();
        }
    }
}
