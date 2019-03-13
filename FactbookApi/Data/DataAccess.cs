using FactbookApi.Code.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactbookApi.Data
{
    public class DataAccess<T>
        where T : class
    {
        #region Private Declarations

        private DbSet<T> dataSet = null;
        private DbContext context = null;

        #endregion Private Declarations

        #region Public Properties

        public DbSet<T> DataSet
        {
            get => dataSet ?? throw new NullReferenceException("The dataSet has not been set.");
            set => dataSet = value;
        }

        public DbContext Context
        {
            get => context ?? throw new NullReferenceException("The context object has not been set.");
            set => context = value;
        }

        #endregion Public Properties

        #region Constructor

        public DataAccess(DbContext context, DbSet<T> dataSet)
        {
            Context = context;
            DataSet = dataSet;
        }

        #endregion Constructor

        #region Methods

        #region Get Items

        //public virtual IQueryable<T> GetItems()
        //{
        //    return from item in DataSet
        //           select item;
        //}

        public virtual IEnumerable<T> GetItems(Func<IEnumerable<T>> itemFunc)
        {
            return itemFunc();
        }

        //public Task<IEnumerable<T>> GetItemsAsync()
        //{
        //    return Task<IEnumerable<T>>.Factory.StartNew(() => GetItems());
        //}

        public Task<IEnumerable<T>> GetItemsAsync(Func<IEnumerable<T>> itemFunc)
        {
            return Task<IEnumerable<T>>.Factory.StartNew(() => GetItems(itemFunc));
        }

        #endregion Get Items

        #region Get Item

        //public T GetItem(int id)
        //{
        //    return DataSet.Find(id);
        //}

        public T GetItem(int id, Func<int, T> itemFunc)
        {
            return itemFunc(id);
        }

        //public Task<T> GetItemAsync(int id)
        //{
        //    return Task<T>.Factory.StartNew(() => GetItem(id));
        //}

        public Task<T> GetItemAsync(int id, Func<int, T> itemFunc)
        {
            return Task<T>.Factory.StartNew(() => GetItem(id, itemFunc));
        }

        #endregion Get Item

        #region Get Item Views

        //public ICollection<TItemView> GetItemViews()
        //{
        //    return GetItemViews(GetItems);
        //}

        //public ICollection<TItemView> GetItemViews(Func<IEnumerable<T>> function)
        //{
        //    return GetViews<TItemView>(function);
        //}

        //public Task<ICollection<TItemView>> GetItemViewsAsync()
        //{
        //    return Task<ICollection<TItemView>>.Factory.StartNew(() => GetItemViews());
        //}

        //public Task<ICollection<TItemView>> GetItemViewsAsync(Func<IEnumerable<T>> function)
        //{
        //    return Task<ICollection<TItemView>>.Factory.StartNew(() => GetItemViews(function));
        //}

        #endregion Get Item Views

        #region Get Item View

        //public TItemView GetItemView(int id)
        //{
        //    return GetItemView(id, GetItem);
        //}

        //public TItemView GetItemView(int id, Func<int, T> itemFunc)
        //{
        //    return GetView<TItemView>(id, itemFunc);
        //}

        //public Task<TItemView> GetItemViewAsync(int id)
        //{
        //    return Task<TItemView>.Factory.StartNew(() => GetItemView(id));
        //}

        //public Task<TItemView> GetItemViewAsync(int id, Func<int, T> function)
        //{
        //    return Task<TItemView>.Factory.StartNew(() => GetItemView(id, function));
        //}

        #endregion Get Item View

        #region Get List Views

        //public ICollection<TListView> GetListViews()
        //{
        //    return GetListViews(GetItems);
        //}

        //public ICollection<TListView> GetListViews(Func<IEnumerable<T>> function)
        //{
        //    return GetViews<TListView>(function);
        //}

        //public Task<ICollection<TListView>> GetListViewsAsync()
        //{
        //    return Task<ICollection<TListView>>.Factory.StartNew(() => GetListViews());
        //}

        //public Task<ICollection<TListView>> GetListViewsAsync(Func<IEnumerable<T>> function)
        //{
        //    return Task<ICollection<TListView>>.Factory.StartNew(() => GetListViews(function));
        //}

        #endregion Get Item Views

        #region Get List View

        //public TListView GetListView(int id)
        //{
        //    return GetListView(id, GetItem);
        //}

        //public TListView GetListView(int id, Func<int, T> itemFunc)
        //{
        //    return GetView<TListView>(id, itemFunc);
        //}

        //public Task<TListView> GetListViewAsync(int id)
        //{
        //    return Task<TListView>.Factory.StartNew(() => GetListView(id));
        //}

        //public Task<TListView> GetListViewAsync(int id, Func<int, T> function)
        //{
        //    return Task<TListView>.Factory.StartNew(() => GetListView(id, function));
        //}

        #endregion Get List View

        #region Generic Get View / Views

        public ICollection<TView> GetViews<TView>(Func<IEnumerable<T>> function)
            where TView : IView<T>, new()
        {
            ICollection<TView> result = new List<TView>();
            foreach (var item in function())
            {
                TView view = new TView();
                view.ViewObject = item;
                result.Add(view);
            }
            return result;
        }

        public Task<ICollection<TView>> GetViewsAsync<TView>(Func<IEnumerable<T>> function)
            where TView : IView<T>, new()
        {
            return Task<ICollection<TView>>.Factory.StartNew(() => GetViews<TView>(function));
        }

        public TView GetView<TView>(int id, Func<int, T> itemFunc)
            where TView : IView<T>, new()
        {
            TView view = new TView();
            view.ViewObject = GetItem(id, itemFunc);
            return view;
        }

        public Task<TView> GetViewAsync<TView>(int id, Func<int, T> function)
            where TView : IView<T>, new()
        {
            return Task<TView>.Factory.StartNew(() => GetView<TView>(id, function));
        }

        #endregion Generic Get View / Views

        #region Other Methods

        public bool ItemExists(Func<T, bool> predicate)
        {
            return DataSet.Any(predicate);
        }

        public void Add(T item)
        {
            DataSet.Add(item);
        }

        public void Delete(T item)
        {
            DataSet.Remove(item);
        }

        public void Update(T item)
        {
            Context.Entry<T>(item).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }

        #endregion Other Methods

        #endregion Methods
    }
}
