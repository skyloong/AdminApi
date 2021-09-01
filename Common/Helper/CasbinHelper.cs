using Casbin.Adapter.EFCore;
using Microsoft.EntityFrameworkCore;
using NetCasbin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper
{
    public class CasbinHelper
    {
        private readonly string _connection;
        private readonly string _confPath;
        public CasbinHelper(string connection, string confPath)
        {
            _connection = connection;
            _confPath = confPath;

            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                context.Database.EnsureCreated();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="buttonId"></param>
        /// <returns></returns>
        public bool HasPermissionForUser(string userId, string buttonId)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                var result = e.HasPermissionForUser(userId, buttonId);
                return result;
            }
        }

        /// <summary>
        /// 给用户添加角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool AddRoleForUser(string userId, string roleId)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                var result = e.AddRoleForUser(userId, roleId);
                return result;
            }
        }
        
        public void MuiltAction(Action<Enforcer> action)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                action.Invoke(e);
            }
        }

        public bool MuiltAction(Func<Enforcer, bool> action)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                return action.Invoke(e);
            }
        }

        public List<string> MuiltAction(Func<Enforcer, List<string>> action)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                return action.Invoke(e);
            }
        }

        /// <summary>
        /// 给用户添加角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public bool AddRolesForUser(string userId, IEnumerable<string> roleIds)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                var result = e.AddRolesForUser(userId, roleIds);
                return result;
            }
        }

        /// <summary>
        /// 判断用户是否有此角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool HasRoleForUser(string roleId, string userId)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                return e.HasRoleForUser(userId, roleId);
            }
        }
        /// <summary>
        /// 删除用户所属角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteRoleForUser(string roleId, string userId)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                var result = e.DeleteRoleForUser(userId, roleId);
                return result;
            }
        }
        /// <summary>
        /// 删除用户某个权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="buttonId"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public bool DeletePermissionForUser(string roleId, string buttonId, string method)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                var result = e.DeletePermissionForUser(roleId, buttonId, method);
                return result;
            }
        }

        /// <summary>
        /// 给角色添加按钮权限
        /// </summary>
        /// <param name="roleId">如：角色Id</param>
        /// <param name="buttonIds">如：/foo/1</param>
        /// <returns></returns>
        public bool AddPermissionForRole(string roleId, List<string> buttonIds)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                var result = e.AddPermissionForUser(roleId, buttonIds);
                return result;
            }
        }

        /// <summary>
        /// 给角色添加菜单权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menudId"></param>
        /// <returns></returns>
        public bool AddMenuForRole(string roleId, string menudId)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                var result = e.AddPermissionForUser(roleId, menudId);
                return result;
            }
        }

        /// <summary>
        /// 给角色添加按钮权限
        /// </summary>
        /// <param name="roleId">如：角色Id</param>
        /// <param name="buttonId">如：/foo/1</param>
        /// <returns></returns>
        public bool AddButtonForRole(string roleId, string buttonId)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                var result = e.AddPermissionForUser(roleId, buttonId);
                return result;
            }
        }
        /// <summary>
        /// 验证权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public bool Enforce(string roleId, string url)
        {
            var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
            using (var context = new CasbinDbContext<int>(options))
            {
                var efCoreAdapter = new EFCoreAdapter<int>(context);
                var e = new Enforcer(_confPath, efCoreAdapter);
                return e.Enforce(roleId, url);
            }
        }
    }
}
