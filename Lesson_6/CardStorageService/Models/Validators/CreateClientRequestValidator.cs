using CardStorageService.Data;
using CardStorageService.Models.Requests;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardStorageService.Models.Validators
{
    public class CreateClientRequestValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
            RuleFor(x => x.Surname)
                .NotNull()
                .Length(1, 255);
            RuleFor(x => x.FirstName)
                .NotNull()
                .Length(1, 255);
            RuleFor(x => x.Patronymic)
                .NotNull()
                .Length(1, 255);
        }

    }
}


//public string? Surname { get; set; }

//public string? FirstName { get; set; }

//public string? Patronymic { get; set; }

//[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//public int ClientId { get; set; }

//[Column]
//[StringLength(255)]
//public string? Surname { get; set; }

//[Column]
//[StringLength(255)]
//public string? FirstName { get; set; }

//[Column]
//[StringLength(255)]
//public string? Patronymic { get; set; }

//[InverseProperty(nameof(Card.Client))]
//public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();