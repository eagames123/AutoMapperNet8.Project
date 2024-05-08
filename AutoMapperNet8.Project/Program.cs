using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); kod par�as�, AutoMapper'� ASP.NET Core uygulamas�na ekler ve AutoMapper'�n profil tan�mlar�n�, yani e�leme ayarlar�n� ve davran��lar�n� i�eren s�n�flar� uygulaman�n �al��ma zaman�nda yap�land�rmak i�in bulunan mevcut assembly i�erisinde arar. 
//Assembly.GetExecutingAssembly() metodu, uygulaman�n kendi assembly'sini d�nd�r�r, yani bu kodun bulundu�u assembly'deki s�n�flar�n AutoMapper profilleri olarak kullan�lmas�n� sa�lar. 
//Bu, uygulaman�n di�er assembly'lerindeki AutoMapper profillerini eklemek isterseniz, bu metodu uygun bir �ekilde de�i�tirebilirsiniz.
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
