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
    public class BranchTypeController : BaseController<BranchType, FactbookContext>
    {
        #region Constructor

        public BranchTypeController(FactbookContext context) 
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<BranchTypeListView>> GetItems()
        {
            return await GetViewsAsync<BranchTypeListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<BranchTypeItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<BranchType>> PostItem(BranchType item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, BranchType item)
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

        protected override DataAccess<BranchType> LoadDataAccess()
        {
            return new DataAccess<BranchType>(Context, Context.BranchType);
        }

        protected override Func<int, BranchType> GetItemFunction()
        {
            return id => Context
                        .BranchType
                        .Include(x => x.Branches).ThenInclude(x => x.ArmedForce)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<BranchType>> GetItemsFunction()
        {
            return () => Context
                        .BranchType
                        .Include(x => x.Branches)
                        .AsEnumerable();
        }

        protected override Func<BranchType, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}