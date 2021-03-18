# Hangfire - ASP.NET Core Sample

> Hangfire allows you to kick off method calls outside of the request processing pipeline in a very easy, but reliable way. These methods invocations are performed in a background thread and called background jobs.

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
