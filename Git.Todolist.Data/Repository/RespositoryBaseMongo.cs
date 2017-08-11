using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Git.Todolist.Core;
using Git.Todolist.Data.DBContext;

namespace Git.Todolist.Data.Repository
{
    public class RespositoryBaseMongo<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        public MongoDbContext dbcontext = new MongoDbContext();

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FindEntity(object keyValue)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindList(string strSql)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindList(Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindList(string strSql, DbParameter[] dbParameter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination)
        {
            bool isAsc = pagination.sord.ToLower() == "asc" ? true : false;
            string[] _order = pagination.sidx.Split(',');
            MethodCallExpression resultExp = null;
            //var tempData = dbcontext.DbSet<TEntity>();
            //foreach (string item in _order)
            //{
            //    string _orderPart = item;
            //    _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
            //    string[] _orderArry = _orderPart.Split(' ');
            //    string _orderField = _orderArry[0];
            //    bool sort = isAsc;
            //    if (_orderArry.Length == 2)
            //    {
            //        isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
            //    }
            //    var parameter = Expression.Parameter(typeof(TEntity), "t");
            //    var property = typeof(TEntity).GetProperty(_orderField);
            //    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            //    var orderByExp = Expression.Lambda(propertyAccess, parameter);
            //    resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(TEntity), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            //}


            //pagination.records = tempData.CountAsync;
            //tempData = tempData.Skip<TEntity>(pagination.rows * (pagination.page - 1)).Take<TEntity>(pagination.rows).AsQueryable();
            //return tempData.ToList();
            return null;
        }

        public int Insert(List<TEntity> entitys)
        {
            throw new NotImplementedException();
        }

        public int Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> IQueryable()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
