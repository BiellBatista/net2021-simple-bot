using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleBotCore.Config;
using SimpleBotCore.Repositories;

namespace SimpleBotCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddMongoDBConfiguration();

            services.AddSingleton<IQuestionRepository, QuestionMongoDBRepository>();

            return services;
        }

        private static IServiceCollection AddMongoDBConfiguration(this IServiceCollection services)
        {
            services.AddOptions<MongoDBConnection>()
                    .Configure<IConfiguration>((settings, configuration) =>
                    {
                        configuration.GetSection("ConnectionStrings:MongoDBConnection").Bind(settings);
                    });

            return services;
        }
    }
}