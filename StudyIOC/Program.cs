
using Microsoft.AspNetCore.Builder;
using StudyIOC.Hubs;
using StudyIOC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHostedService<ConsumerStarter>();
builder.Services.AddSignalR();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChartHub>("/chart");
    endpoints.MapHub<ClientListHub>("/clientlist");
    
});


app.MapRazorPages();
//app.MapGet("/ClientChart", () => "Hello World!");
app.Run();
