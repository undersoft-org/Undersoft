using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK.Logging;

namespace Undersoft.SDK.Benchmarks.Updating.Models
{
    public class User : Origin
    {
        [Description("Imię")]
        [StringLength(100)]
        public string Name { get; set; } = "Michael Brown";

        [Description("Imię")]
        [StringLength(100)]
        public string FirstName { get; set; } = "Micheal";

        [Description("Nazwisko")]
        [StringLength(100)]
        public string LastName { get; set; } = "Brown";

        [Description("Email")]
        [StringLength(255)]
        public string Email { get; set; } = "gg@ggg.gg";

        [Description("Numer telefonu")]
        [StringLength(100)]
        public string PayrollNumber { get; set; } = "3543AAA2532";

        [Description("Nazwa formularza z którego pochodzi metryczka")]
        [StringLength(200)]
        public string SourceLabel { get; set; } = "Source";

        [Description(
            "Identyfikator encji w systemie zewnętrznym (dotyczy użytkowników operacyjnych)"
        )]
        public int? ExternalId { get; set; }

        [Description("Object ostatniej operacji")]
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OperationDate { get; set; } = Log.Clock;

        public virtual UserProfiles Profiles { get; set; } = new UserProfiles();

        public virtual UserAssignments Assignments { get; set; } = new UserAssignments();

        public Guid? MigratedToUserId { get; set; }

        [ForeignKey(nameof(MigratedToUserId))]
        public virtual User MigratedToUser { get; set; }

        [NotMapped]
        public bool IsArchived
        {
            get { return MigratedToUserId.HasValue; }
        }

        public Guid? PrimaryUserId { get; set; }

        [ForeignKey(nameof(PrimaryUserId))]
        public virtual User PrimaryUser { get; set; }

        public virtual ICollection<User> DependentUsers { get; set; }

        public void SetOperationDate(DateTime operationDate)
        {
            OperationDate = operationDate;
        }
    }
}
