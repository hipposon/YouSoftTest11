using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouSoftTest1.Models;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Diagnostics;

namespace YouSoftTest1.Controllers
{
    public class HomeController : Controller
    {
        MainDBEntities MainDBEntities = new MainDBEntities();       

        public async Task<ActionResult> Index(int page = 1)
        {
            var itemsOnPage = 25; //кол-во элементов(строк в таблице) на странице

            IQueryable<Table> source = MainDBEntities.Table;
            var count = await source.CountAsync();
            if (page <= 0) page = (count/itemsOnPage) + 1; //если вызывается последняя страница
            var items = await source.OrderBy(x =>x.Id).Skip((page - 1) * itemsOnPage).Take(itemsOnPage).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, itemsOnPage);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Tables = items
            };
            return View(viewModel);

            /*

            var pageNumber = (page ?? 1);
            var Table = MainDBEntities.Table.ToList<Table>(); //лист элементов таблицы  
            return View(Table.ToPagedList(pageNumber, itemsOnPage)); */
        }
    }
}