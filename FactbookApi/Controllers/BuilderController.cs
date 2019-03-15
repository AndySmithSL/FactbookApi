using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactbookApi.Code.Classes;
using FactbookApi.Context;
using FactbookApi.Data;
using FactbookApi.Models;
using FactbookApi.Views.ItemView;
using FactbookApi.Views.ListView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FactbookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuilderController : BaseController<Builder, FactbookContext>
    {
        #region Constructor

        public BuilderController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<BuilderListView>> GetItems()
        {
            return await GetViewsAsync<BuilderListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<BuilderItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<Builder>> PostItem(Builder item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Builder item)
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

        protected override DataAccess<Builder> LoadDataAccess()
        {
            return new DataAccess<Builder>(Context, Context.Builder);
        }

        protected override Func<int, Builder> GetItemFunction()
        {
            return id => Context
                        .Builder
                        .Include(x => x.Ships).ThenInclude(x => x.ShipServices).ThenInclude(x => x.ShipSubType)
                        .Include(x => x.Ships).ThenInclude(x => x.ShipServices).ThenInclude(x => x.Branch)
                        .Include(x => x.Ships).ThenInclude(x => x.ShipServices).ThenInclude(x => x.ShipClass)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<Builder>> GetItemsFunction()
        {
            return () => Context
                        .Builder
                        .Include(x => x.Ships)
                        .AsEnumerable();
        }

        protected override Func<Builder, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}