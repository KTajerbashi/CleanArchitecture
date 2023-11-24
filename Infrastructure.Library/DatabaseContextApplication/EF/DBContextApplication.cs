using Domain.Library.Entities.BUS;
using Domain.Library.Entities.CNT;
using Domain.Library.Entities.GEN;
using Domain.Library.Entities.LOG;
using Domain.Library.Entities.RPT;
using Domain.Library.Entities.SEC;
using Domain.Library.Enums;
using Infrastructure.Library.DatabaseContextApplication.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json.Linq;
using System.Reflection;
using static Domain.Library.Entities.LOG.DataHistory;

namespace Infrastructure.Library.DatabaseContextApplication.EF
{
    public class DBContextApplication : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DBContextApplication(DbContextOptions<DBContextApplication> option) : base(option)
        {

        }
        #region CNT
        public DbSet<MenuLink> MenuLinks { get; set; }
        public DbSet<MenuRole> MenuRoles { get; set; }
        #endregion
        #region GEN
        public DbSet<FileObject> FileObjects { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        #endregion
        #region RPT
        public DbSet<UserReport> UserReports { get; set; }
        public DbSet<ProductReport> ProductReports { get; set; }
        public DbSet<Report> Reports { get; set; }
        #endregion
        #region BUS
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<FactorProduct> FactorProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        #endregion
        #region LOG
        public DbSet<DataHistory> DataHistories { get; set; }
        public DbSet<NLogData> NLogDatas { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region SEC
            builder.Entity<User>().ToTable("Users", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<Role>().ToTable("Roles", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<RoleClaim>().ToTable("RoleClaims", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<UserClaim>().ToTable("UserClaims", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<UserLogin>().ToTable("UserLogins", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive).HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            builder.Entity<UserRole>().ToTable("UserRoles", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive).HasKey(x => new { x.ID, x.UserId, x.RoleId });
            builder.Entity<UserToken>().ToTable("UserTokens", "SEC").HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<User>().HasIndex(x => x.NationalCode).IsUnique();
            #endregion

            #region BUS
            builder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<ProductDetail>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<ProductType>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<Author>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<Factor>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<FactorProduct>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            #endregion

            #region CNT
            builder.Entity<MenuLink>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<MenuRole>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            #endregion
            #region GEN
            builder.Entity<FileObject>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<Picture>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            #endregion
            #region LOG
            //builder.Entity<DataHistory>().HasQueryFilter(x => x.Value );
            builder.Entity<SystemLog>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<UserLog>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);

            #endregion

            #region RPT
            builder.Entity<ProductReport>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<Report>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            builder.Entity<UserReport>().HasQueryFilter(x => !x.IsDeleted && x.IsActive);
            #endregion

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            FluentApiConfiguration.Configurations(builder);
        }
        protected void Creating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        private void Configuration(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        private volatile bool isGeneratedDataHistory = false;
        public int SaveChanges(bool? ignoreDataHistory = default)
        {
            try
            {
                CleanString();

                (List<DataHistory> addHistory, List<EntityEntry> addEntity) data = (new List<DataHistory>(), new List<EntityEntry>());

                if (ignoreDataHistory == null || !ignoreDataHistory.Value)
                    data = GenerateDataChange();

                var saveResult = base.SaveChanges();

                if (ignoreDataHistory == null || !ignoreDataHistory.Value)
                    SaveDataChangeForAdd(data.addHistory, data.addEntity);

                return saveResult;
            }
            finally
            {
                isGeneratedDataHistory = false;
            }
        }
        public (List<DataHistory> addHistory, List<EntityEntry> addEntity) GenerateDataChange()
        {
            if (isGeneratedDataHistory)
                return (null, null);

            isGeneratedDataHistory = true;
            var logList = new List<DataHistory>();
            var addStateList = new List<DataHistory>();
            var addEntityList = new List<EntityEntry>();

            this.ChangeTracker.DetectChanges();

            foreach (var item in this.ChangeTracker.Entries())
            {
                if (item.State == EntityState.Added ||
                    item.State == EntityState.Deleted ||
                    item.State == EntityState.Modified)
                {
                    DataHistory history = DataHistory.FromEntity(item);
                    if (history != null)
                    {
                        //var httpContextAccessor = this.GetService<IHttpContextAccessor>();
                        //HttpContext context = httpContextAccessor.HttpContext;
                        //var request = context?.Request;

                        //history.IP = context?.Connection.RemoteIpAddress.ToString();
                        //history.RequestMethod = request?.Method;
                        //history.RequestUrl = request?.Path;
                        //history.UserName = context?.User.Identity.Name;

                        //logList.Add(history);
                    }

                    if (item.State == EntityState.Added)
                        addEntityList.Add(item);
                }
            }

            var batchKey = Guid.NewGuid().ToString();
            logList.ForEach(log =>
            {
                log.BatchKey = batchKey;
                if (log.Type == LogTypeEnum.Added)
                    addStateList.Add(log);
            });
            DataHistories.AddRange(logList);

            return (addStateList, addEntityList);
        }
        /// <summary>
        /// محتوایی که داره اینسرت یا اپدیت میشه حروف عربی اش را جایگزین میکند
        /// </summary>
        private void CleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                //اونایی که قابلیت خواندن و نوشتن دارند و از نوع استرینگ اند
                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    //اگر مقدار داشته باشد
                    //if (val.HasValue())
                    //{
                    //    var newVal = val.Fa2En().FixPersianChars();
                    //    if (newVal == val)
                    //        continue;
                    //    property.SetValue(item.Entity, newVal, null);
                    //}
                }
            }
        }

        public void SaveDataChangeForAdd(List<DataHistory> addHistory, List<EntityEntry> addEntity)
        {
            if (addHistory != null && addHistory.Any())
            {
                for (int i = 0; i < addHistory.Count; i++)
                {
                    addHistory[i].RecordID = addEntity[i].Properties.Where(c => c.Metadata.IsPrimaryKey()).Select(c => c.CurrentValue).FirstOrDefault()?.ToString();
                    var newValue = JObject.Parse(addHistory[i].NewValue);
                    if (newValue is null)
                        continue;

                    if (newValue.ContainsKey("ID"))
                    {
                        newValue["ID"] = addHistory[i].RecordID;
                    }
                    if (newValue.ContainsKey("Id"))
                    {
                        newValue["Id"] = addHistory[i].RecordID;
                    }
                    //addHistory[i].NewValue = JsonConverter.SerializeObject(newValue);
                }
            }
            base.SaveChanges();
        }
    }
}
