using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rotativaio.AspNetCore
{
    public static class MvcServiceCollectionExtensions
    {
        public static void AddRotativaIo(this IServiceCollection services, string rotativaIoUrl, string rotativaIoApiKey)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            RotativaIoConfiguration.SetRotativaIoUrl(rotativaIoUrl);
            RotativaIoConfiguration.SetRotativaIoApiKey(rotativaIoApiKey);
        }

    }
}
