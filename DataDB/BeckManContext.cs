using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LIS_Middleware.DataDB
{
    public partial class BeckManContext : DbContext
    {
        public BeckManContext()
        {
        }

        public BeckManContext(DbContextOptions<BeckManContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExOrder> ExOrders { get; set; }
        public virtual DbSet<TempOrder> TempOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=211.20.154.188,51200;Database=BeckMan;Trusted_Connection=True;Integrated Security=false;MultipleActiveResultSets=true;User ID=connector;Password=1qazse43W");
                // optionsBuilder.UseSqlServer("Server=192.168.1.35;Database=BeckMan;Trusted_Connection=True;Integrated Security=false;MultipleActiveResultSets=true;User ID=beckman;Password=beckman");
                optionsBuilder.UseSqlServer("Server=192.168.1.36;Database=BeckMan;Trusted_Connection=True;Integrated Security=false;MultipleActiveResultSets=true;User ID=newbeckman;Password=Jy-05320022");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<ExOrder>(entity =>
            {
                entity.ToTable("ExOrder");

                entity.HasIndex(e => new { e.WNo, e.Item }, "IX_ExOrder_SNO_item");

                entity.HasIndex(e => new { e.Barcode, e.Dwflag }, "IX_ExOrder_dwflag");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("barcode");

                entity.Property(e => e.Birth)
                    .HasMaxLength(9)
                    .HasColumnName("birth");

                entity.Property(e => e.CDate)
                    .HasMaxLength(8)
                    .HasColumnName("c_date");

                entity.Property(e => e.ChdV)
                    .HasMaxLength(80)
                    .HasColumnName("CHD_V");

                entity.Property(e => e.DeviceId)
                    .HasColumnName("DeviceID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Dwflag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("dwflag")
                    .HasDefaultValueSql("((0))")
                    .HasComment(" 0:初始狀態, 1:讀走醫令, 2:寫入報告, 3:讀走報告");

                entity.Property(e => e.Dworderdate)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("dworderdate")
                    .HasDefaultValueSql("('')")
                    .HasComment("讀走醫令日期時間");

                entity.Property(e => e.Dwreportdate)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("dwreportdate")
                    .HasDefaultValueSql("('')")
                    .HasComment("讀走報告日期時間");

                entity.Property(e => e.Equitemid)
                    .HasMaxLength(20)
                    .HasColumnName("equitemid");

                entity.Property(e => e.Examiner).HasMaxLength(10);

                entity.Property(e => e.High)
                    .HasMaxLength(50)
                    .HasColumnName("high");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("item");

                entity.Property(e => e.ListCreator).HasDefaultValueSql("((0))");

                entity.Property(e => e.Low)
                    .HasMaxLength(50)
                    .HasColumnName("low");

                entity.Property(e => e.MDate)
                    .HasMaxLength(8)
                    .HasColumnName("m_date");

                entity.Property(e => e.MTime)
                    .HasMaxLength(6)
                    .HasColumnName("m_time");

                entity.Property(e => e.Meno)
                    .HasMaxLength(1000)
                    .HasColumnName("meno");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.PId)
                    .HasMaxLength(10)
                    .HasColumnName("p_id");

                entity.Property(e => e.Result)
                    .HasMaxLength(10)
                    .HasColumnName("result");

                entity.Property(e => e.SDate)
                    .HasMaxLength(8)
                    .HasColumnName("s_date");

                entity.Property(e => e.Sample)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("sample")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sex)
                    .HasMaxLength(2)
                    .HasColumnName("sex");

                entity.Property(e => e.SpecimenState).HasMaxLength(10);

                entity.Property(e => e.VHigh)
                    .HasMaxLength(50)
                    .HasColumnName("v_high");

                entity.Property(e => e.VLow)
                    .HasMaxLength(50)
                    .HasColumnName("v_low");

                entity.Property(e => e.WNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("w_no");
            });

            modelBuilder.Entity<TempOrder>(entity =>
            {
                entity.ToTable("TempOrder");

                entity.HasIndex(e => new { e.Sno, e.Barcode }, "IX_TempOrder_SNO_barcode");

                entity.HasIndex(e => e.Status, "IX_TempOrder_status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("barcode");

                entity.Property(e => e.DataBase).HasMaxLength(20);

                entity.Property(e => e.DeviceId)
                    .HasColumnName("DeviceID")
                    .HasComment("處理檢體儀器");

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.ListCreator)
                    .HasDefaultValueSql("((0))")
                    .HasComment("開單所在");

                entity.Property(e => e.Mark)
                    .HasMaxLength(10)
                    .HasColumnName("mark");

                entity.Property(e => e.Pc)
                    .HasMaxLength(1)
                    .HasColumnName("pc");

                entity.Property(e => e.Sno)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("SNO");

                entity.Property(e => e.SpecimenId)
                    .HasMaxLength(2)
                    .HasColumnName("SpecimenID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SubBirthday).HasMaxLength(9);

                entity.Property(e => e.SubIdno)
                    .HasMaxLength(10)
                    .HasColumnName("SubIDNO");

                entity.Property(e => e.SubName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
