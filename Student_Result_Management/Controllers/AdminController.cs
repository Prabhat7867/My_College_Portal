using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Student_Result_Management.Models;
using System.Text;

namespace Student_Result_Management.Controllers
{
    public class AdminController : Controller
    {
        private string url = "https://localhost:7042/api/StudentAPI/";
        private string Result_url = "https://localhost:7042/api/Students_Result/";
        private HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentDetails std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Add_Students"] = "New Student added successfully.";
                return RedirectToAction("Index");

            }
            return View();

        }

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    StudentDetails student = new StudentDetails();
        //    HttpResponseMessage response = client.GetAsync(url + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        String result = response.Content.ReadAsStringAsync().Result;
        //        var data = JsonConvert.DeserializeObject<StudentDetails>(result);
        //        if (data != null)
        //        {
        //            student = data;
        //        }
        //    }
        //    return View(student);
        //}

        //[HttpPost]
        //public IActionResult Edit(StudentDetails std)
        //{
        //    var data = JsonConvert.SerializeObject(std);
        //    StringContent content = new StringContent(data, UTF32Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = client.PutAsync(url + std.RollNo, content).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        TempData["Update_Details"] = "Student details updated successfully.";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}


        [HttpGet]
        public IActionResult Admin_LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Admin_LoginPage(int Admin_Id, string Admin_Password)
        {

            HttpContext.Session.SetString("RollNumber", Admin_Id.ToString());
            return View("Index");
        }

        [HttpGet]
        public IActionResult Add_NewStudent() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_NewStudent(StudentDetails std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Add_Students"] = "New Student added successfully.";
                return RedirectToAction("Index");

            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentDetails student = new StudentDetails();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                String result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<StudentDetails>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(StudentDetails std)
        {
            var data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, UTF32Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + std.RollNo, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Update_Details"] = "Student details updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            StudentDetails std = new StudentDetails();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<StudentDetails>(content);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpGet]
        public IActionResult Get_AllStudents()
        {
            List<StudentDetails> Studensts = new List<StudentDetails>();
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<StudentDetails>>(result);

                if (data != null)
                {
                    Studensts = data;
                }
            }
            return View(Studensts);
        }


    }
}
