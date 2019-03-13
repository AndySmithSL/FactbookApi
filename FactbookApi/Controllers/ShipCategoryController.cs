using FactbookApi.Code.Classes;
using FactbookApi.Context;
using FactbookApi.Data;
using FactbookApi.Models;
using FactbookApi.Views.ItemView;
using FactbookApi.Views.ListView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactbookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipCategoryController : BaseController<ShipCategory, FactbookContext>
    {
        #region Constructor

        public ShipCategoryController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<ShipCategoryListView>> GetItems()
        {
            return await GetViewsAsync<ShipCategoryListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<ShipCategoryItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<ShipCategory>> PostItem(ShipCategory item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ShipCategory item)
        {
            return await PutAsync(id, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            return await DeleteAsync(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<ShipCategory> LoadDataAccess()
        {
            return new DataAccess<ShipCategory>(Context, Context.ShipCategory);
        }

        protected override Func<int, ShipCategory> GetItemFunction()
        {
            return id => Context
                        .ShipCategory
                        .Include(x => x.ShipTypes).ThenInclude(x => x.ShipSubTypes)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<ShipCategory>> GetItemsFunction()
        {
            return () => Context
                        .ShipCategory
                        .Include(x => x.ShipTypes).ThenInclude(x => x.ShipSubTypes);
        }

        protected override Func<ShipCategory, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}