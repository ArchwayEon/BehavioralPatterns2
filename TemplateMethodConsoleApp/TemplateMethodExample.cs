using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodConsoleApp;

public abstract class TheApplication
{
    public List<Document> Documents { get; set; }
      = new List<Document>();

    public void OpenDocument(string name)
    {
        if (!CanOpenDocument(name))
        {
            Console.WriteLine($"Cannot open document {name}!");
            return;
        }

        Document doc = DoCreateDocument(name);
        if (doc != null)
        {
            Documents.Add(doc);
            AboutToOpenDocument(doc);
            doc.Open();
            doc.DoRead();
            doc.Close();
        }
    }

    protected abstract Document DoCreateDocument(string name);
    protected abstract bool CanOpenDocument(string name);
    protected abstract void AboutToOpenDocument(Document document);
}
public class MyApplication : TheApplication
{
    protected override void AboutToOpenDocument(Document document)
    {
        Console.WriteLine($"About to open {document.Name}");
    }

    protected override bool CanOpenDocument(string name)
    {
        if (name.Length < 10) return true;
        return false;
    }

    protected override Document DoCreateDocument(string name)
    {
        return new MyDocument { Name = name };
    }
}
public abstract class Document
{
    public string Name { get; set; }
    public void Save()
    {
        Console.WriteLine($"Saving {Name}");
    }

    public void Open()
    {
        Console.WriteLine($"Opening {Name}");
    }

    public void Close()
    {
        Console.WriteLine($"Closing {Name}");
    }

    public abstract void DoRead();
}
public class MyDocument : Document
{
    public override void DoRead()
    {
        Console.WriteLine($"Reading {Name}");
    }
}
