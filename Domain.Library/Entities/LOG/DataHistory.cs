using Domain.Library.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities.LOG
{
    /// <summary>
    /// تاریخچه تغییرات جداول
    /// </summary>
    [Table("DataHistory", Schema = "LOG"), Description("تاریخچه تغییرات جداول")]
    public partial class DataHistory
    {
        [Description("کد فرم")]
        [Key]
        public long ID { get; set; }

        [Description("نام جدول")]
        [StringLength(100)]
        public string TableName { get; set; }

        [Description("کد رکورد")]
        [StringLength(50)]
        public string RecordID { get; set; }

        [Description("نوع تغییر")]
        public LogTypeEnum Type { get; set; }

        [Description("داده قبلی")]
        public string Value { get; set; }

        [Description("داده جدید")]
        public string NewValue { get; set; }

        [Description("تاریخ تغییر")]
        public DateTime DateTime { get; set; }

        [Description("کاربر")]
        [StringLength(36)]
        public string User { get; set; }

        [Description("IP")]
        [StringLength(20)]
        public string IP { get; set; }

        [Description("نام کاربری")]
        public string UserName { get; set; }

        [Description("RequestUrl")]
        public string RequestUrl { get; set; }

        [Description("RequestMethod")]
        public string RequestMethod { get; set; }

        [Description("BatchKey")]
        [StringLength(40)]
        public string BatchKey { get; set; }

        [Description("EntityType")]
        //[StringLength(150)]
        public string EntityType { get; set; }

        public static DataHistory FromEntity(EntityEntry item)
        {
            if (item.Entity.GetType() == typeof(DataHistory))
                return null;

            var recordID = "0";
            //TODO: for newValues, recordId is zero! Or update it after savein DB
            if (item.State != EntityState.Added)
            {
                try
                {
                    //TODO: try another way to be sure it's correct value
                    //recordID = item.CurrentValues.GetValue<long>("ID").ToString();
                    //var originalValue = item.Property("ID").OriginalValue;
                    recordID = item.Property("ID").CurrentValue.ToString();
                }
                catch
                {
                }
                try
                {
                    recordID = item.Property("Id").CurrentValue.ToString();
                }
                catch
                {
                }
            }

            var value = "";
            var newValue = "";
            Dictionary<string, object> NewValues = null;
            if (item.State == EntityState.Modified)
            {
                var modifiedProperties = GetModifiedEntityProperties(item);
                NewValues = modifiedProperties.NewValues;
                if (modifiedProperties.Values.Count == 0 && modifiedProperties.NewValues.Count == 0)
                    return null;
                value = GetJson(modifiedProperties.Values);
                newValue = GetJson(modifiedProperties.NewValues);
            }
            else if (item.State == EntityState.Added)
            {
                newValue = GetJson(GetEntityProperties(item, false));
            }
            else if (item.State == EntityState.Deleted)
            {
                value = GetJson(GetEntityProperties(item, true));
            }

            Type type = item.Entity.GetType();
            type = type.Namespace == "Castle.Proxies" ? type.BaseType : type;

            var attributes = type.GetCustomAttributes(typeof(TableAttribute), true);
            var tableNameAttribute = attributes != null && attributes.Any() ? (TableAttribute)attributes[0] : null;

            var keyUpdate = "UpdateBy";
            var keyCreate = "CreateBy";

            var user = "";
            try
            {
                user = (NewValues != null && NewValues.ContainsKey(keyUpdate) ? NewValues[keyUpdate]
                  : NewValues != null && NewValues.ContainsKey(keyCreate) ? NewValues[keyCreate] : "").ToString();
            }
            catch { }
            if (string.IsNullOrEmpty(user))
            {
                try
                {
                    user = item.CurrentValues[keyUpdate]?.ToString();
                }
                catch { }
            }
            if (string.IsNullOrEmpty(user))
            {
                try
                {
                    user = item.CurrentValues[keyCreate]?.ToString();
                }
                catch { }
            }

            var history = new DataHistory
            {
                DateTime = DateTime.Now,
                Type = item.State == EntityState.Added ? LogTypeEnum.Added :
                       item.State == EntityState.Modified ? LogTypeEnum.Modified : LogTypeEnum.Deleted,
                Value = value,
                NewValue = newValue,
                TableName = tableNameAttribute != null ? tableNameAttribute.Name : type.Name,
                EntityType = $"{type.FullName}, {type.Assembly.FullName}",
                RecordID = recordID,
                User = user?.ToString(),

            };
            return history;
        }

        private static (Dictionary<string, object> Values, Dictionary<string, object> NewValues) GetModifiedEntityProperties(EntityEntry item)
        {
            var values = new Dictionary<string, object>();
            var newValues = new Dictionary<string, object>();
            var originalValues = item.GetDatabaseValues();

            foreach (var property in originalValues.Properties)
            {
                if (item.CurrentValues[property]?.ToString() != originalValues[property]?.ToString())
                {
                    values.Add(property.Name, originalValues[property]?.ToString());
                    newValues.Add(property.Name, item.CurrentValues[property]?.ToString());
                }
            }
            //foreach (var property in item.CurrentValues.Properties)
            //{
            //    if (item.CurrentValues[property]?.ToString() != item.OriginalValues[property]?.ToString())
            //    {
            //        values.Add(property.Name, item.OriginalValues[property]?.ToString());
            //        newValues.Add(property.Name, item.CurrentValues[property]?.ToString());
            //    }
            //}
            return (values, newValues);
        }

        private static Dictionary<string, object> GetEntityProperties(EntityEntry item, bool getOriginalValues)
        {
            var values = getOriginalValues ? item.OriginalValues : item.CurrentValues;
            return values.Properties.ToList().ToDictionary(d => d.Name, d => values[d]);
        }

        private static string GetJson(object entity)
        {
            //return Newtonsoft.Json.JsonConvert.SerializeObject(entity);
            return null;
        }

    }


    public partial class DataHistory
    {
        /// <summary>
        /// رخ دادهای سامانه
        /// </summary>
        [Table("NLogData", Schema = "LOG"), Description("رخ دادهای سامانه")]
        public class NLogData
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("کد رخ داد")]
            public long Id { get; set; }

            public string ContextTraceId { get; set; }

            [StringLength(200), Description("دسته بندی")]
            public string Category { get; set; }

            [StringLength(15), Description("IP")]
            public string IP { get; set; }

            [StringLength(200), Description("مشخصات مرورگر")]
            public string UserAgent { get; set; }

            [StringLength(5), Description("سطح")]
            public string Level { get; set; }

            [StringLength(100), Description("محل اجرا")]
            public string CallSite { get; set; }

            [Description("متن پیام")]
            public string Message { get; set; }

            [Description("ویژگی ها")]
            public string Properties { get; set; }

            [Description("خطا")]
            public string Exception { get; set; }

            [Description("تاریخ و زمان ثبت")]
            public DateTime InsertDate { get; set; }

            [Description("کد کاربر")]
            public long? InsertUserID { get; set; }

            [StringLength(256), Description("نام کاربری کاربر")]
            public string UserName { get; set; }

            [Description("هش سطر داده")]
            public string RecordHash { get; set; }
        }

        public class NLogDataConfiguration : IEntityTypeConfiguration<NLogData>
        {
            public void Configure(EntityTypeBuilder<NLogData> builder)
            {
            }
        }
    }





}