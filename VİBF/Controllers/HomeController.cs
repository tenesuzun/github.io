using Microsoft.AspNetCore.Mvc;
using VİBF.Models;
using System.Data.SqlClient;
using Dapper;
using System.IO;

namespace VİBF.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Save(Form applicant)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VİBF_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                var affectedRows = connection.Execute("INSERT INTO Applicants (İsim, Soyİsim, Cinsiyet, TCNO, Telefon, Mail, Adres, DoğumTarihi, AdliSicil, MedeniDurum, Ehliyet) Values (@İsim, @Soyİsim, @Cinsiyet, @TCNO, @Telefon, @Mail, @Adres, @DoğumTarihi, @AdliSicil, @MedeniDurum, @Ehliyet);", new { İsim = applicant.Ad, Soyİsim = applicant.Soyad, Cinsiyet = applicant.Cinsiyet, TCNO = applicant.TCKN, Telefon = applicant.Telefon, Mail = applicant.Email, Adres = applicant.Adres, DoğumTarihi = applicant.Dgt, AdliSicil = applicant.Sicil, MedeniDurum = applicant.Medeni_hal, Ehliyet = applicant.Ehliyet });
                using (MemoryStream pdf = new MemoryStream())
                {
                    applicant.Cv.CopyToAsync(pdf);
                    byte[] byte_pdf = pdf.ToArray();
                    var affectedCV = connection.Execute("INSERT INTO CVs ([File]) Values (@File);", new { File = byte_pdf });
                }
                
                connection.Close();
                return Content("Başvurunuz Tamamlandı");
            }
            
        } 
    }
}