using bulkAction.Data;
using bulkAction.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkAction.Controllers
{
    public class FruitController : Controller
    {
        private readonly ApplicationDbContexts _dbContext;
        public FruitController(ApplicationDbContexts dbContext) {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Fruits> list = _dbContext.fruits.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Fruits fruits)
        {
            _dbContext.fruits.Add(fruits);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var fruitDetail = _dbContext.fruits.Where(fr => fr.Id == id).FirstOrDefault();
            return View(fruitDetail);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var fruitDetail = _dbContext.fruits.Where(fr => fr.Id == id).FirstOrDefault();
            return View(fruitDetail);
        }
        [HttpPost]
        public IActionResult Edit(Fruits fruits)
        {
            var updateValue = _dbContext.fruits.Find(fruits.Id);
            updateValue.Name = fruits.Name;
            updateValue.price = fruits.price;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id) {
            var data = _dbContext.fruits.Find(Id);
            _dbContext.fruits.Remove(data);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
