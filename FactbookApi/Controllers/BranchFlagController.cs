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
    public class BranchFlagController : BaseController<BranchFlag, FactbookContext>
    {
        #region Constructor

        public BranchFlagController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<BranchFlagListView>> GetItems()
        {
            return await GetViewsAsync<BranchFlagListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<BranchFlagItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<BranchFlag>> PostItem(BranchFlag item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, BranchFlag item)
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

        protected override DataAccess<BranchFlag> LoadDataAccess()
        {
            return new DataAccess<BranchFlag>(Context, Context.BranchFlag);
        }

        protected override Func<int, BranchFlag> GetItemFunction()
        {
            return id => Context
                        .BranchFlag
                        .Include(x => x.Branch).ThenInclude(x => x.ArmedForce)
                        .Include(x => x.Branch).ThenInclude(x => x.BranchType)
                        .Include(x => x.Branch).ThenInclude(x => x.BranchFlags).ThenInclude(x => x.Flag)
                        .Include(x => x.Flag).ThenInclude(x => x.ArmedForceFlags).ThenInclude(x => x.Flag)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<BranchFlag>> GetItemsFunction()
        {
            return () => Context
                        .BranchFlag
                        .Include(x => x.Branch)
                        .Include(x => x.Flag)
                        .AsEnumerable();
        }

        protected override Func<BranchFlag, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}