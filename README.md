Automapper Hakkında
---------------------------------------------------------------------------------------------------------------------------------------------------------------
.net 8 web projemisini oluşturuyoruz.
---------------------------------------------------------------------------------------------------------------------------------------------------------------
Manage nuget manager üzerinden Automapper kütüphanesini kuruyoruz.
---------------------------------------------------------------------------------------------------------------------------------------------------------------
program.cs tarafında gerekli servis ekleme işlemini yapıyoruz.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
C# dilinde, ASP.NET Core uygulamalarında kullanılan AutoMapper kütüphanesini yapılandırmak için kullanılır.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); kod parçası, AutoMapper'ı ASP.NET Core uygulamasına ekler ve AutoMapper'ın profil tanımlarını, yani eşleme ayarlarını ve davranışlarını içeren sınıfları uygulamanın çalışma zamanında yapılandırmak için bulunan mevcut assembly içerisinde arar. 
Assembly.GetExecutingAssembly() metodu, uygulamanın kendi assembly'sini döndürür, yani bu kodun bulunduğu assembly'deki sınıfların AutoMapper profilleri olarak kullanılmasını sağlar. 
Bu, uygulamanın diğer assembly'lerindeki AutoMapper profillerini eklemek isterseniz, bu metodu uygun bir şekilde değiştirebilirsiniz.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
---------------------------------------------------------------------------------------------------------------------------------------------------------------
örnek sınıfımızı oluşturalım
public class Employee
{
public int Id { get; set; }
public string FirstName { get; set; }
public string LastName { get; set; }
public string Address { get; set; }
public string Phone { get; set; }
public string Email { get; set; }
}
---------------------------------------------------------------------------------------------------------------------------------------------------------------
oluşturduğumuz örnek sıfına karsılık DTO sınıfımızı olusturalım
public class EmployeeDTO
{
public int Id { get; set; }
public string FirstName { get; set; }
public string LastName { get; set; }
}
---------------------------------------------------------------------------------------------------------------------------------------------------------------
Map işlemini gerceklestırmek ıcın ilgili kodumuzu yazıyoruz
public class EmployeeProfile : Profile
{
public EmployeeProfile()
{
//CreateMap<Employee, EmployeeDTO>().ForMember(dtoData => dtoData.FullName, fulldata => fulldata.MapFrom(src => src.FirstName + " " + src.LastName))
//    .ReverseMap();
CreateMap<Employee, EmployeeDTO>().ReverseMap();
}
}

Profile nedir?
AutoMapper, bir nesne haritalama kütüphanesidir ve bir sınıfın özelliklerini başka bir sınıfın özelliklerine otomatik olarak eşlemeyi sağlar. 
AutoMapper'ı kullanırken, eşleme mantığını ve davranışlarını ayarlamak için "Profil" adı verilen sınıfları kullanırsınız.
Bir AutoMapper profil sınıfı, genellikle AutoMapper tarafından haritalama işlemlerinin yapılandırılması için kullanılır. 
Bu sınıf, belirli bir sınıfın özelliklerini başka bir sınıfın özelliklerine eşlemek için gereken kuralları ve davranışları tanımlar. 
Profil sınıfı, AutoMapper'ın Profile sınıfını miras alır ve CreateMap yöntemi kullanılarak eşleme ayarları tanımlanır.

public class MyProfile : Profile
{
public MyProfile()
{
CreateMap<SourceClass, DestinationClass>();
}
}
Bu kod, SourceClass ve DestinationClass arasında bir eşleme tanımlar. 
Yani, AutoMapper bu sınıfların özelliklerini birbirine eşleyebilir.
Sonra bu profil sınıfını, örneğin bir ASP.NET Core uygulamasında, AddAutoMapper yöntemiyle yapılandırarak kullanabilirsiniz:
services.AddAutoMapper(typeof(MyProfile));
Bu şekilde, AutoMapper uygulamadaki profil sınıflarınızı tanıyacak ve yapılandırma ayarlarını kullanarak eşleme işlemlerini gerçekleştirebilecek.
---------------------------------------------------------------------------------------------------------------------------------------------------------------
Controller tarafında IMapper interface eklemesini yapıyoruz 
private readonly IMapper _mapper;
public HomeController(ILogger<HomeController> logger, IMapper mapper)
{
_logger = logger;
_mapper = mapper;
}
IMapper, AutoMapper kütüphanesinin bir parçası olan bir arayüzdür. 
IMapper arayüzü, nesne eşlemesi (object mapping) işlemlerini gerçekleştirmek için kullanılır. 
Yani, bir sınıfın özelliklerini başka bir sınıfın özelliklerine otomatik olarak eşlemek için kullanılır.
Bu _mapper alanı, genellikle sınıf içinde farklı sınıflar arasında eşlemeleri gerçekleştirmek için kullanılır. 
IMapper nesnesi, AutoMapper tarafından oluşturulan eşlemeleri gerçekleştirmek için kullanılan bir arayüzdür ve genellikle AutoMapper'ın özelliklerini ve yapılandırmalarını kullanarak eşlemeleri gerçekleştirmek için kullanılır.
Örneğin, aşağıdaki gibi bir kullanım senaryosu olabilir:
public class MyClass
{
private readonly IMapper _mapper;

public MyClass(IMapper mapper)
{
_mapper = mapper;
}

public void MapObjects()
{
SourceClass source = new SourceClass();
DestinationClass destination = _mapper.Map<DestinationClass>(source);
// Yukarıdaki satır, source nesnesinin özelliklerini destination nesnesine eşler.
}
}
_mapper alanı, sınıfın dışında bir IMapper nesnesiyle enjekte edilir ve daha sonra bu nesne kullanılarak nesne eşlemesi gerçekleştirilir.

List<Employee> employees = new List<Employee>();
employees.Add(new Employee() { Id = 1, FirstName = "Erkan", LastName = "Salihoğlu", Address = "Beşiktaş", Email = "es@test.com" });
employees.Add(new Employee() { Id = 1, FirstName = "Burak", LastName = "Junior", Address = "Üsküdar", Email = "jb@test.com" });
List<Employee> result = employees.ToList();
List<EmployeeDTO> employeeDto = _mapper.Map<List<EmployeeDTO>>(result);
return View(employeeDto);
---------------------------------------------------------------------------------------------------------------------------------------------------------------
View tarafında sınfıımızı (EmployeeDTO) sayfaya çağırıyoruz.
@{
ViewData["Title"] = "Home Page";
}

@model List<AutoMapperNet8.Project.DTOs.EmployeeDTO>

<div class="text-center">
<h1 class="display-4">Welcome</h1>
<p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>
<hr/>
@foreach (var item in Model)
{
<p>@item.Id - @item.FirstName - @item.LastName </p>
<hr />
}
