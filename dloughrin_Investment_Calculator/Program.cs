using Microsoft;
using Investment_Calc.Data;
using Investment_Calc.Data.Interfaces;
using Investment_Calc.Data.Repos;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Add our database context
builder.Services.AddDbContextFactory<InvestCalcContext>(opt => opt.UseSqlite($"DataSource = ../Calc.db"));

//Add repos
builder.Services.AddScoped<I_InvestmentRepo, InvestmentRepo>();
builder.Services.AddScoped<I_AssetRepo, AssetRepo>();
builder.Services.AddScoped<I_UserRepo, UserRepo>();
builder.Services.AddScoped<I_ContactFormRepo, ContactFormRepo>();

var app = builder.Build();

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<InvestCalcContext>();
    dataContext.Database.Migrate();
}

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
