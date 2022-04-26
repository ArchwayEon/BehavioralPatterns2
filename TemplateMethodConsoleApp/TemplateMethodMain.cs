using System;

namespace TemplateMethodConsoleApp;

class TemplateMethodMain
{
    static void Main(string[] args)
    {
        MyApplication app = new();
        app.OpenDocument("document1");
        app.OpenDocument("document2longname");
    }

}
