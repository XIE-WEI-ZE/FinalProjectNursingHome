using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjFinalProjectApi.Models;

public partial class DbNursingHomeContext : DbContext
{
    public DbNursingHomeContext()
    {
    }

    public DbNursingHomeContext(DbContextOptions<DbNursingHomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CareAssignment> CareAssignments { get; set; }

    public virtual DbSet<CareRequest> CareRequests { get; set; }

    public virtual DbSet<Caregiver> Caregivers { get; set; }

    public virtual DbSet<CommunityAttachment> CommunityAttachments { get; set; }

    public virtual DbSet<CommunityAuditLog> CommunityAuditLogs { get; set; }

    public virtual DbSet<CommunityBoard> CommunityBoards { get; set; }

    public virtual DbSet<CommunityChatAttachment> CommunityChatAttachments { get; set; }

    public virtual DbSet<CommunityChatMessage> CommunityChatMessages { get; set; }

    public virtual DbSet<CommunityChatRoom> CommunityChatRooms { get; set; }

    public virtual DbSet<CommunityChatRoomMember> CommunityChatRoomMembers { get; set; }

    public virtual DbSet<CommunityFavorite> CommunityFavorites { get; set; }

    public virtual DbSet<CommunityFollow> CommunityFollows { get; set; }

    public virtual DbSet<CommunityInteraction> CommunityInteractions { get; set; }

    public virtual DbSet<CommunityMessage> CommunityMessages { get; set; }

    public virtual DbSet<CommunityNotification> CommunityNotifications { get; set; }

    public virtual DbSet<CommunityPost> CommunityPosts { get; set; }

    public virtual DbSet<CommunityPostTag> CommunityPostTags { get; set; }

    public virtual DbSet<CommunityReply> CommunityReplies { get; set; }

    public virtual DbSet<CommunityReport> CommunityReports { get; set; }

    public virtual DbSet<CommunityReportedContent> CommunityReportedContents { get; set; }

    public virtual DbSet<CommunityTag> CommunityTags { get; set; }

    public virtual DbSet<CommunityTicket> CommunityTickets { get; set; }

    public virtual DbSet<CommunityUserProfile> CommunityUserProfiles { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAnnualLeaveBalance> EmployeeAnnualLeaveBalances { get; set; }

    public virtual DbSet<EmployeeApprovalFlowTemplate> EmployeeApprovalFlowTemplates { get; set; }

    public virtual DbSet<EmployeeApprovalLog> EmployeeApprovalLogs { get; set; }

    public virtual DbSet<EmployeeAttendanceLog> EmployeeAttendanceLogs { get; set; }

    public virtual DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

    public virtual DbSet<EmployeeJobTitle> EmployeeJobTitles { get; set; }

    public virtual DbSet<EmployeeLeaveApplication> EmployeeLeaveApplications { get; set; }

    public virtual DbSet<EmployeeLeaveType> EmployeeLeaveTypes { get; set; }

    public virtual DbSet<EmployeeLoginLog> EmployeeLoginLogs { get; set; }

    public virtual DbSet<EmployeeMissingPunchApplication> EmployeeMissingPunchApplications { get; set; }

    public virtual DbSet<EmployeePasswordResetRequest> EmployeePasswordResetRequests { get; set; }

    public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

    public virtual DbSet<EmployeeScheduleAssignment> EmployeeScheduleAssignments { get; set; }

    public virtual DbSet<EmployeeUserAccount> EmployeeUserAccounts { get; set; }

    public virtual DbSet<EquipmentCategory> EquipmentCategories { get; set; }

    public virtual DbSet<EquipmentItem> EquipmentItems { get; set; }

    public virtual DbSet<EquipmentMaintenanceOrder> EquipmentMaintenanceOrders { get; set; }

    public virtual DbSet<EquipmentPurchasingOrder> EquipmentPurchasingOrders { get; set; }

    public virtual DbSet<EquipmentPurchasingOrderDetail> EquipmentPurchasingOrderDetails { get; set; }

    public virtual DbSet<EquipmentRentCustomerLog> EquipmentRentCustomerLogs { get; set; }

    public virtual DbSet<EquipmentRentList> EquipmentRentLists { get; set; }

    public virtual DbSet<EquipmentRentListDetail> EquipmentRentListDetails { get; set; }

    public virtual DbSet<EquipmentSupplier> EquipmentSuppliers { get; set; }

    public virtual DbSet<EventBatch> EventBatches { get; set; }

    public virtual DbSet<EventCategory> EventCategories { get; set; }

    public virtual DbSet<EventPaymentDetail> EventPaymentDetails { get; set; }

    public virtual DbSet<EventPhoto> EventPhotos { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<EventTemplate> EventTemplates { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberDailyHealthRecord> MemberDailyHealthRecords { get; set; }

    public virtual DbSet<MemberEmergencyContact> MemberEmergencyContacts { get; set; }

    public virtual DbSet<MemberMedicalHistory> MemberMedicalHistories { get; set; }

    public virtual DbSet<MemberSecurityLog> MemberSecurityLogs { get; set; }

    public virtual DbSet<RegistrationDetail> RegistrationDetails { get; set; }

    public virtual DbSet<RoomBed> RoomBeds { get; set; }

    public virtual DbSet<RoomImage> RoomImages { get; set; }

    public virtual DbSet<RoomOccupancy> RoomOccupancies { get; set; }

    public virtual DbSet<RoomTable> RoomTables { get; set; }

    public virtual DbSet<RoomVisitReservation> RoomVisitReservations { get; set; }

    public virtual DbSet<ShopCategory> ShopCategories { get; set; }

    public virtual DbSet<ShopOrder> ShopOrders { get; set; }

    public virtual DbSet<ShopOrderDetail> ShopOrderDetails { get; set; }

    public virtual DbSet<ShopProduct> ShopProducts { get; set; }

    public virtual DbSet<ShopProductPhoto> ShopProductPhotos { get; set; }

    public virtual DbSet<SuppliesCategory> SuppliesCategories { get; set; }

    public virtual DbSet<SuppliesProduct> SuppliesProducts { get; set; }

    public virtual DbSet<SuppliesProductsDate> SuppliesProductsDates { get; set; }

    public virtual DbSet<SuppliesPurchasingOrder> SuppliesPurchasingOrders { get; set; }

    public virtual DbSet<SuppliesPurchasingOrderDetail> SuppliesPurchasingOrderDetails { get; set; }

    public virtual DbSet<SuppliesSalesLog> SuppliesSalesLogs { get; set; }

    public virtual DbSet<SuppliesSalesOrder> SuppliesSalesOrders { get; set; }

    public virtual DbSet<SuppliesSalesOrderDetail> SuppliesSalesOrderDetails { get; set; }

    public virtual DbSet<SuppliesSupplier> SuppliesSuppliers { get; set; }

    public virtual DbSet<TransferOrder> TransferOrders { get; set; }

    public virtual DbSet<TransferOrderDetail> TransferOrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbNursingHome;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CareAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId);

            entity.Property(e => e.AssignedTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.Eta)
                .HasColumnType("datetime")
                .HasColumnName("ETA");
        });

        modelBuilder.Entity<CareRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.FMemberId).HasColumnName("fMemberId");
            entity.Property(e => e.RequestTime).HasColumnType("datetime");
            entity.Property(e => e.ServiceType).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Caregiver>(entity =>
        {
            entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<CommunityAttachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Communit__442C64DE51CCCFAF");

            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.AttachmentUrl).HasMaxLength(255);
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");
        });

        modelBuilder.Entity<CommunityAuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Communit__5E5499A8E334205B");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.ActionType).HasMaxLength(50);
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.ContentId).HasColumnName("ContentID");
            entity.Property(e => e.ContentType).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CommunityBoard>(entity =>
        {
            entity.HasKey(e => e.BoardId).HasName("PK__Communit__F9646BD2C625AAB3");

            entity.HasIndex(e => e.BoardName, "UQ__Communit__16ABEDBE5E59ED4F").IsUnique();

            entity.Property(e => e.BoardId).HasColumnName("BoardID");
            entity.Property(e => e.BoardDescription).HasMaxLength(255);
            entity.Property(e => e.BoardName).HasMaxLength(50);
            entity.Property(e => e.BoardStatus).HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ModeratorId).HasColumnName("ModeratorID");
        });

        modelBuilder.Entity<CommunityChatAttachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Communit__442C64DE0D5A7AFD");

            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.AttachmentType).HasMaxLength(20);
            entity.Property(e => e.FileName).HasMaxLength(100);
            entity.Property(e => e.FileUrl).HasMaxLength(255);
            entity.Property(e => e.MessageId).HasColumnName("MessageID");
        });

        modelBuilder.Entity<CommunityChatMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Communit__C87C037C2677AD25");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.SentAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CommunityChatRoom>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Communit__3286391984032B4A");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatorMemberId).HasColumnName("CreatorMemberID");
            entity.Property(e => e.RoomName).HasMaxLength(100);
            entity.Property(e => e.RoomStatus).HasMaxLength(20);
            entity.Property(e => e.RoomType).HasMaxLength(20);
        });

        modelBuilder.Entity<CommunityChatRoomMember>(entity =>
        {
            entity.HasKey(e => new { e.RoomId, e.MemberId }).HasName("PK__Communit__A2493DAA3D6679FF");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.JoinedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CommunityFavorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__Communit__CE74FAF514DF9EA6");

            entity.Property(e => e.FavoriteId).HasColumnName("FavoriteID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
        });

        modelBuilder.Entity<CommunityFollow>(entity =>
        {
            entity.HasKey(e => new { e.FollowerId, e.FollowingId }).HasName("PK__Communit__79CB03DBA04E9FA8");

            entity.Property(e => e.FollowerId).HasColumnName("FollowerID");
            entity.Property(e => e.FollowingId).HasColumnName("FollowingID");
            entity.Property(e => e.FollowedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CommunityInteraction>(entity =>
        {
            entity.HasKey(e => e.InteractionId).HasName("PK__Communit__922C0376F6D16EFB");

            entity.Property(e => e.InteractionId).HasColumnName("InteractionID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.InteractionsType).HasMaxLength(20);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.TargetId).HasColumnName("TargetID");
            entity.Property(e => e.TargetType).HasMaxLength(20);
        });

        modelBuilder.Entity<CommunityMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Communit__C87C037C11E43220");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.SenderType).HasMaxLength(20);
            entity.Property(e => e.SentAt).HasColumnType("datetime");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
        });

        modelBuilder.Entity<CommunityNotification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Communit__20CF2E32BCBFB4D1");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.NotificationsType).HasMaxLength(20);
            entity.Property(e => e.NotificationsUrl).HasMaxLength(255);
            entity.Property(e => e.ReceiverMemberId).HasColumnName("ReceiverMemberID");
            entity.Property(e => e.SenderMemberId).HasColumnName("SenderMemberID");
        });

        modelBuilder.Entity<CommunityPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Communit__AA126038D9C84513");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.BoardId).HasColumnName("BoardID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ParentPostId).HasColumnName("ParentPostID");
            entity.Property(e => e.PostStatus).HasMaxLength(20);
            entity.Property(e => e.QuotePostId).HasColumnName("QuotePostID");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CommunityPostTag>(entity =>
        {
            entity.HasKey(e => new { e.PostId, e.TagId }).HasName("PK__Communit__7C45AF9C4A4C687D");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.TagId).HasColumnName("TagID");
        });

        modelBuilder.Entity<CommunityReply>(entity =>
        {
            entity.HasKey(e => e.ReplyId).HasName("PK__Communit__C25E46291A675774");

            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ParentReplyId).HasColumnName("ParentReplyID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.ReplieStatus).HasMaxLength(10);
        });

        modelBuilder.Entity<CommunityReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Communit__D5BD48E51027AF26");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.HandledAt).HasColumnType("datetime");
            entity.Property(e => e.HandledEmployeeId).HasColumnName("HandledEmployeeID");
            entity.Property(e => e.ReasonType).HasMaxLength(50);
            entity.Property(e => e.ReportMemberId).HasColumnName("ReportMemberID");
            entity.Property(e => e.ReportStatus).HasMaxLength(10);
            entity.Property(e => e.ReportedAt).HasColumnType("datetime");
            entity.Property(e => e.ReportedContentId).HasColumnName("ReportedContentID");
            entity.Property(e => e.Result).HasMaxLength(255);
            entity.Property(e => e.TargetMemberId).HasColumnName("TargetMemberID");
            entity.Property(e => e.TargetType).HasMaxLength(20);
        });

        modelBuilder.Entity<CommunityReportedContent>(entity =>
        {
            entity.HasKey(e => e.ReportedContentId).HasName("PK__Communit__1DDC4E5BE6DA526D");

            entity.ToTable("CommunityReportedContent");

            entity.Property(e => e.ReportedContentId).HasColumnName("ReportedContentID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.OtherId).HasColumnName("OtherID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");
            entity.Property(e => e.ReportedContentType).HasMaxLength(10);
        });

        modelBuilder.Entity<CommunityTag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Communit__657CFA4C32A51C8D");

            entity.HasIndex(e => e.TagName, "UQ__Communit__BDE0FD1DF87EB882").IsUnique();

            entity.Property(e => e.TagId).HasColumnName("TagID");
            entity.Property(e => e.TagName).HasMaxLength(50);
        });

        modelBuilder.Entity<CommunityTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Communit__712CC6275D9E86D6");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.ClosedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.HandlerEmployeeId).HasColumnName("HandlerEmployeeID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ResolvedAt).HasColumnType("datetime");
            entity.Property(e => e.TicketsPriority).HasMaxLength(20);
            entity.Property(e => e.TicketsStatus).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CommunityUserProfile>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Communit__0CF04B38EE2399E8");

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("MemberID");
            entity.Property(e => e.DisplayName).HasMaxLength(100);
            entity.Property(e => e.LastUpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(255);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1F06B9A2D");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.CurrentAddress).HasMaxLength(100);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EducationLevel).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactPerson).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactPhone).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactRelationship).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.IdentityNumber).HasMaxLength(100);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.IsSupervisor).HasDefaultValue(false);
            entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PayrollBankAccount).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PoliceClearanceCertified).HasDefaultValue(false);
            entity.Property(e => e.RegisteredAddress).HasMaxLength(100);
        });

        modelBuilder.Entity<EmployeeAnnualLeaveBalance>(entity =>
        {
            entity.HasKey(e => e.BalanceId).HasName("PK__Employee__A760D5BEBBEA8C04");

            entity.ToTable("EmployeeAnnualLeaveBalance");

            entity.Property(e => e.BalanceId).HasColumnName("BalanceID");
            entity.Property(e => e.AutoGenerated).HasDefaultValue(true);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TotalDays)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(4, 1)");
            entity.Property(e => e.UsedDays)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(4, 1)");
        });

        modelBuilder.Entity<EmployeeApprovalFlowTemplate>(entity =>
        {
            entity.HasKey(e => e.FlowId).HasName("PK__Employee__1184B33CA3D7E06F");

            entity.ToTable("EmployeeApprovalFlowTemplate");

            entity.Property(e => e.FlowId).HasColumnName("FlowID");
            entity.Property(e => e.FormType).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.StepName).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeApprovalLog>(entity =>
        {
            entity.HasKey(e => e.ApprovalId).HasName("PK__Employee__328477F4488057EE");

            entity.ToTable("EmployeeApprovalLog");

            entity.Property(e => e.ApprovalId).HasColumnName("ApprovalID");
            entity.Property(e => e.ApproveComment).HasMaxLength(200);
            entity.Property(e => e.ApproveDate).HasColumnType("datetime");
            entity.Property(e => e.ApproveStatus).HasMaxLength(20);
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.FormId).HasColumnName("FormID");
            entity.Property(e => e.FormType).HasMaxLength(50);
            entity.Property(e => e.IsFinalStep).HasDefaultValue(false);
            entity.Property(e => e.StepName).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeAttendanceLog>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Employee__8B69261C6864AED4");

            entity.ToTable("EmployeeAttendanceLog");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.ClockInTime).HasColumnType("datetime");
            entity.Property(e => e.ClockOutTime).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Employee__B2079BEDC1EAF148");

            entity.ToTable("EmployeeDepartment");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<EmployeeJobTitle>(entity =>
        {
            entity.HasKey(e => e.JobTitleId).HasName("PK__Employee__35382FE922B78EF0");

            entity.ToTable("EmployeeJobTitle");

            entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.TitleName).HasMaxLength(100);
        });

        modelBuilder.Entity<EmployeeLeaveApplication>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__Employee__796DB95902255368");

            entity.ToTable("EmployeeLeaveApplication");

            entity.Property(e => e.LeaveId).HasColumnName("LeaveID");
            entity.Property(e => e.ApplyDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.LeaveHours).HasColumnType("decimal(4, 1)");
            entity.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");
            entity.Property(e => e.Reason).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("審核中");
        });

        modelBuilder.Entity<EmployeeLeaveType>(entity =>
        {
            entity.HasKey(e => e.LeaveTypeId).HasName("PK__Employee__43BE8F146A0B95F6");

            entity.ToTable("EmployeeLeaveType");

            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeLoginLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Employee__5E548648329A8334");

            entity.ToTable("EmployeeLoginLog");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.DeviceInfo).HasMaxLength(200);
            entity.Property(e => e.FailReason).HasMaxLength(100);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPAddress");
            entity.Property(e => e.LoginTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeMissingPunchApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Employee__C93A4C9902B4D7F7");

            entity.ToTable("EmployeeMissingPunchApplication");

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.ApplyDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ApplyReason).HasMaxLength(200);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.MissingType).HasMaxLength(10);
            entity.Property(e => e.RequestedTime).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("審核中");
        });

        modelBuilder.Entity<EmployeePasswordResetRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Employee__33A8517A37AD1B12");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ExpireTime).HasColumnType("datetime");
            entity.Property(e => e.IsUsed).HasDefaultValue(false);
            entity.Property(e => e.RequestedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Token).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Employee__9C8A5B4910D1479A");

            entity.ToTable("EmployeeSchedule");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.EndTime).HasPrecision(0);
            entity.Property(e => e.ScheduleName).HasMaxLength(50);
            entity.Property(e => e.StartTime).HasPrecision(0);
            entity.Property(e => e.WorkDays).HasMaxLength(20);
        });

        modelBuilder.Entity<EmployeeScheduleAssignment>(entity =>
        {
            entity.HasKey(e => e.EmployeeScheduleId).HasName("PK__Employee__0310D9A60B45076F");

            entity.ToTable("EmployeeScheduleAssignment");

            entity.Property(e => e.EmployeeScheduleId).HasColumnName("EmployeeScheduleID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
        });

        modelBuilder.Entity<EmployeeUserAccount>(entity =>
        {
            entity.HasKey(e => e.UserAccountId).HasName("PK__Employee__DA6C709AF83A21BA");

            entity.ToTable("EmployeeUserAccount");

            entity.HasIndex(e => e.Username, "UQ__Employee__536C85E4C8EBD0F6").IsUnique();

            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLoginTime).HasColumnType("datetime");
            entity.Property(e => e.LockedUntil).HasColumnType("datetime");
            entity.Property(e => e.LoginFailCount).HasDefaultValue(0);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PasswordSalt).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<EquipmentCategory>(entity =>
        {
            entity.ToTable("EquipmentCategory");

            entity.Property(e => e.EquipmentCategoryId).HasColumnName("EquipmentCategoryID");
            entity.Property(e => e.EquipmentCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<EquipmentItem>(entity =>
        {
            entity.Property(e => e.EquipmentItemId).HasColumnName("EquipmentItemID");
            entity.Property(e => e.EquipmentCategoryId).HasColumnName("EquipmentCategoryID");
            entity.Property(e => e.EquipmentItemName).HasMaxLength(50);
            entity.Property(e => e.EquipmentStatus).HasMaxLength(10);
            entity.Property(e => e.EquipmentSupplierId).HasColumnName("EquipmentSupplierID");
        });

        modelBuilder.Entity<EquipmentMaintenanceOrder>(entity =>
        {
            entity.Property(e => e.EquipmentMaintenanceOrderId).HasColumnName("EquipmentMaintenanceOrderID");
            entity.Property(e => e.EquipmentItemId).HasColumnName("EquipmentItemID");
        });

        modelBuilder.Entity<EquipmentPurchasingOrder>(entity =>
        {
            entity.Property(e => e.EquipmentPurchasingOrderId).HasColumnName("EquipmentPurchasingOrderID");
            entity.Property(e => e.EquipmentSupplierId).HasColumnName("EquipmentSupplierID");
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<EquipmentPurchasingOrderDetail>(entity =>
        {
            entity.Property(e => e.EquipmentPurchasingOrderDetailId).HasColumnName("EquipmentPurchasingOrderDetailID");
            entity.Property(e => e.EquipmentCategoryId).HasColumnName("EquipmentCategoryID");
            entity.Property(e => e.EquipmentItemIds).HasColumnName("EquipmentItemIDs");
            entity.Property(e => e.EquipmentPurchasingOrderId).HasColumnName("EquipmentPurchasingOrderID");
        });

        modelBuilder.Entity<EquipmentRentCustomerLog>(entity =>
        {
            entity.ToTable("EquipmentRentCustomerLog");

            entity.Property(e => e.EquipmentRentCustomerLogId).HasColumnName("EquipmentRentCustomerLogID");
            entity.Property(e => e.CustomerGui)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerGUI");
            entity.Property(e => e.CustomerName).HasMaxLength(50);
        });

        modelBuilder.Entity<EquipmentRentList>(entity =>
        {
            entity.ToTable("EquipmentRentList");

            entity.Property(e => e.EquipmentRentListId).HasColumnName("EquipmentRentListID");
            entity.Property(e => e.CustomerGui)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerGUI");
            entity.Property(e => e.CustomerName).HasMaxLength(50);
        });

        modelBuilder.Entity<EquipmentRentListDetail>(entity =>
        {
            entity.Property(e => e.EquipmentRentListDetailId).HasColumnName("EquipmentRentListDetailID");
            entity.Property(e => e.EquipmentItemId).HasColumnName("EquipmentItemID");
            entity.Property(e => e.EquipmentRentListId).HasColumnName("EquipmentRentListID");
        });

        modelBuilder.Entity<EquipmentSupplier>(entity =>
        {
            entity.Property(e => e.EquipmentSupplierId).HasColumnName("EquipmentSupplierID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.ContactPerson).HasMaxLength(20);
            entity.Property(e => e.EquipmentSupplierGui)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EquipmentSupplierGUI");
            entity.Property(e => e.EquipmentSupplierName).HasMaxLength(50);
            entity.Property(e => e.SupplierKeyword).HasMaxLength(50);
        });

        modelBuilder.Entity<EventBatch>(entity =>
        {
            entity.HasKey(e => e.BatchId).HasName("PK__EventBat__5D55CE3863545EEA");

            entity.ToTable("EventBatch");

            entity.Property(e => e.BatchId).HasColumnName("BatchID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.EventDateTimeEnd).HasColumnType("datetime");
            entity.Property(e => e.EventDateTimeStart).HasColumnType("datetime");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventLocation).HasMaxLength(200);
            entity.Property(e => e.LastModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.MedicalAid).HasMaxLength(1000);
            entity.Property(e => e.Organizer).HasMaxLength(100);
            entity.Property(e => e.RegistrationDateEnd).HasColumnType("datetime");
            entity.Property(e => e.RegistrationDateStart).HasColumnType("datetime");
            entity.Property(e => e.TargetAudience).HasMaxLength(100);
        });

        modelBuilder.Entity<EventCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__EventCat__19093A2B27357819");

            entity.ToTable("EventCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(20);
        });

        modelBuilder.Entity<EventPaymentDetail>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__EventPay__6EF588302A4377E8");

            entity.Property(e => e.RegistrationId)
                .ValueGeneratedNever()
                .HasColumnName("RegistrationID");
            entity.Property(e => e.EinvoiceCarrier)
                .HasMaxLength(50)
                .HasColumnName("EInvoiceCarrier");
            entity.Property(e => e.InvoiceTitle).HasMaxLength(100);
            entity.Property(e => e.InvoiceType).HasMaxLength(100);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentItem).HasMaxLength(100);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.TaxId)
                .HasMaxLength(10)
                .HasColumnName("TaxID");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("TransactionID");
        });

        modelBuilder.Entity<EventPhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__EventPho__21B7B582CB6179AF");

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EventId).HasColumnName("EventID");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__EventSta__C8EE20431BD7A543");

            entity.ToTable("EventStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.EventCategory).HasMaxLength(20);
            entity.Property(e => e.StatusName).HasMaxLength(20);
        });

        modelBuilder.Entity<EventTemplate>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__EventTem__7944C870D5CEAD92");

            entity.ToTable("EventTemplate");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EventLocation).HasMaxLength(200);
            entity.Property(e => e.EventName).HasMaxLength(100);
            entity.Property(e => e.LastModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Organizer).HasMaxLength(100);
            entity.Property(e => e.Subtitle).HasMaxLength(200);
            entity.Property(e => e.TargetAudience).HasMaxLength(100);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.FMemberId);

            entity.ToTable("Member");

            entity.Property(e => e.FMemberId).HasColumnName("fMemberId");
            entity.Property(e => e.FAccount)
                .HasMaxLength(50)
                .HasColumnName("fAccount");
            entity.Property(e => e.FAccountStatus).HasColumnName("fAccountStatus");
            entity.Property(e => e.FBirthDate).HasColumnName("fBirthDate");
            entity.Property(e => e.FCity)
                .HasMaxLength(50)
                .HasColumnName("fCity");
            entity.Property(e => e.FCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FDistrict)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("fDistrict");
            entity.Property(e => e.FEmail)
                .HasMaxLength(200)
                .HasColumnName("fEmail");
            entity.Property(e => e.FExternalId)
                .HasMaxLength(200)
                .HasColumnName("fExternalId");
            entity.Property(e => e.FGender)
                .HasMaxLength(50)
                .HasColumnName("fGender");
            entity.Property(e => e.FHeight)
                .HasColumnType("decimal(4, 1)")
                .HasColumnName("fHeight");
            entity.Property(e => e.FIdNumber)
                .HasMaxLength(50)
                .HasColumnName("fIdNumber");
            entity.Property(e => e.FLoginProvider)
                .HasMaxLength(20)
                .HasColumnName("fLoginProvider");
            entity.Property(e => e.FName)
                .HasMaxLength(50)
                .HasColumnName("fName");
            entity.Property(e => e.FPasswordHash).HasColumnName("fPasswordHash");
            entity.Property(e => e.FPasswordSalt).HasColumnName("fPasswordSalt");
            entity.Property(e => e.FPhone)
                .HasMaxLength(100)
                .HasColumnName("fPhone");
            entity.Property(e => e.FProfilePictureUrl)
                .HasMaxLength(200)
                .HasColumnName("fProfilePictureUrl");
            entity.Property(e => e.FResidesInCareHomeStatus).HasColumnName("fResidesInCareHomeStatus");
            entity.Property(e => e.FRoadAddress)
                .HasMaxLength(100)
                .HasColumnName("fRoadAddress");
            entity.Property(e => e.FWeight)
                .HasColumnType("decimal(4, 1)")
                .HasColumnName("fWeight");
            entity.Property(e => e.FZip).HasColumnName("fZip");
        });

        modelBuilder.Entity<MemberDailyHealthRecord>(entity =>
        {
            entity.HasKey(e => e.FId);

            entity.ToTable("MemberDailyHealthRecord");

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FCheckPeriod)
                .HasMaxLength(50)
                .HasColumnName("fCheckPeriod");
            entity.Property(e => e.FCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FDiastolic).HasColumnName("fDiastolic");
            entity.Property(e => e.FIorecord)
                .HasMaxLength(50)
                .HasColumnName("fIORecord");
            entity.Property(e => e.FMemberId).HasColumnName("fMemberId");
            entity.Property(e => e.FNotes)
                .HasMaxLength(200)
                .HasColumnName("fNotes");
            entity.Property(e => e.FPulse).HasColumnName("fPulse");
            entity.Property(e => e.FRecordDate).HasColumnName("fRecordDate");
            entity.Property(e => e.FSystolic).HasColumnName("fSystolic");
        });

        modelBuilder.Entity<MemberEmergencyContact>(entity =>
        {
            entity.HasKey(e => e.FId);

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FAddress)
                .HasMaxLength(50)
                .HasColumnName("fAddress");
            entity.Property(e => e.FCity)
                .HasMaxLength(50)
                .HasColumnName("fCity");
            entity.Property(e => e.FContactName)
                .HasMaxLength(50)
                .HasColumnName("fContactName");
            entity.Property(e => e.FCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FDistrict)
                .HasMaxLength(50)
                .HasColumnName("fDistrict");
            entity.Property(e => e.FEmail)
                .HasMaxLength(200)
                .HasColumnName("fEmail");
            entity.Property(e => e.FIsActive).HasColumnName("fIsActive");
            entity.Property(e => e.FIsPrimary).HasColumnName("fIsPrimary");
            entity.Property(e => e.FMemberId).HasColumnName("fMemberId");
            entity.Property(e => e.FNotes)
                .HasMaxLength(200)
                .HasColumnName("fNotes");
            entity.Property(e => e.FPhone)
                .HasMaxLength(50)
                .HasColumnName("fPhone");
            entity.Property(e => e.FRelationship)
                .HasMaxLength(10)
                .HasColumnName("fRelationship");
            entity.Property(e => e.FUpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("fUpdatedAt");
        });

        modelBuilder.Entity<MemberMedicalHistory>(entity =>
        {
            entity.HasKey(e => e.FId);

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FDiagnosedDate).HasColumnName("fDiagnosedDate");
            entity.Property(e => e.FDiseaseName)
                .HasMaxLength(100)
                .HasColumnName("fDiseaseName");
            entity.Property(e => e.FMemberId).HasColumnName("fMemberId");
            entity.Property(e => e.FNotes)
                .HasMaxLength(200)
                .HasColumnName("fNotes");
        });

        modelBuilder.Entity<MemberSecurityLog>(entity =>
        {
            entity.HasKey(e => e.FId);

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FEventType)
                .HasMaxLength(50)
                .HasColumnName("fEventType");
            entity.Property(e => e.FIpAddress)
                .HasMaxLength(200)
                .HasColumnName("fIpAddress");
            entity.Property(e => e.FMemberId).HasColumnName("fMemberId");
            entity.Property(e => e.FNotes)
                .HasMaxLength(200)
                .HasColumnName("fNotes");
        });

        modelBuilder.Entity<RegistrationDetail>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__Registra__6EF58830B989AED0");

            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.AmountDue).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.EventBatchId).HasColumnName("EventBatchID");
            entity.Property(e => e.InternalRemarks).HasMaxLength(500);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.RegistrationDateTime).HasColumnType("datetime");
            entity.Property(e => e.RegistrationNum).HasMaxLength(20);
        });

        modelBuilder.Entity<RoomBed>(entity =>
        {
            entity.HasKey(e => e.FBedId).HasName("PK__RoomBed__09ECDAA165005AC7");

            entity.ToTable("RoomBed");

            entity.Property(e => e.FBedId).HasColumnName("fBedId");
            entity.Property(e => e.FBedCode)
                .HasMaxLength(50)
                .HasColumnName("fBedCode");
            entity.Property(e => e.FBedStatus).HasColumnName("fBedStatus");
            entity.Property(e => e.FRoomId).HasColumnName("fRoomId");

            entity.HasOne(d => d.FRoom).WithMany(p => p.RoomBeds)
                .HasForeignKey(d => d.FRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoomBed__fRoomId__39237A9A");
        });

        modelBuilder.Entity<RoomImage>(entity =>
        {
            entity.HasKey(e => e.FRoomImageId).HasName("PK__RoomImag__2C910A0A0AE42266");

            entity.ToTable("RoomImage");

            entity.Property(e => e.FRoomImageId).HasColumnName("fRoomImageId");
            entity.Property(e => e.FRoomId).HasColumnName("fRoomId");

            entity.HasOne(d => d.FRoom).WithMany(p => p.RoomImages)
                .HasForeignKey(d => d.FRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoomImage__fRoom__3BFFE745");
        });

        modelBuilder.Entity<RoomOccupancy>(entity =>
        {
            entity.HasKey(e => e.FOccupancyId).HasName("PK__RoomOccu__BAFC68F02950123F");

            entity.ToTable("RoomOccupancy");

            entity.Property(e => e.FOccupancyId).HasColumnName("fOccupancyId");
            entity.Property(e => e.FBedId).HasColumnName("fBedId");
            entity.Property(e => e.FBillingAmount).HasColumnName("fBillingAmount");
            entity.Property(e => e.FBillingDate)
                .HasColumnType("datetime")
                .HasColumnName("fBillingDate");
            entity.Property(e => e.FBillingStatus).HasColumnName("fBillingStatus");
            entity.Property(e => e.FCheckInDate)
                .HasColumnType("datetime")
                .HasColumnName("fCheckInDate");
            entity.Property(e => e.FCheckOutDate)
                .HasColumnType("datetime")
                .HasColumnName("fCheckOutDate");
            entity.Property(e => e.FMemberId).HasColumnName("fMemberId");
            entity.Property(e => e.FPaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("fPaymentMethod");

            entity.HasOne(d => d.FBed).WithMany(p => p.RoomOccupancies)
                .HasForeignKey(d => d.FBedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoomOccup__fBedI__3EDC53F0");
        });

        modelBuilder.Entity<RoomTable>(entity =>
        {
            entity.HasKey(e => e.FRoomId).HasName("PK__RoomTabl__FD3AACD9B2183494");

            entity.ToTable("RoomTable");

            entity.Property(e => e.FRoomId).HasColumnName("fRoomId");
            entity.Property(e => e.FBedCount).HasColumnName("fBedCount");
            entity.Property(e => e.FRoomAlias)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fRoomAlias");
            entity.Property(e => e.FRoomDescription).HasColumnName("fRoomDescription");
            entity.Property(e => e.FRoomName)
                .HasMaxLength(100)
                .HasColumnName("fRoomName");
            entity.Property(e => e.FRoomPrice).HasColumnName("fRoomPrice");
            entity.Property(e => e.FRoomType).HasColumnName("fRoomType");
        });

        modelBuilder.Entity<RoomVisitReservation>(entity =>
        {
            entity.HasKey(e => e.FReservationId).HasName("PK__RoomVisi__BD75641D53FE9AE2");

            entity.ToTable("RoomVisitReservation");

            entity.Property(e => e.FReservationId).HasColumnName("fReservationId");
            entity.Property(e => e.FCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FEmail)
                .HasMaxLength(255)
                .HasColumnName("fEmail");
            entity.Property(e => e.FName)
                .HasMaxLength(100)
                .HasColumnName("fName");
            entity.Property(e => e.FPhoneOrLineId)
                .HasMaxLength(100)
                .HasColumnName("fPhoneOrLineId");
            entity.Property(e => e.FReservationDate)
                .HasColumnType("datetime")
                .HasColumnName("fReservationDate");
        });

        modelBuilder.Entity<ShopCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BF25D0914");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Picture).HasColumnType("image");
        });

        modelBuilder.Entity<ShopOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF280F8ADA");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.BuyerName).HasMaxLength(40);
            entity.Property(e => e.CarrierNumber).HasMaxLength(50);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryAddress).HasMaxLength(200);
            entity.Property(e => e.DeliveryMethod).HasMaxLength(100);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.FMemberId).HasColumnName("fMemberId");
            entity.Property(e => e.InvoiceInMethod).HasMaxLength(100);
            entity.Property(e => e.InvoiceTax).HasMaxLength(100);
            entity.Property(e => e.InvoiceTitle).HasMaxLength(100);
            entity.Property(e => e.Note).HasMaxLength(300);
            entity.Property(e => e.OrderNo).HasMaxLength(50);
            entity.Property(e => e.OrderTime).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(100);
            entity.Property(e => e.ReceiverName).HasMaxLength(100);
            entity.Property(e => e.ReceiverPhone).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<ShopOrderDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__ShopOrde__135C314D87AC1AEB");

            entity.Property(e => e.DetailId).HasColumnName("DetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
        });

        modelBuilder.Entity<ShopProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__ShopProd__B40CC6ED1550AA6D");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LargePhotoPath).HasMaxLength(200);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            //entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Summary).HasMaxLength(200);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.ThumbnailPhotoPath).HasMaxLength(200);
        });

        modelBuilder.Entity<ShopProductPhoto>(entity =>
        {
            entity.HasKey(e => e.ProductPhotoId).HasName("PK__ShopProd__82A8EF93197BBDAC");

            entity.ToTable("ShopProductPhoto");

            entity.Property(e => e.ProductPhotoId).HasColumnName("ProductPhotoID");
            entity.Property(e => e.LargePhotoFileName).HasMaxLength(50);
            entity.Property(e => e.LargePhotoPath).HasMaxLength(200);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);
            entity.Property(e => e.ThumbnailPhotoPath).HasMaxLength(200);
        });

        modelBuilder.Entity<SuppliesCategory>(entity =>
        {
            entity.ToTable("SuppliesCategory");

            entity.Property(e => e.SuppliesCategoryId).HasColumnName("SuppliesCategoryID");
            entity.Property(e => e.SuppliesCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<SuppliesProduct>(entity =>
        {
            entity.Property(e => e.SuppliesProductId).HasColumnName("SuppliesProductID");
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(50);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.SuppliesCategoryId).HasColumnName("SuppliesCategoryID");
            entity.Property(e => e.SuppliesProductName).HasMaxLength(50);
        });

        modelBuilder.Entity<SuppliesProductsDate>(entity =>
        {
            entity.ToTable("SuppliesProductsDate");

            entity.Property(e => e.SuppliesProductsDateId).HasColumnName("SuppliesProductsDateID");
            entity.Property(e => e.SuppliesProductId).HasColumnName("SuppliesProductID");
        });

        modelBuilder.Entity<SuppliesPurchasingOrder>(entity =>
        {
            entity.Property(e => e.SuppliesPurchasingOrderId).HasColumnName("SuppliesPurchasingOrderID");
            entity.Property(e => e.SuppliesSupplierId).HasColumnName("SuppliesSupplierID");
        });

        modelBuilder.Entity<SuppliesPurchasingOrderDetail>(entity =>
        {
            entity.Property(e => e.SuppliesPurchasingOrderDetailId).HasColumnName("SuppliesPurchasingOrderDetailID");
            entity.Property(e => e.SuppliesPurchasingOrderId).HasColumnName("SuppliesPurchasingOrderID");
        });

        modelBuilder.Entity<SuppliesSalesLog>(entity =>
        {
            entity.ToTable("SuppliesSalesLog");

            entity.Property(e => e.SuppliesSalesLogId).HasColumnName("SuppliesSalesLogID");
            entity.Property(e => e.CustomerGui)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CustomerGUI");
            entity.Property(e => e.CustomerName).HasMaxLength(50);
        });

        modelBuilder.Entity<SuppliesSalesOrder>(entity =>
        {
            entity.Property(e => e.SuppliesSalesOrderId).HasColumnName("SuppliesSalesOrderID");
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.OrderStatus).HasMaxLength(10);
        });

        modelBuilder.Entity<SuppliesSalesOrderDetail>(entity =>
        {
            entity.Property(e => e.SuppliesSalesOrderDetailId).HasColumnName("SuppliesSalesOrderDetailID");
            entity.Property(e => e.SuppliesProductId).HasColumnName("SuppliesProductID");
            entity.Property(e => e.SuppliesSalesOrderId).HasColumnName("SuppliesSalesOrderID");
        });

        modelBuilder.Entity<SuppliesSupplier>(entity =>
        {
            entity.Property(e => e.SuppliesSupplierId).HasColumnName("SuppliesSupplierID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.ContactPerson).HasMaxLength(20);
            entity.Property(e => e.SupplierKeyword).HasMaxLength(50);
            entity.Property(e => e.SuppliesSupplierGui)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SuppliesSupplierGUI");
            entity.Property(e => e.SuppliesSupplierName).HasMaxLength(50);
        });

        modelBuilder.Entity<TransferOrder>(entity =>
        {
            entity.Property(e => e.TransferOrderId).HasColumnName("TransferOrderID");
            entity.Property(e => e.OrderStatus).HasMaxLength(10);
        });

        modelBuilder.Entity<TransferOrderDetail>(entity =>
        {
            entity.Property(e => e.TransferOrderDetailId).HasColumnName("TransferOrderDetailID");
            entity.Property(e => e.SuppliesProductId).HasColumnName("SuppliesProductID");
            entity.Property(e => e.TransferOrderId).HasColumnName("TransferOrderID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
