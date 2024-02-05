using DocumentCtrl.Domain.Base;
using DocumentCtrl.Domain.Validations.Entities;
using DocumentCtrl.Domain.ValueObjects;

namespace DocumentCtrl.Domain.Entities;

public class Company : Entity
{
    public Company(string corporate, string document, string name, string address)
    {
        var corp = new Document(corporate);
        var company = new Document(document);
        
        Corporate = corp;
        Document = company;
        Name = name;
        Address = address;
    }

    public Document Corporate { get; private set; }
    public Document Document { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
}