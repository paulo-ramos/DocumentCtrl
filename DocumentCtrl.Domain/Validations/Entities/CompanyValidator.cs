using DocumentCtrl.Domain.Entities;
using DocumentCtrl.Domain.Validations.ValueObjects;
using FluentValidation;

namespace DocumentCtrl.Domain.Validations.Entities;

public class CompanyValidator : AbstractValidator<Company>
{
    public CompanyValidator()
    {
        RuleFor(x => x.Corporate).SetValidator(new DocumentValidator());
        
        RuleFor(x => x.Document).SetValidator(new DocumentValidator());
        
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Nome da Companhia não pode ser nulo!");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nome da Companhia não pode ser vazio!");
        
      
    }
}