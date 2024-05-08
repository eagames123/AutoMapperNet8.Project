using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); kod parçasý, AutoMapper'ý ASP.NET Core uygulamasýna ekler ve AutoMapper'ýn profil tanýmlarýný, yani eþleme ayarlarýný ve davranýþlarýný içeren sýnýflarý uygulamanýn çalýþma zamanýnda yapýlandýrmak için bulunan mevcut assembly içerisinde arar. 
//Assembly.GetExecutingAssembly() metodu, uygulamanýn kendi assembly'sini döndürür, yani bu kodun bulunduðu assembly'deki sýnýflarýn AutoMapper profilleri olarak kullanýlmasýný saðlar. 
//Bu, uygulamanýn diðer assembly'lerindeki AutoMapper profillerini eklemek isterseniz, bu metodu uygun bir þekilde deðiþtirebilirsiniz.
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
