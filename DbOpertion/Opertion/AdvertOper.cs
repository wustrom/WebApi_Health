using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using Common.Extend;
using Common;
using System.Collections.Generic;
using DbOpertion.Models;

namespace DbOpertion.DBoperation
{
    public partial class AdvertOper : SingleTon<AdvertOper>
    {
        public string ConnString=ConfigurationManager.AppSettings["ConnString"].ToString();
                /// <summary>
        /// 插入
        /// </summary>
        /// <param name="advert"></param>
        /// <returns>是否成功</returns>
        public bool Insert(Advert advert)
        {
            StringBuilder sql = new StringBuilder("insert into Advert ");
            StringBuilder part1 = new StringBuilder();
            StringBuilder part2 = new StringBuilder();
            var parm = new DynamicParameters();
            bool flag = true;
            if(!advert.name.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("name");
                    part2.Append("@name");
                    flag = false;
                }
                else
                {
                    part1.Append(",name");
                    part2.Append(",@name");
                }
                parm.Add("name", advert.name);
            }
            if(!advert.img.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("img");
                    part2.Append("@img");
                    flag = false;
                }
                else
                {
                    part1.Append(",img");
                    part2.Append(",@img");
                }
                parm.Add("img", advert.img);
            }
            if(!advert.url.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("url");
                    part2.Append("@url");
                    flag = false;
                }
                else
                {
                    part1.Append(",url");
                    part2.Append(",@url");
                }
                parm.Add("url", advert.url);
            }

            sql.Append("(").Append(part1).Append(") values(").Append(part2).Append(")");

            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
            var r = conn.Execute(sql.ToString(), parm);
            conn.Close();
            return r > 0;
        }
    }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>是否成功</returns>
        public bool Delete(int id)
        {
            object parm = new { id = id };
            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
            var r = conn.Execute(@"Delete From Advert where id=@id",parm);
            conn.Close();
                return r > 0;
        }
    }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="advert"></param>
        /// <returns>是否成功</returns>
        public bool Update(Advert advert)
        {
            StringBuilder sql = new StringBuilder("update Advert set ");
            StringBuilder part1 = new StringBuilder();
            StringBuilder part2 = new StringBuilder();
            var parm = new DynamicParameters();
            bool flag = true;
            if(!advert.id.IsNullOrEmpty())
            {
                part2.Append("id = @id");
                parm.Add("id", advert.id);
            }
            if(!advert.name.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("name = @name");
                    flag = false;
                }
                else
                {
                    part1.Append(", name = @name");
                }
                parm.Add("name", advert.name);
            }
            if(!advert.img.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("img = @img");
                    flag = false;
                }
                else
                {
                    part1.Append(", img = @img");
                }
                parm.Add("img", advert.img);
            }
            if(!advert.url.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("url = @url");
                    flag = false;
                }
                else
                {
                    part1.Append(", url = @url");
                }
                parm.Add("url", advert.url);
            }

            sql.Append(part1).Append(" where ").Append(part2);
            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
            var r = conn.Execute(sql.ToString(), parm);
            conn.Close();
            return r > 0;
        }
    }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="advert"></param>
        /// <returns>对象列表</returns>
        public List<Advert> Select(Advert advert)
        {
            StringBuilder sql = new StringBuilder("Select ");
            if(!advert.Field.IsNullOrEmpty())
            {
                sql.Append(advert.Field);
            }
            else
            {
                sql.Append("*");
            }
            sql.Append(" from Advert ");
            StringBuilder part1 = new StringBuilder();
            var parm = new DynamicParameters();
            bool flag = true;
            if(!advert.id.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("id = @id");
                    flag = false;
                }
                else
                {
                    part1.Append(" and id = @id");
                }
                parm.Add("id", advert.id);
            }
            if(!advert.name.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("name = @name");
                    flag = false;
                }
                else
                {
                    part1.Append(" and name = @name");
                }
                parm.Add("name", advert.name);
            }
            if(!advert.img.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("img = @img");
                    flag = false;
                }
                else
                {
                    part1.Append(" and img = @img");
                }
                parm.Add("img", advert.img);
            }
            if(!advert.url.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("url = @url");
                    flag = false;
                }
                else
                {
                    part1.Append(" and url = @url");
                }
                parm.Add("url", advert.url);
            }

        if(!advert.GroupBy.IsNullOrEmpty())
        {
            part1.Append(" Group By ").Append(advert.GroupBy).Append(" ");
            flag = false;
        }
        if(!advert.OrderBy.IsNullOrEmpty())
        {
            part1.Append(" Order By ").Append(advert.OrderBy).Append(" ");
            flag = false;
        }
            if (!flag)
            {
                sql.Append(" where ");
            }
            sql.Append(part1);
            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
                var r = (List<Advert>)conn.Query<Advert>(sql.ToString(), parm);
                conn.Close();
                if(r == null)
                {
                    r = new List<Advert>();
                }
                return r;
            }
    }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="advert"></param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageNo">页面编号</param>
        /// <returns>对象列表</returns>
        public List<Advert> SelectByPage(Advert advert,int pageSize,int pageNo)
        {
            StringBuilder sql = new StringBuilder("Select Top ").Append(pageSize).Append(" ");
            if(!advert.Field.IsNullOrEmpty())
            {
                sql.Append(advert.Field);
            }
            else
            {
                sql.Append("*");
            }
            sql.Append(" from Advert ");
            StringBuilder part1 = new StringBuilder();
            StringBuilder part2 = new StringBuilder();
            StringBuilder strBuliderPage = new StringBuilder();
            var parm = new DynamicParameters();
            bool flag = true;
            if(!advert.id.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("id = @id");
                    flag = false;
                }
                else
                {
                    part1.Append(" and id = @id");
                }
                parm.Add("id", advert.id);
            }
            if(!advert.name.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("name = @name");
                    flag = false;
                }
                else
                {
                    part1.Append(" and name = @name");
                }
                parm.Add("name", advert.name);
            }
            if(!advert.img.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("img = @img");
                    flag = false;
                }
                else
                {
                    part1.Append(" and img = @img");
                }
                parm.Add("img", advert.img);
            }
            if(!advert.url.IsNullOrEmpty())
            {
                if (flag)
                {
                    part1.Append("url = @url");
                    flag = false;
                }
                else
                {
                    part1.Append(" and url = @url");
                }
                parm.Add("url", advert.url);
            }
        if(!flag)
        {
            strBuliderPage.Append(" and");
        }strBuliderPage.Append(" id not in (").Append("Select Top ").Append(pageSize * (pageNo - 1)).Append(" id from Advert ");
        if(!advert.GroupBy.IsNullOrEmpty())
        {
            strBuliderPage.Append(" Group By ").Append(advert.GroupBy).Append(" ");
            flag = false;
        }
        if(!advert.OrderBy.IsNullOrEmpty())
        {
            strBuliderPage.Append(" Order By ").Append(advert.OrderBy).Append(" ");
            flag = false;
        }
        strBuliderPage.Append(" )");
            if (!flag)
            {
                sql.Append(" where ");
            }
            sql.Append(part1).Append(strBuliderPage).Append(part1);
        if(!advert.GroupBy.IsNullOrEmpty())
        {
            part2.Append(" Group By ").Append(advert.GroupBy).Append(" ");
        }
        if(!advert.OrderBy.IsNullOrEmpty())
        {
            part2.Append(" Order By ").Append(advert.OrderBy).Append(" ");
        }
        sql.Append(part2);
            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
                var r = (List<Advert>)conn.Query<Advert>(sql.ToString(), parm);
                conn.Close();
                if(r == null)
                {
                    r = new List<Advert>();
                }
                return r;
        }
    }
        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>是否成功</returns>
        public List<Advert> SelectByIds(List<string> List_Id)
        {
            object parm = new { id = List_Id.ToArray() };
            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
                var r = (List<Advert>)conn.Query<Advert>("Select * From Advert where id in @id", parm);
                conn.Close();
                if(r == null)
                {
                    r = new List<Advert>();
                }
                return r;
        }
    }
    }
}
