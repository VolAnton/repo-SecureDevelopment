using CardStorageService.Data;
using CardStorageService.Models.Requests;
using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardStorageService.Models.Validators
{
    public class CreateCardRequestValidator : AbstractValidator<CreateCardRequest>
    {
        public CreateCardRequestValidator()
        {
            RuleFor(x => x.ClientId)
                .NotNull();
            RuleFor(x => x.CardNo)
                .NotNull()
                .Length(20);
            RuleFor(x => x.Name)
                .NotNull()
                .Length(1, 50);
            RuleFor(x => x.CVV2)
                .NotNull()
                .Length(3, 50);
            RuleFor(x => x.ExpDate)
                .NotNull();                
        }

    }
}
//public int ClientId { get; set; }

//public string CardNo { get; set; }

//public string? Name { get; set; }

//public string? CVV2 { get; set; }

//public DateTime ExpDate { get; set; }

//[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//public Guid CardId { get; set; }

//[ForeignKey(nameof(Client))]
//public int ClientId { get; set; }

//[Column]
//[StringLength(20)]
//public string CardNo { get; set; }

//[Column]
//[StringLength(50)]
//public string? Name { get; set; }

//[Column]
//[StringLength(50)]
//public string? CVV2 { get; set; }

//[Column]
//public DateTime ExpDate { get; set; }

//public virtual Client Client { get; set; }