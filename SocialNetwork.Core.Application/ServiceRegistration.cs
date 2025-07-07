using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.Services;
using System.Reflection;

namespace SocialNetwork.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //#region Services
            //services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IPostService, PostService>();
            //services.AddTransient<IComentariosService, ComentariosService>();
            //services.AddTransient<IAmigoService, AmigoService>();



            //#endregion


            // Descomenta esto cuando ya arregles los services y les pongas sus viewModels
        }
    }
}