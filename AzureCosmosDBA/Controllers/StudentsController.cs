using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using AzureCosmosDBA.Models;
using AzureCosmosDBA.Data;


namespace AzureCosmosDBA.Controllers
{
    public class StudentsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var students = await StudentDocumentDB<Students>.GetStudentsList();
            return View(students);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Surname,Email,Mobile,Telephone,IsActive")]Students student)
        {
            if (ModelState.IsValid)
            {
                await StudentDocumentDB<Students>.CreateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Students student = await StudentDocumentDB<Students>.GetStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Surname,Email,Mobile,Telephone,IsActive")]Students student)
        {
            if (ModelState.IsValid)
            {
                await StudentDocumentDB<Students>.UpdateStudent(student.Id , student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Students student = await StudentDocumentDB<Students>.GetStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed([Bind(Include = "Id")] string id)
        {
            await StudentDocumentDB<Students>.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(string id)
        {
            Students student = await StudentDocumentDB<Students>.GetStudent(id);
            return View(student);
        }
    }
}