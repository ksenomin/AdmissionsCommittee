using AdmissionComittee.Context;
using AdmissionComittee.Entities;
using Repository;
using Repository.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IApplicantStorage, ApplicantRepository>();
builder.Services.AddScoped<IApplicantManager, ApplicantManager>();
builder.Services.AddDbContext<ApplicantContext>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var dbContext = new ApplicantContext())
{
    var applicant = new Applicant()
    {
        FullName = "Егор егоров",
        BirthDay = Convert.ToDateTime("02.03.2000"),
        Gender = Gender.Male,
        StudyForm = StudyForm.Mixed,
        InformaticScore = 100,
        MathScore = 56,
        RussianScore = 33
    };
    dbContext.Add(applicant);
}

app.Run();
