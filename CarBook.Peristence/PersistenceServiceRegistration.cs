using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogRepository;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using CarBook.Peristence.Repositories;
using CarBook.Peristence.Repositories.BlogRepository;
using CarBook.Peristence.Repositories.CarPricingRepository;
using CarBook.Peristence.Repositories.CarRepositories;
using CarBook.Peristence.Repositories.CommentRepositories;
using CarBook.Peristence.Repositories.TagCloudRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<CarBookDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CarBookConnectionString")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
            services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
            services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
            services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
            //services.AddScoped(typeof(IAboutRepository), typeof(AboutRepository));


            return services;
        }
    }
}
