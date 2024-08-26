using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Student_Result_Management.Models;
using System.Net.Http;
using System.Text;

namespace Student_Result_Management.Controllers
{
    public class AdminController : Controller
    {
        private string url = "https://localhost:7042/api/StudentAPI/";
        private string Result_url = "https://localhost:7042/api/Students_Result/";
        private string AdminCred_url = "https://localhost:7042/api/AdminCredentials/";
        private string StudentCred_url = "https://localhost:7042/api/StudentCredentials/";
        private string StudentAttendance_url = "https://localhost:7042/api/StudentAttendance/";
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

        [HttpGet]
        public IActionResult Admin_LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Admin_LoginPage(int Admin_Id, string Admin_Password)
        {

            //HttpContext.Session.SetString("RollNumber", Admin_Id.ToString());

            HttpResponseMessage response = client.GetAsync(AdminCred_url + Admin_Id).Result;
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AdminCredential>(content);
                if (data != null)
                {
                    if(data.Password == Admin_Password)
                    {
                        return View("Index");
                    }else
                    {
                        ViewData["Login_Status"] = "Wrong credentials";
                    }
                }
                else { ViewData["Login_Status"] = "Not Exist"; }
            }
            return View();
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
                return RedirectToAction("Get_AllStudents");

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
                return RedirectToAction("Get_AllStudents");
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
        public IActionResult Delete(int id)
        {
            StudentDetails student = new StudentDetails();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response != null)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<StudentDetails>(result);
                if (data != null)
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


//########################################################################################################################
//#######################################################################         RESULT        ##########################

        [HttpGet]
        public IActionResult GetALL_StudentResult()
        {
            List<Y2024> result = new List<Y2024>();
            HttpResponseMessage response = client.GetAsync(Result_url).Result;
            if (response.IsSuccessStatusCode) 
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Y2024>>(content);
                if (data != null)
                {
                    result = data;
                }
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult AddNew_Result()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew_Result(Y2024 result) 
        {
            string data = JsonConvert.SerializeObject(result);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(Result_url,content).Result;
            if ((response.IsSuccessStatusCode))
            {
                return RedirectToAction("GetALL_StudentResult");
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Update_Result(int id)
        {
            Y2024 result = new Y2024();

            HttpResponseMessage response = client.GetAsync(Result_url+id).Result;
            if (response.IsSuccessStatusCode) 
            {
               string content = response.Content.ReadAsStringAsync().Result;
               var data = JsonConvert.DeserializeObject<Y2024>(content);
                if (data != null) 
                {
                    result = data;
                }
            }return View(result);
        }

        [HttpPost]
        public IActionResult Update_Result(Y2024 result)
        {
            var data = JsonConvert.SerializeObject(result);
            StringContent content = new StringContent(data, Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PutAsync(Result_url+result.RollNo, content).Result;
            if (response.IsSuccessStatusCode)
            {
               return RedirectToAction("GetALL_StudentResult");   
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Result(int id) 
        {
            Y2024 res = new Y2024();
            HttpResponseMessage response = client.GetAsync(Result_url + id).Result;
            if (response.IsSuccessStatusCode) 
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Y2024>(content);
                if (data != null) 
                {
                    res = data;
                }
            }return View(res);

        }

        [HttpGet]
        public IActionResult DeleteResult(int id)
        {
            Y2024 result = new Y2024();
            HttpResponseMessage response = client.GetAsync(Result_url + id).Result;
            if (response.IsSuccessStatusCode)
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

        [HttpPost, ActionName("DeleteResult")]
        public IActionResult DeleteResult_Confirmerd(int id) 
        {
            HttpResponseMessage response = client.DeleteAsync(Result_url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetALL_StudentResult");
            }
            return View();

        }


    }
}
