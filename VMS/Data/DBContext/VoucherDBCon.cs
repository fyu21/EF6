using System.Data.Entity;
using VMS.Models.Info;

namespace VMS.Data.DBContext
{
    
    public class VoucherDBCon : DbContext
    {
        public VoucherDBCon() : base("name=MyAPPDb")
        {

        }
        public DbSet<VoucherInfo> VoucherInfoes { get; set; }

        public DbSet<VoucherFormInfo> VoucherForms { get; set; }

        public DbSet<VoucherStatusInfo> VoucherStatus { get; set; }

        public DbSet<ExternalSystemInfo> ExternalSystems { get; set; }
        public DbSet<VoucherAllotmentInfo> VoucherAllotments { get; set; }
        public DbSet<VoucherBatchUploadInfo> VoucherBatchUploads { get; set; }

        public DbSet<PeriodInfo> Periods { get; set; }

    }
}
