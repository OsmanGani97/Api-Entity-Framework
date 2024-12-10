using evipractice.Models;
using evipractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace evipractice.Controllers
{
    public class WorkersController(WorkerDbContext db, IWebHostEnvironment env) : Controller
    {
        

        public IActionResult Index()
        {
            var data = db.Workers.Include(x => x.WorkLogs).ToList();
            return View(data);
            
        }
        public IActionResult Create()
        {
            var model = new WorkerInputModel();
            model.WorkLogs.Add(new WorkLog { });
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(WorkerInputModel model, string operation = "")
        {
            if (operation == "add")
            {
                model.WorkLogs.Add(new WorkLog { });
                foreach (var item in ModelState.Values)
                {
                    item.Errors.Clear();
                    item.RawValue = null;
                }
            }
            if (operation.StartsWith("remove"))
            {
               
                int index = int.Parse(operation.Substring(operation.IndexOf("_") + 1));
                model.WorkLogs.RemoveAt(index);
                foreach (var item in ModelState.Values)
                {
                    item.Errors.Clear();
                    item.RawValue = null;
                }
            }
            if (operation == "insert")
            {
                if (ModelState.IsValid)
                {
                    var w = new Worker
                    {
                        Name = model.Name,
                        ContactNo = model.ContactNo,
                        Skill = model.Skill,
                        PayRate = model.PayRate ?? 0,
                        HireDate = model.HireDate,
                        IsActive = model.IsActive
                    };
                    string ext = Path.GetExtension(model.Picture.FileName);
                    string f = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string filePath = Path.Combine(env.WebRootPath, "Pictures", f);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    model.Picture.CopyTo(fs);
                    fs.Close();
                    w.Picture = f;
                    foreach (var wl in model.WorkLogs)
                    {
                        w.WorkLogs.Add(wl);
                    }
                    db.Workers.Add(w);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var w = db.Workers.FirstOrDefault(x => x.WorkerId == id);
            if (w == null) return NotFound();
            db.Workers.Remove(w);
            //db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
