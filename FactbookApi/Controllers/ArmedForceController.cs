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
    public class ArmedForceController : BaseController<ArmedForce, FactbookContext>
    {
        #region Constructor

        public ArmedForceController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<ArmedForceListView>> GetItems()
        {
            return await GetViewsAsync<ArmedForceListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {

            return await GetViewAsync<ArmedForceItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<ArmedForce>> PostItem(ArmedForce item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ArmedForce item)
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

        protected override DataAccess<ArmedForce> LoadDataAccess()
        {
            return new DataAccess<ArmedForce>(Context, Context.ArmedForce);
        }

        protected override Func<int, ArmedForce> GetItemFunction()
        {
            return id => Context
                        .ArmedForce
                        .Include(x => x.ArmedForceFlags).ThenInclude(x => x.Flag)
                        .Include(x => x.Branches).ThenInclude(x => x.BranchType)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<ArmedForce>> GetItemsFunction()
        {
            return () => Context
                        .ArmedForce
                        .Include(x => x.ArmedForceFlags).ThenInclude(x => x.Flag)
                        .Include(x => x.Branches)
                        .AsEnumerable();
        }

        protected override Func<ArmedForce, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}