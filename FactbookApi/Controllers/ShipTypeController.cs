using FactbookApi.Code.Classes;
using FactbookApi.Context;
using FactbookApi.Data;
using FactbookApi.Models;
using FactbookApi.Views;
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
    public class ShipTypeController : BaseController<ShipType, FactbookContext>
    {
        #region Constructor

        public ShipTypeController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<ShipTypeListView>> GetItems()
        {
            return await GetViewsAsync<ShipTypeListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<ShipTypeItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<ShipType>> PostItem(ShipType item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ShipType item)
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

        protected override DataAccess<ShipType> LoadDataAccess()
        {
            return new DataAccess<ShipType>(Context, Context.ShipType);
        }

        protected override Func<int, ShipType> GetItemFunction()
        {
            return id => Context.ShipType
                                .Include(x => x.ShipCategory).ThenInclude(x => x.ShipTypes)
                                .Include(x => x.ShipSubTypes)
                                .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<ShipType>> GetItemsFunction()
        {
            return () => Context.ShipType.Include(x => x.ShipCategory)
                                .Include(x => x.ShipSubTypes);
        }

        protected override Func<ShipType, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods

    }
}