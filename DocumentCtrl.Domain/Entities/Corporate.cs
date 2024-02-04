using DocumentCtrl.Domain.Base;
using Document = DocumentCtrl.Domain.ValueObjects.Document;

namespace DocumentCtrl.Domain.Entities;

public class Corporate : Entity
{
    public Corporate(string newDocument, string name)
    {
        var document = new Document(newDocument);
        
        Document = document;
        Name = name;
    }

    public Document Document { get; private set; }
    public string Name { get; private set; }
    
}

