using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullSearchSamples.Services.Impl;
using FullSearchSamples.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace FullSearchSamples
{
    internal class Sample01
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    #region Configure EF DBContext Service (Documents Database)

                    services.AddDbContext<DocumentDbContext>(options =>
                    {
                        options.UseSqlServer(@"data source=SUPERCOMPUTER\SQLEXPRESS;initial catalog=DocumentsDatabase;User Id=DocumentsDatabaseUser;Password=sudo;MultipleActiveResultSets=True;App=EntityFramework");
                    });

                    #endregion

                    #region Configure Repositories

                    services.AddTransient<IDocumentRepository, DocumentRepository>();

                    #endregion
                })
                .Build();

            // Сохраним документы в БД
            host.Services.GetRequiredService<IDocumentRepository>().LoadDocuments();

            Console.ReadKey();
        }

    }
}
