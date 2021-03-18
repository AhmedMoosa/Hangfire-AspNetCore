# Hangfire - ASP.NET Core Sample

## Steps

- Install Packages (Hangfire.Core, Hangfire.AspNetCore, Hangfire.SqlServer)
- Set Your Connection String to Sql Server Database in appSettings.json.
- Add Hangfire to Service Container (Start.Configure).

```
            services.AddHangfire(options =>
            {
                options.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"));
                options.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
                options.UseSimpleAssemblyNameTypeSerializer();
                options.UseRecommendedSerializerSettings();
            });
            services.AddHangfireServer();

```

- Use Hangfire Middleware

```
  app.UseEndpoints(endpoints =>
            {
                ......
                endpoints.MapHangfireDashboard();
            });
```

- Run the Source code
