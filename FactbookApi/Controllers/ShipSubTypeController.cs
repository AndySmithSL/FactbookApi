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
    public class ShipSubTypeController :  BaseController<ShipSubType, FactbookContext>
    {
        #region Constructor

        public ShipSubTypeController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<ShipSubTypeListView>> GetItems()
        {
            return await GetViewsAsync<ShipSubTypeListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<ShipSubTypeItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<ShipSubType>> PostItem(ShipSubType item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ShipSubType item)
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

        protected override DataAccess<ShipSubType> LoadDataAccess()
        {
            return new DataAccess<ShipSubType>(Context, Context.ShipSubType);
        }

        protected override Func<int, ShipSubType> GetItemFunction()
        {
            return id => Context
                        .ShipSubType
                        .Include(x => x.ShipType).ThenInclude(x => x.ShipCategory)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<ShipSubType>> GetItemsFunction()
        {
            return () => Context
                        .ShipSubType
                        .Include(x => x.ShipType).ThenInclude(x => x.ShipCategory)
                        .AsEnumerable();
        }

        protected override Func<ShipSubType, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}
