using DocumentCtrl.Domain.Entities;
using DocumentCtrl.Domain.Validations.ValueObjects;
using FluentValidation;

namespace DocumentCtrl.Domain.Validations.Entities;

public class CorporateValidator : AbstractValidator<Corporate>
{
    public CorporateValidator()
    {
        RuleFor(c => c.Document).SetValidator(new DocumentValidator());
    }
    
}