using System;
using System.Web.Mvc;
using GeoffBurnsTaskList.Models;

namespace GeoffBurnsTaskList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskListModel _taskList;
        private readonly IRepository<Commitment> _repository;

        public HomeController(IRepository<Commitment> repository, ITaskListModel taskListModel)
        {
            _taskList = taskListModel;
            _repository = repository;
        }

  
        public ActionResult Index()
        {
            return View(_taskList); 
        }
        public ActionResult DeleteAll()
        {
            _repository.DeleteAll();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View(new Commitment());
        }

        [HttpPost]
        public ViewResult Create(Commitment commitment)
        {
            if(commitment == null)
                commitment = new Commitment();
            if (!TryUpdateModel(commitment))
            {
                ViewBag.updateError = "Create Failure";
                ModelState.AddModelError("Create Failure","Could not update Task");
                return View(commitment);
            }
            try
            {
                _repository.Create(commitment);
                ModelState.Clear();
                return View("Create", new Commitment());
            }
            catch (Exception ex)
            {
                    ViewBag.updateError = ex.Message;
                    ModelState.AddModelError("Create Failure", ex);
                    return View(commitment);    
            }
        }
  
    }
}
