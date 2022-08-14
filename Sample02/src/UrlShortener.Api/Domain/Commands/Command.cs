using System;

namespace UrlShortened.Api.Domain.Commands
{
    public class Command
    {
        public string Id { get; }

        public Command()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}