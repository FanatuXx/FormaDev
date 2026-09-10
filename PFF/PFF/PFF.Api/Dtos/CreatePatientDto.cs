using PFF.Domain.Model.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PFF.Api.Dtos
{
    public class CreatePatientDto
    {
        public string? SSIN { get; set; }
        public string? IdNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Alias { get; set; }
        public string? Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Allergies { get; set; }
        public bool? IsInsured { get; set; } = false;
        public string? Insurance { get; set; } 
        public DateTime? InsuranceEndDate { get; set; }
        public bool? HasInsuranceCard { get; set; } = false;
        public DateTime? InsuranceCardEndDate { get; set; }
        public bool? IsAtFedasil { get; set; } = false;
        public int? Income { get; set; }
        public string? Status { get; set; }
        public bool? IsWorking { get; set; } = false;
        public DrugTypeEnum? DrugType { get; set; }
        public ConsumptionFrequencyEnum? ConsumptionFrequency { get; set; }
    }
}
