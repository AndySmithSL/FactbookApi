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
    public class ShipController : BaseController<Ship, FactbookContext>
    {
        #region Constructor

        public ShipController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<ShipListView>> GetItems()
        {
            return await GetViewsAsync<ShipListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<ShipItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<Ship>> PostItem(Ship item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Ship item)
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

        protected override DataAccess<Ship> LoadDataAccess()
        {
            return new DataAccess<Ship>(Context, Context.Ship);
        }

        protected override Func<int, Ship> GetItemFunction()
        {
            return id => Context
                        .Ship
                        .Include(x => x.Builder).ThenInclude(x => x.Ships)
                        .Include(x => x.ShipServices).ThenInclude(x => x.ShipSubType).ThenInclude(x => x.ShipType).ThenInclude(x => x.ShipCategory)
                        .Include(x => x.ShipServices).ThenInclude(x => x.ShipClass).ThenInclude(x => x.PrecedingClasses)
                        .Include(x => x.ShipServices).ThenInclude(x => x.ShipClass).ThenInclude(x => x.SucceedingClasses)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Branch).ThenInclude(x => x.BranchFlags).ThenInclude(x => x.Flag)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Branch).ThenInclude(x => x.BranchType)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Branch).ThenInclude(x => x.ArmedForce)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Ship)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<Ship>> GetItemsFunction()
        {
            return () => Context
                        .Ship
                        .Include(x => x.Builder)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Branch)
                        .Include(x => x.ShipServices).ThenInclude(x => x.ShipClass)
                        .Include(x => x.ShipServices).ThenInclude(x => x.ShipSubType)
                        .AsEnumerable();
        }

        protected override Func<Ship, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}