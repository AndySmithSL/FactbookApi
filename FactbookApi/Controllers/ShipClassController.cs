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
    public class ShipClassController : BaseController<ShipClass, FactbookContext>
    {
        #region Constructor

        public ShipClassController(FactbookContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<ShipClassListView>> GetItems()
        {
            return await GetViewsAsync<ShipClassListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return await GetViewAsync<ShipClassItemView>(id);
        }

        [HttpPost]
        public async Task<ActionResult<ShipClass>> PostItem(ShipClass item)
        {
            return await PostAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ShipClass item)
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

        protected override DataAccess<ShipClass> LoadDataAccess()
        {
            return new DataAccess<ShipClass>(Context, Context.ShipClass);
        }

        protected override Func<int, ShipClass> GetItemFunction()
        {
            return id => Context
                        .ShipClass
                        .Include(x => x.ShipServices).ThenInclude(x => x.Ship).ThenInclude(x => x.Builder)
                        .Include(x => x.ShipServices).ThenInclude(x => x.ShipSubType).ThenInclude(x => x.ShipType).ThenInclude(x => x.ShipCategory)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Branch).ThenInclude(x => x.BranchType)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Branch).ThenInclude(x => x.ArmedForce)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Branch).ThenInclude(x => x.BranchFlags).ThenInclude(x => x.Flag)
                        .Include(x => x.PrecedingClasses).ThenInclude(x => x.PrecedingShipClass).ThenInclude( x=> x.ShipServices).ThenInclude(x => x.Ship)
                        .Include(x => x.PrecedingClasses).ThenInclude(x => x.SucceedingShipClass)
                        .Include(x => x.SucceedingClasses).ThenInclude(x => x.PrecedingShipClass)
                        .Include(x => x.SucceedingClasses).ThenInclude(x => x.SucceedingShipClass).ThenInclude(x => x.ShipServices).ThenInclude(x => x.Ship)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<ShipClass>> GetItemsFunction()
        {
            return () => Context
                        .ShipClass
                        .Include(x => x.PrecedingClasses)
                        .Include(x => x.SucceedingClasses)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Branch)
                        .Include(x => x.ShipServices).ThenInclude(x => x.ShipSubType)
                        .Include(x => x.ShipServices).ThenInclude(x => x.Ship)
                        .Include(x => x.ShipServices).ThenInclude(x => x.ShipClass)
                        .AsEnumerable();
        }

        protected override Func<ShipClass, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}