using DocumentCtrl.Domain.Entities;
using DocumentCtrl.Domain.Validations.ValueObjects;
using FluentValidation;

namespace DocumentCtrl.Domain.Validations.Entities;

public class CorporateValidator : AbstractValidator<Corporate>
{
    public CorporateValidator()
    {
        RuleFor(x => x.Document)
            .SetValidator(new DocumentValidator());
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nome da Corporação não pode ser vazio!");
        
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Nome da Corporação não pode ser nulo!");
    }
    
}