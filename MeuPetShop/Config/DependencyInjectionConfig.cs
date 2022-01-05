using Cadastro_de_pessoas.Areas.Identity.Data;
using Cadastro_de_pessoas.Data;
using Cadastro_de_pessoas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddTransient<IPessoaRepository,PessoaRepository>();
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient<IAtendentesRepository, AtendentesRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<IEventoRepository, EventoRepository>();
            services.AddTransient<ITipoRepository, TipoRepository>();
            return services;
        }
    }
}
