using Sparks.Components.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Sparks.Components.Blazor
{
    /// <summary>
    /// <see cref="ServiceCollection"/> class extension.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ModalService"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorModal(this IServiceCollection services)
        {
            return services.AddScoped<ModalService>();
        }
    }
}
