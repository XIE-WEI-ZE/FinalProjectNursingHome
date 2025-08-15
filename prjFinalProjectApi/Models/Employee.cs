using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public bool? EmploymentStatus { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsSupervisor { get; set; }

    public int? DepartmentId { get; set; }

    public int? JobTitleId { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? IdentityNumber { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? EducationLevel { get; set; }

    public string? CurrentAddress { get; set; }

    public string? RegisteredAddress { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public string? EmergencyContactPerson { get; set; }

    public string? EmergencyContactRelationship { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public DateOnly? HireDate { get; set; }

    public bool? PoliceClearanceCertified { get; set; }

    public string? PayrollBankAccount { get; set; }

    public string? PhotoPath { get; set; }
}
