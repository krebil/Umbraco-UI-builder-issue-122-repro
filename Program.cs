using test;
using Umbraco.UIBuilder.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddUIBuilder(cfg =>
    {
        cfg.AddSection("test", configBuilder =>
        {
            configBuilder.Tree(treeConfigBuilder =>
            {
                treeConfigBuilder.AddCollection<Person>(p => p.Id, "Person", "People", "", collectionConfig =>
                {
                    collectionConfig.SetRepositoryType<PersonRepository>();
                    collectionConfig.SetNameProperty(p => p.Name);
                    collectionConfig.Editor(e =>
                    {
                        e.AddTab("General", tabConfig =>
                        {
                            tabConfig.AddFieldset("Content", fieldsetConfig =>
                            {
                                fieldsetConfig.AddField(p => p.JobTitle).SetDataType("Richtext editor");
                            });
                        });
                    });
                });
            });
        });
    })
    .AddComposers()
    .Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
