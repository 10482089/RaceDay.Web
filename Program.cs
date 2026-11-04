var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Add Session (for login)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 2. Add HttpContextAccessor (to read cookies/session in views)
builder.Services.AddHttpContextAccessor();

// 3. Add HttpClient (to talk to the Part 2 API)
builder.Services.AddHttpClient("RaceDayAPI", client =>
{
    // IMPORTANT: Change this port to match YOUR API port!
    // Check the black window when you run your API.
    client.BaseAddress = new Uri("https://localhost:7202/");
});

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

// 4. Use Session
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
// If in Docker, the API isn't on localhost, it's on host.docker.internal
var apiUrl = builder.Environment.IsDevelopment() ? "https://localhost:7202/" : "http://host.docker.internal:5000/";
builder.Services.AddHttpClient("RaceDayAPI", client =>
{
    //  DOES THIS MATCH YOUR API?
    client.BaseAddress = new Uri("https://localhost:7202/");
});