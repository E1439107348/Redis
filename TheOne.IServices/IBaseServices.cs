using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TheOne.IServices
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        #region 1.0 增

        void Add(TEntity model);

        #endregion

        #region 2.0 删

        void Delete(TEntity model, bool isAddedDbContext);



        #endregion

        #region 3.0 改

        /// <summary>
        /// 编辑，约定model 是一个自定义的实体，没有追加到EF容器中的
        /// </summary>
        /// <param name="model"></param>
        void Edit(TEntity model, string[] propertyNames);


        #endregion

        #region 4.0 查

        #region 4.0.1 根据条件查询

        /// <summary>
        /// 带条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where);

        #endregion

        #region 4.0.2 排序查询

        /// <summary>
        /// 正序排序
        /// </summary>
        /// <typeparam name="TKey">表示要排序TEntity中的字段</typeparam>
        /// <param name="where"></param>
        /// <param name="keySelector">要排序的lambda表达式</param>
        /// <returns></returns>
        List<TEntity> QueryOrderByWhere<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> keySelector);


        /// <summary>
        /// 倒序排序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        List<TEntity> QueryOrderByDescWhere<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> keySelector);


        #endregion

        #region 4.0.3 连表查询

        /// <summary>
        /// 连表操作
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="tableNames">要连表的数组</param>
        /// <returns></returns>
        List<TEntity> QueryJoinWhere(Expression<Func<TEntity, bool>> where, string[] tableNames);


        #endregion

        #region 4.0.4 分页查询

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TKey">表示要排序TEntity中的字段</typeparam>
        /// <param name="pageindex">分页的页码</param>
        /// <param name="pagesize">页容量</param>
        /// <param name="totalcount">总条数</param>
        /// <param name="where">查询条件</param>
        /// <param name="keySelector">要排序的lambda表达式</param>
        /// <returns></returns>
        List<TEntity> GetListByPage<TKey>(int pageindex, int pagesize, out int totalcount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> keySelector, bool isDes = true);
        List<TEntity> PageWith<TKey>(List<Expression<Func<TEntity, bool>>> where, int page, int rows, out int total, Expression<Func<TEntity, TKey>> keySelector, bool isDes = true);

        #endregion

        #region 4.0.5 延时查询
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> WhereWithNoTracking(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> All(Expression<Func<TEntity, bool>> where);
        #endregion

        #endregion

        #region 5.0 调用存储过程

        /// <summary>
        /// 调用存储过程的方法
        /// </summary>
        /// <typeparam name="TEntity1">代表的是存储过程查询结果实体</typeparam>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="ps">存储过程的参数，system.data.sqlclient.SqlParameter[]</param>
        /// <returns></returns>
        List<TEntity1> QueryByProc<TEntity1>(string procName, params object[] ps);



        #endregion

        #region 6.0 统一保存

        /// <summary>
        /// 统一将EF容器对象中的所有代理类生成相应的sql语句发给db服务器执行
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        #endregion

        #region 7.0 执行sql返回状态

        /// <summary>
        /// 执行sql返回状态
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">参数</param>
        /// <returns>返回状态</returns>
        int ExecuteSqlCommand(string sql, params object[] ps);

        #endregion 
    }
}
