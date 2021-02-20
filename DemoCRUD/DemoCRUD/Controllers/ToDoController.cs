using DemoCRUD.Infrastructure;
using DemoCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCRUD.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext context;

        public ToDoController(ToDoContext context)
        {
            this.context = context;
        }
        // Get
        public async Task<ActionResult> Index()
        {
            IQueryable<TodoList> items =
                from i in context.ToDoList
                orderby i.id
                select i;
            List<TodoList> todoLists = await items.ToListAsync();
            return View(todoLists);
        }

        //Get /todo/create
        public IActionResult Create() => View();

        //Post /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();
                TempData["Create"] = "新增的項目已經增加了!" + item.Content;
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // Get /todo/edit/
        public async Task<ActionResult> Edit(int id)
        {
            TodoList item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //Post /todo/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();
                TempData["Edit"] = "新增的項目已經修改了!" + item.Content;
                return RedirectToAction("Index");
            }
            return View(item);
        }
       
        // Get /todo/delet
        public async Task<ActionResult> Delete(int id)
        {
            TodoList item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "這個項目已經不存在了";
            }
            else
            {

                context.ToDoList.Remove(item);
                await context.SaveChangesAsync();
                TempData["Remove"] = item.Content + "已經被刪除了!";


            }
            return RedirectToAction("Index");
        }



    }
}
