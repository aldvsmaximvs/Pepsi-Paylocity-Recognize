namespace PaylocityToRecognize.Model
{
    public class PaylocityEmployeeDetail
    {
        public DateTime BirthDate { get; set; }
        public IEnumerable<CustomBooleanField> CustomBooleanFields { get; set; }
        public string EmployeeId { get; set; }
        public string CoEmpCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Currency { get; set; }
        public TaxSetup TaxSetup { get; set; }
        public DepartmentPosition DepartmentPosition { get; set; }
        public FederalTax FederalTax { get; set; }
        public PrimaryStateTax PrimaryStateTax { get; set; }
        public Status Status { get; set; }
        public WorkEligibility WorkEligibility { get; set; }
        public WorkAddress WorkAddress { get; set; }
        public HomeAddress HomeAddress { get; set; }
        public WebTime WebTime { get; set; }
        public string CompanyName { get; set; }
        public string CompanyFEIN { get; set; }
        public IEnumerable<EmergencyContact> EmergencyContacts { get; set; }
    }

    public class EmergencyContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public string PrimaryPhone { get; set; }
        public string Country { get; set; }
        public string Priority { get; set; }
    }

    public class WebTime
    {
        public bool IsTimeLaborEnabled { get; set; }
    }

    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    public class WorkAddress : Address
    {
        public string Location { get; set; }
    }

    public class HomeAddress : Address
    {
    }

    public class WorkEligibility
    {
        public bool IsI9Verified { get; set; }
        public bool IsSSNVerified { get; set; }
        public string WorkAuthorization { get; set; }
    }

    public class Status
    {
        public string ChangeReason { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string EmployeeStatus { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsEligibleForRehire { get; set; }
        public string StatusType { get; set; }
    }

    public class PrimaryStateTax
    {
        public decimal Amount { get; set; }
        public decimal Exceptions { get; set; }
        public decimal Exceptions2 { get; set; }
        public string FillingStatus { get; set; }
        public decimal Percentage { get; set; }
        public string TaxCalculationCode { get; set; }
        public string TaxCode { get; set; }
        public int W4FormYear { get; set; }
    }

    public class FederalTax
    {
        public decimal Amount { get; set; }
        public string FillingStatus { get; set; }
        public decimal Percentage { get; set; }
        public string TaxCalculationCode { get; set; }
        public int W4FormYear { get; set; }
    }

    public class DepartmentPosition
    {
        public string ChangeReason { get; set; }
        public string CostCenter1 { get; set; }
        public string CostCenter2 { get; set; }
        public string CostCenter3 { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string EmployeeType { get; set; }
        public string EqualEmploymentOpportunityClass { get; set; }
        public bool IsMinimumWageExempt { get; set; }
        public bool IsOvertimeExcept { get; set; }
        public bool IsSupervisorReviewer { get; set; }
        public bool IsUnionDuesCollected { get; set; }
        public bool IsUnionInitiationCollected { get; set; }
        public string JobTitle { get; set; }
        public string PositionCode { get; set; }
        public string ReviewerCompanyNumber { get; set; }
        public string ReviewerEmployeeId { get; set; }
        public string SupervisorCompanyNumber { get; set; }
        public string SupervisorEmployeeId { get; set; }
        public string WorkersCompensation { get; set; }
    }

    public class TaxSetup
    {
        public string SUIState { get; set; }
        public string TaxForm { get; set; }
    }

    public class CustomBooleanField
    {
        public string Category { get; set; }
        public string Label { get; set; }
        public bool Value { get; set; }
    }
}
