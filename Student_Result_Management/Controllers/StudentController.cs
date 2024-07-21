using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Student_Result_Management.Models;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Student_Result_Management.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7042/api/StudentAPI/";
        private string Result_url = "https://localhost:7042/api/Students_Result/";
        private HttpClient client = new HttpClient();

        public IActionResult Student_HomePage()
        {
            return View();
        }


        //[HttpGet]
        //public IActionResult Index()
        //{
        //    List<StudentDetails> Studensts = new List<StudentDetails>();
        //    HttpResponseMessage response = client.GetAsync(url).Result;

        //    if(response.IsSuccessStatusCode)
        //    {
        //        string result = response.Content.ReadAsStringAsync().Result;
        //        var data = JsonConvert.DeserializeObject<List<StudentDetails>>(result);

        //        if(data != null) 
        //        {
        //            Studensts = data;
        //        }
        //    }
        //    return View(Studensts);
        //}

        //[HttpGet]
        //public IActionResult Create() 
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(StudentDetails std)
        //{
        //    string data = JsonConvert.SerializeObject(std);
        //    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = client.PostAsync(url, content).Result;
        //    if(response.IsSuccessStatusCode) 
        //    {
        //        TempData["Add_Students"] = "New Student added successfully.";
        //        return RedirectToAction("Index");
                
        //    }
        //    return View();

        //}

        //[HttpGet]
        //public IActionResult Edit(int id) 
        //{
        //    StudentDetails student = new StudentDetails();
        //    HttpResponseMessage response = client.GetAsync(url + id).Result;
        //    if(response.IsSuccessStatusCode) 
        //    {
        //        String result  = response.Content.ReadAsStringAsync().Result;
        //        var data = JsonConvert.DeserializeObject<StudentDetails>(result);
        //        if(data != null) 
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
        //    StringContent content = new StringContent(data,UTF32Encoding.UTF8,"application/json");
        //    HttpResponseMessage response = client.PutAsync(url+std.RollNo, content).Result;
        //    if(response.IsSuccessStatusCode) 
        //    {
        //        TempData["Update_Details"] = "Student details updated successfully.";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpGet]
        public IActionResult Details(int id) 
        {
            StudentDetails std = new StudentDetails();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if(response != null) 
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<StudentDetails> (content);
                if(data != null) 
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            StudentDetails student = new StudentDetails();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if(response != null) 
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<StudentDetails>(result);
                if(data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Delete_StudentDetails"] = "Student details deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Get_StudentDetails()
        {
            //int Roll_No = 1;
            var Roll_No = HttpContext.Session.GetString("RollNumber");
            //if (HttpContext.Session.GetString("RollNumber") != "0")
            //{
            //    HttpContext.Session.SetString("RollNumber", Roll_No.ToString());
            //}

            TempData["Get_details"] = "Student details";
            StudentDetails std = new StudentDetails();
            HttpResponseMessage response = client.GetAsync(url + Roll_No).Result;
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<StudentDetails>(content);
                if (data != null)
                {
                    std = data;
                }
            }
            return View("Details", std);
        }

        //[HttpPost]
        //public IActionResult Get_StudentDetails(string Name, int Roll_No)
        //{
        //    Roll_No = 1;
        //    TempData["Get_details"] = "Student details";
        //    StudentDetails std = new StudentDetails();
        //    HttpResponseMessage response = client.GetAsync(url + Roll_No).Result;
        //    if (response != null)
        //    {
        //        string content = response.Content.ReadAsStringAsync().Result;
        //        var data = JsonConvert.DeserializeObject<StudentDetails>(content);
        //        if (data != null)
        //        {
        //            std = data;
        //        }
        //    }
        //    return View("Details",std);
        //}

        [HttpGet]
        public IActionResult Get_StudentResult()
        {
            TempData["Get_details"] = "Student result";
            //int Roll_No = 1;
            var Roll_No = HttpContext.Session.GetString("RollNumber");

            //if (HttpContext.Session.GetString("RollNumber") != "0")
            //{
            //    HttpContext.Session.SetString("RollNumber", Roll_No.ToString());
            //}

            TempData["Get_details"] = "Student result";
            Y2024 result = new Y2024();
            HttpResponseMessage response = client.GetAsync(Result_url + Roll_No).Result;
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Y2024>(content);
                if (data != null)
                {
                    result = data;
                }
            }
            return View(result);
        }

        //[HttpPost]
        //public IActionResult Get_StudentResult(string Name, int Roll_No)
        //{
        //    Roll_No = 1;
        //    TempData["Get_details"] = "Student result";
        //    Y2024 result = new Y2024();
        //    HttpResponseMessage response = client.GetAsync(Result_url + Roll_No).Result;
        //    if (response != null)
        //    {
        //        string content = response.Content.ReadAsStringAsync().Result;
        //        var data = JsonConvert.DeserializeObject<Y2024>(content);
        //        if (data != null)
        //        {
        //            result = data;
        //        }
        //    }
        //    return View();


        //}

        [HttpGet]
        public IActionResult Student_LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Student_LoginPage(int Roll_No,  string Password) 
        {
            //Apply Password validations

            HttpContext.Session.SetString("RollNumber", Roll_No.ToString());

            return View("Student_HomePage");
        }
        [HttpGet]
        public IActionResult Get_StudentAttendance()
        {
            return View();
        }


    }
}
