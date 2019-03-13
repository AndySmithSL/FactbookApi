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
    public class ArmedForceFlagController : BaseController<ArmedForceFlag, FactbookContext>
    {
        #region Constructor

        public ArmedForceFlagController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<ArmedForceFlagListView>> GetItems()
        {
            return await GetViewsAsync<ArmedForceFlagListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<ArmedForceFlagItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<ArmedForceFlag>> PostItem(ArmedForceFlag item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ArmedForceFlag item)
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

        protected override DataAccess<ArmedForceFlag> LoadDataAccess()
        {
            return new DataAccess<ArmedForceFlag>(Context, Context.ArmedForceFlag);
        }

        protected override Func<int, ArmedForceFlag> GetItemFunction()
        {
            return id => Context
                        .ArmedForceFlag
                        .Include(x => x.ArmedForce).ThenInclude(x => x.Branches)
                        .Include(x => x.Flag)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<ArmedForceFlag>> GetItemsFunction()
        {
            return () => Context
                        .ArmedForceFlag
                        .Include(x => x.ArmedForce)
                        .Include(x => x.Flag)
                        .AsEnumerable();
        }

        protected override Func<ArmedForceFlag, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}