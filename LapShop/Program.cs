
using BusinessLib.Bl;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("constr"))
    .AddInterceptors(new SoftDeleteInterceptor()));

// Register your classes as services
builder.Services.AddScoped<IBusinessInterface<TbCategory>, clsCategory>();
builder.Services.AddScoped<IBusinessInterface<TbItem>, clsItem>();
builder.Services.AddScoped<IItemViewService<VwItem>, clsItem>();
builder.Services.AddScoped<IItemLight<TbItem>, clsItem>();
builder.Services.AddScoped<ISpecialGetFeature<TbItemImage>, clsItemImage>();
builder.Services.AddScoped<IBusinessInterface<TbItemType>, clsItemType>();
builder.Services.AddScoped<IBusinessInterface<TbOs>, clsOs>();
builder.Services.AddScoped<IBusinessInterface<TbGPU>, clsGPU>();
builder.Services.AddScoped<IBusinessInterface<TbProcessor>, clsProcessor>();
builder.Services.AddScoped<IBusinessInterface<TbHardDisk>, clsHardDisk>();
builder.Services.AddScoped<IBusinessInterface<TbScreenResolution>, clsScreenResolution>();
builder.Services.AddScoped<IBusinessInterface<TbRAM>, clsRAM>();
builder.Services.AddScoped<ISpecialSalesItemFetaure<TbSalesInvoiceItem>, clsSalesInvoiceItems>();
builder.Services.AddScoped<ISpecialInvoiceFeature, clsSalesInvoice>();

//// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    //user
    options.User.RequireUniqueEmail = true;
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 4;




}).AddEntityFrameworkStores<AppDbContext>();

// Configure the Application Cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    // If the LoginPath isn't set, ASP.NET Core defaults the path to /Account/Login.
    options.LoginPath = "/Account/Login"; // Set your login path here
});

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins("http://127.0.0.1:5500")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });

builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.UseCors("AllowSpecificOrigin");

app.UseEndpoints(endpoints =>
{
    // Set the default route to admin/social/index
    endpoints.MapControllerRoute(
    name: "main",
    pattern: "{controller=Items}/{action=List}/{id?}");


    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");


	endpoints.MapControllerRoute(
		name: "api",
		pattern: "api/{controller=Values}/{action=Index}/{id?}");


});
app.Run();
