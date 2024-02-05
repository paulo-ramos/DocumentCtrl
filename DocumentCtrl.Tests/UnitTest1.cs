using DocumentCtrl.Domain.Entities;
using DocumentCtrl.Domain.Enums;
using DocumentCtrl.Domain.Validations.Entities;
using DocumentCtrl.Domain.Validations.ValueObjects;
using DocumentCtrl.Domain.ValueObjects;
using FluentValidation;

namespace DocumentCtrl.Tests;

public class UnitTest1
{
    
    [Theory]
    [InlineData("13711827871")]
    [InlineData("13711827872")]
    [InlineData("13711827873")]
    [InlineData("13711827874")]
    [InlineData("13711827875")]
    [InlineData("13711827876")]
    [InlineData("13711827877")]
    [InlineData("13711827878")]
    [InlineData("13711827879")]
    public void DeveRetornarErroAoCriarUmDocumentoCPFInvalido(string document)
    {
        // arrange
        var doc = new Document(document);
        var validator = new DocumentValidator();
        
        
        //act
        var exception = Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(doc));
        
        //assert
        Assert.Contains($"Documento [{document}] inválido!", exception.Message);
        Assert.Equal(EDocumentType.ERRO, doc.Type);
    }
    
    [Theory]
    [InlineData("13711827870")]
    public void DeveRetornarSucessooAoCriarUmDocumentoCPFValido(string document)
    {
        // arrange
        var doc = new Document(document);
        var validator = new DocumentValidator();
        
        
        //act
        var result = validator.Validate(doc);
        
        //assert
        Assert.True(result.IsValid);
        Assert.Equal(EDocumentType.CPF, doc.Type);
    }
    
    
    [Theory]
    [InlineData("0123456789123")]
    public void DeveRetornarErroAoCriarUmDocumentoCNPJInvalido(string document)
    {
        // arrange
        var doc = new Document(document);
        var validator = new DocumentValidator();
        
        
        //act
        var exception = Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(doc));
        
        //assert
        Assert.Contains($"Documento [{document}] inválido!", exception.Message);
        Assert.Equal(EDocumentType.ERRO, doc.Type);
       
    }
    
    [Theory]
    [InlineData("54740606000192")]
    public void DeveRetornarSucessooAoCriarUmDocumentoCNPJValido(string document)
    {
        // arrange
        var doc = new Document(document);
        var validator = new DocumentValidator();
        
        
        //act
        var result = validator.Validate(doc);
        
        //assert
        Assert.True(result.IsValid);
        Assert.Equal(EDocumentType.CNPJ, doc.Type);
    }
    
    
    [Theory]
    [InlineData("13711827871")]
    public void DeveRetornarErroAoValidarUmDocumentoInvalido(string document)
    {
        // arrange
        var corp = new Corporate(document, "Cia São Paulo");
        var validator = new CorporateValidator();
        //Guid guidResult;
        
        
        //act
        var exception = Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(corp));
        
        //assert
        Assert.Contains($"Documento [{document}] inválido!", exception.Message);
        Assert.True(Guid.TryParse(corp.Id.ToString(), out Guid guidResult));
        Assert.Equal(EDocumentType.ERRO, corp.Document.Type);
        Assert.Equal("Cia São Paulo", corp.Name);
    }
    
    [Theory]
    [InlineData("13711827870")]
    public void DeveRetornarSucessoAoValidarUmDocumentoCPFValido(string document)
    {
        // arrange
        var corp = new Corporate(document, "Paulo");
        var validator = new CorporateValidator();
        
        
        //act
        var result = validator.Validate(corp);
        
        //assert
        Assert.True(result.IsValid && corp.Document.Type == EDocumentType.CPF);
    }
    
    
    [Theory]
    [InlineData("13711827871","13711827870")]
    [InlineData("13711827872","13711827870")]
    [InlineData("13711827873","13711827870")]
    [InlineData("13711827874","13711827870")]
    [InlineData("13711827875","13711827870")]
    [InlineData("13711827876","13711827870")]
    [InlineData("13711827877","13711827870")]
    [InlineData("13711827878","13711827870")]
    [InlineData("13711827879","13711827870")]
    public void DeveRetornarErroAoValidarUmDocumentoCorporacaoInvalido(string corporate, string newCompany)
    {
        // arrange
        var company = new Company(corporate, newCompany, "Cia São Paulo", "Rua Lopes, 87");
        var validator = new CompanyValidator();
        
        
        //act
        var exception = Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(company));
        
        //assert
        Assert.Contains($"Corporate.Type: Documento [{company.Corporate.Number}] inválido! Severity: Error", exception.Message);
    }
    
    [Theory]
    [InlineData("13711827870","13711827871")]
    [InlineData("13711827870","13711827872")]
    [InlineData("13711827870","13711827873")]
    [InlineData("13711827870","13711827874")]
    [InlineData("13711827870","13711827875")]
    [InlineData("13711827870","13711827876")]
    [InlineData("13711827870","13711827877")]
    [InlineData("13711827870","13711827878")]
    [InlineData("13711827870","13711827879")]
    public void DeveRetornarErroAoValidarUmDocumentoCompanhiaInvalido(string corporate, string newCompany)
    {
        // arrange
        var company = new Company(corporate, newCompany, "Cia São Paulo", "Rua Lopes, 87");
        var validator = new CompanyValidator();
        
        
        //act
        var exception = Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(company));
        
        //assert
        Assert.Contains($"Document.Type: Documento [{company.Document.Number}] inválido! Severity: Error", exception.Message);
        
    }
    
    [Theory]
    [InlineData("13711827870","13711827870")]
    public void DeveRetornarSucessoAoValidarUmDocumentoCorporacaoValido(string corporate, string newCompany)
    {
        // arrange
        var company = new Company(corporate, newCompany, "Cia São Paulo", "Rua Lopes, 87");
        var validator = new CompanyValidator();
        
        
        //act
        var result = validator.Validate(company);
        
        //assert
        Assert.True(result.IsValid);
    }
    
    [Theory]
    [InlineData("13711827870","13711827870")]
    public void DeveRetornarSucessoAoValidarUmDocumentoCompanhiaValido(string corporate, string newCompany)
    {
        // arrange
        var company = new Company(corporate, newCompany, "Cia São Paulo", "Rua Lopes, 87");
        var validator = new CompanyValidator();
        
        
        //act
        var result = validator.Validate(company);
        
        //assert
        Assert.True(result.IsValid);
        
    }
    
    [Theory]
    [InlineData("13711827870","13711827870")]
    public void DeveRetornarErroAoValidarNomeCompanhiaVazio(string corporate, string newCompany)
    {
        // arrange
        var company = new Company(corporate, newCompany, "", "Rua Lopes, 87");
        var validator = new CompanyValidator();
        
        
        //act
        var exception = Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(company));
        
        //assert
        Assert.Contains($"Name: Nome da Companhia não pode ser vazio! Severity: Error", exception.Message);
    }
    
    [Theory]
    [InlineData("13711827870","13711827870")]
    public void DeveRetornarErroAoValidarNomeCompanhiaNulo(string corporate, string newCompany)
    {
        // arrange
        var company = new Company(corporate, newCompany, null, "Rua Lopes, 87");
        var validator = new CompanyValidator();
        
        
        //act
        var exception = Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(company));
        
        //assert
        Assert.Contains($"Name: Nome da Companhia não pode ser nulo! Severity: Error", exception.Message);
    }

}