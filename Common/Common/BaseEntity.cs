using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BaseEntity
    {
        /// <summary>
        /// Get Type
        /// </summary>
        /// <returns></returns>
        public Type GetEntityType()
        {
            return this.GetType();
        }
        /// <summary>
        /// Danh property Required
        /// </summary>
        /// <returns></returns>
        public List<PropertyInfo> GetListPropertiesRequired()
        {
            //return this.GetEntityType().GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(RequiredAttribute))).ToList();
            return this.GetEntityType().GetProperties().Where(x => x.GetCustomAttribute<RequiredAttribute>(true) != null).ToList();

        }
        /// <summary>
        /// Danh sách propterty Key
        /// </summary>
        /// <returns></returns>
        public List<PropertyInfo> GetListPropertiesKey()
        {
            //return this.GetEntityType().GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(KeyAttribute))).ToList();
            return this.GetEntityType().GetProperties().Where(x => x.GetCustomAttribute<KeyAttribute>(true) != null).ToList();

        }
        /// <summary>
        /// Danh sách property Column
        /// </summary>
        /// <returns></returns>
        public List<PropertyInfo> GetListPropertiesColumn()
        {
            //return this.GetEntityType().GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(ColumnAttribute))).ToList();
            return this.GetEntityType().GetProperties().Where(x => x.GetCustomAttribute<ColumnAttribute>(true) != null).ToList();
        }
        /// <summary>
        /// Lấy ra displayName của prop
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        public string GetDisplayNameOfProperty(string propName)
        {
            var listProp = this.GetType().GetProperty(propName);
            if (listProp != null && listProp.GetCustomAttribute<DisplayNameAttribute>(true) != null)
            {
                return (listProp.GetCustomAttribute<DisplayNameAttribute>(true)).DisplayName;
            }
            return null;
        }
    }
}
