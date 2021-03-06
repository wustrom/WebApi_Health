using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Sleep
    {
        /// <summary>
        ///
        /// </summary>
        public Int32 id { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32 cid { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String sleepTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String wakeTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String cycle { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Boolean enable { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32 advanceMinutes { get; set; }
        /// <summary>
        /// 获取对应主键
        /// </summary>
        public string GetBuilderPrimaryKey()
        {
            return "id";
        }
        /// <summary>
        /// 排序语句格式为 字段名,字段名,字段名...
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// 排序语句 字段名,字段名,字段名...
        /// </summary>
        public string GroupBy { get; set; }
        /// <summary>
        /// 筛选字段
        /// </summary>
        public string Field { get; set; }

}
}
