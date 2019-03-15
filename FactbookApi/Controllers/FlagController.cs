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
    public class FlagController : BaseController<Flag, FactbookContext>
    {
        #region Constructor

        public FlagController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<FlagListView>> GetItems()
        {
            return await GetViewsAsync<FlagListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<FlagItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<Flag>> PostItem(Flag item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Flag item)
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

        protected override DataAccess<Flag> LoadDataAccess()
        {
            return new DataAccess<Flag>(Context, Context.Flag);
        }

        protected override Func<int, Flag> GetItemFunction()
        {
            return id => Context
                        .Flag
                        .Include(x => x.ArmedForceFlags).ThenInclude(x => x.ArmedForce).ThenInclude(x => x.Branches)
                        .Include(x => x.BranchFlags).ThenInclude(x => x.Branch).ThenInclude(x => x.ArmedForce)
                        .Include(x => x.BranchFlags).ThenInclude(x => x.Branch).ThenInclude(x => x.BranchType)
                        .Include(x => x.BranchFlags).ThenInclude(x => x.Branch).ThenInclude(x => x.BranchFlags).ThenInclude(x => x.Flag)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<Flag>> GetItemsFunction()
        {
            return () => Context
                        .Flag
                        .Include(x => x.ArmedForceFlags).ThenInclude(x => x.ArmedForce)
                        .Include(x => x.BranchFlags).ThenInclude(x => x.Branch)
                        .AsEnumerable();
        }

        protected override Func<Flag, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}