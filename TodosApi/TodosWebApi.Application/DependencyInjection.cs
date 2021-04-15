using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodosWebApi.WebApi.Data;
using TodosWebApi.WebApi.Interfaces;
using TodosWebApi.WebApi.Repository;

namespace TodosWebApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            const string connectionString = "Server=.;Database=TodoItems;Trusted_Connection=True;";

            services.AddDbContext<DataContext>(optionsAction => optionsAction.UseSqlServer(connectionString));
            services.AddTransient<DbContext, DataContext>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}
