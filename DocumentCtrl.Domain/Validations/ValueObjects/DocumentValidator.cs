using DocumentCtrl.Domain.Enums;
using DocumentCtrl.Domain.ValueObjects;
using FluentValidation;

namespace DocumentCtrl.Domain.Validations.ValueObjects;

public class DocumentValidator : AbstractValidator<Document>
{
    public DocumentValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("Número do Documento não pode ser vazio!");
        
        RuleFor(x => x.Number)
            .NotNull()
            .WithMessage("Número do Documento não pode ser nulo!");
        
        RuleFor(x => x.Type)
            .NotEqual(EDocumentType.ERRO)
            .WithMessage(d => $"Documento [{d.Number}] inválido!");
        
        
    }
}