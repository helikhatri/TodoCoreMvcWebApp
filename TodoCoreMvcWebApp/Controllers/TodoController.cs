using Microsoft.AspNetCore.Mvc;
using TodoCoreMvcWebApp.Data;
using Task = TodoCoreMvcWebApp.Models.Task;

namespace TodoCoreMvcWebApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDatacontext _db;
        public TodoController(ApplicationDatacontext db)
        {
                _db = db;
        }
        public IActionResult Index(string searchText)
        {
            IEnumerable<Task> obj = _db.Tasks;
            if (!string.IsNullOrEmpty(searchText))
            {
                obj = obj.Where(task => task.Title.ToUpper().Contains(searchText.ToUpper()));
            }
            return View(obj);
        }

        //Get
        public IActionResult Create(Task task)
        {
            if (task == null)
            {
                return View();
            }
            return View(task);
        }

        //post
        [HttpPost, ActionName("Create")]
        public IActionResult CreateTask(Task task)
        {
            if (task == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (task.Id > 0)
                {
                    task.UpdatedDate = DateTime.Now;
                    _db.Tasks.Update(task);
                }
                else
                {
                    _db.Tasks.Add(task);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        //Get
        public IActionResult Edit(int id)
        {
            var obj = _db.Tasks.Where(task => task.Id == id).FirstOrDefault();
            return RedirectToAction("Create", obj);
        }

        //Get
        public IActionResult Delete(int id)
        {
            var obj = _db.Tasks.Where(task => task.Id == id).FirstOrDefault();
            if (obj != null)
            {
                _db.Tasks.Remove(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Get
        public IActionResult Clone(int id)
        {
            var obj = _db.Tasks.Where(task => task.Id == id).FirstOrDefault();
            if (obj != null)
            {
                var cloneObj = obj.DeepCopy();
                _db.Tasks.Add(cloneObj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateStatus(Task task)
        {
            var taskObj = _db.Tasks.Where(t => t.Id == task.Id).FirstOrDefault();
            if (taskObj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (task.Id > 0)
                {
                    taskObj.Status = task.Status;
                    taskObj.UpdatedDate = DateTime.Now;
                    _db.Tasks.Update(taskObj);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
