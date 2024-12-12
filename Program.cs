using lr11.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
	options.Filters.AddService<ActionLoggingFilter>();
	options.Filters.AddService<UniqueUsersFilter>();
});

// Реєстрація власних фільтрів як сервісів
builder.Services.AddScoped<ActionLoggingFilter>();
builder.Services.AddScoped<UniqueUsersFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Animals}/{action=Index}/{id?}");
app.Run();