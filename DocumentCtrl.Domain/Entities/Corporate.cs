using DocumentCtrl.Domain.Base;
using Document = DocumentCtrl.Domain.ValueObjects.Document;

namespace DocumentCtrl.Domain.Entities;

public class Corporate : Entity
{
    private IList<Company> _companies;
    public Corporate(string newDocument, string name)
    {
        var document = new Document(newDocument);
        
        Document = document;
        Name = name;

        _companies = new List<Company>();
    }

    public Document Document { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyCollection<Company> Companies { get { return _companies.ToArray(); } }

    public void AddCompany(Company company)
    {
        _companies.Add(company);
    }
}

