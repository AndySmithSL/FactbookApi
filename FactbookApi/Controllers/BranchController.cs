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
    public class BranchController : BaseController<Branch, FactbookContext>
    {
        #region Constructor

        public BranchController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<BranchListView>> GetItems()
        {
            return await GetViewsAsync<BranchListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<BranchItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<Branch>> PostItem(Branch item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Branch item)
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

        protected override DataAccess<Branch> LoadDataAccess()
        {
            return new DataAccess<Branch>(Context, Context.Branch);
        }

        protected override Func<int, Branch> GetItemFunction()
        {
            return id => Context
                        .Branch
                        .Include(x => x.BranchType).ThenInclude(x => x.Branches)
                        .Include(x => x.ArmedForce).ThenInclude(x => x.Branches)
                        .Include(x => x.ArmedForce).ThenInclude(x => x.ArmedForceFlags).ThenInclude(x => x.Flag)
                        .Include(x => x.BranchFlags).ThenInclude(x => x.Flag)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<Branch>> GetItemsFunction()
        {
            return () => Context
                        .Branch
                        .Include(x => x.ArmedForce)
                        .Include(x => x.BranchType)
                        .Include(x => x.BranchFlags).ThenInclude(x => x.Flag)
                        .AsEnumerable();
        }

        protected override Func<Branch, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}