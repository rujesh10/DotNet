using krishmakc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace krishmakc.Controllers
{
    public class TextFileController : Controller
    {
        // GET: TextFile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReadFromTxtFile()
        {
            StreamReader sr = new StreamReader("C:\\Users\\USER\\source\\repos\\krishmakc\\Content\\myfile.txt");
            string lineTxt;
            string textFileContent="";
            while ((lineTxt = sr.ReadLine()) != null)
            {
                textFileContent = textFileContent +"\n"+ lineTxt;
            }
            ViewBag.TextFileContent = textFileContent;
            return View();
        }

        public ActionResult WriteToTxtFile()
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\USER\\source\\repos\\krishmakc\\Content\\myfile.txt"))
            {
                //foreach (string ln in textLines2)
                //{
                //    writer.WriteLine(ln);
                //}

                string myHobby = "My hobby is bababbabab";
                writer.WriteLine(myHobby,true);
            }
            
            return View();
        }
        public ActionResult StudentForm()
        {
            StudentModel newStudent = new StudentModel();
            return View(newStudent);
        }
        public ActionResult SaveStudent(StudentModel newStudent)
        {
            if(ModelState.IsValid)
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\USER\\source\\repos\\krishmakc\\Content\\myfile.txt",true))
                {
                    string studentInfo = newStudent.RollNo +","+ newStudent.FullName +"," +newStudent.Age + "," + newStudent.Address + "," + newStudent.ContactNo;
                    writer.WriteLine(studentInfo);
                }
                ViewBag.SuccessMessage = "Your Student Info is Saved";
                return View("StudentForm", new StudentModel());
            }
            else
            {
                return View("StudentForm", newStudent);
            }
            
        }
        public ActionResult Students()
        {
            StreamReader sr = new StreamReader("C:\\Users\\USER\\source\\repos\\krishmakc\\Content\\myfile.txt");
            string lineTxt;
            List<StudentModel> students = new List<StudentModel>();
            while ((lineTxt = sr.ReadLine()) != null)
            {
                string[] studentInfo = lineTxt.Split(',');
                StudentModel student = new StudentModel();
                student.RollNo =Convert.ToInt32( studentInfo[0]);
                student.FullName = studentInfo[1];
                student.Age = Convert.ToInt32(studentInfo[2]);
                student.Address = studentInfo[3];
                student.ContactNo = studentInfo[4];
                students.Add(student);
            }
            return View(students);
        }
    }
}