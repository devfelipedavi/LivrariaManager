using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Notificacoes;
using DevIO.LM.Business.Services;
using DevIO.LM.Data.Context;
using DevIO.LM.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.LM.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            
            services.AddScoped<IAluguelRepository, AluguelRepository>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IAluguelService, AluguelService>();
            services.AddScoped<IEditoraService, EditoraService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
