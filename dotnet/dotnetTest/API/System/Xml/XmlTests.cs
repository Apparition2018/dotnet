using System.Reflection;
using System.Xml;
using dotnet.L.Demo;

namespace dotnetTest.API.System.Xml;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.xml">System.Xml</a>
/// </summary>
public class XmlTests : Demo
{
    private Stream? _stream;

    [SetUp]
    public void SetUp()
    {
        Assembly assembly = Assembly.Load(Dotnet);
        _stream = assembly.GetManifestResourceStream($"{DemoDirAssemblyPath}.Person.xml");
    }

    [Test]
    public void XmlDocumentAndXmlNode()
    {
        XmlDocument doc = new();
        doc.Load(_stream!);
        XmlNode? rootNode = doc.DocumentElement;
        List<Person> persons = [];
        if (rootNode == null) return;
        foreach (XmlNode personNode in rootNode.ChildNodes)
        {
            if (personNode.Name != nameof(Person)) continue;
            Person p = new();
            foreach (XmlNode personFieldNode in personNode)
            {
                switch (personFieldNode.Name)
                {
                    case nameof(Person.Name):
                        p.Name = personFieldNode.InnerText;
                        break;
                    case nameof(Person.Age):
                        p.Age = Convert.ToInt16(personFieldNode.InnerText);
                        break;
                    case nameof(Person.Gender):
                        p.Gender = personFieldNode.InnerText;
                        break;
                    case nameof(Home):
                        Home h = new();
                        foreach (XmlNode homeFiledNode in personFieldNode)
                        {
                            switch (homeFiledNode.Name)
                            {
                                case nameof(Home.Address):
                                    h.Address = homeFiledNode.InnerText;
                                    break;
                                case nameof(Home.Tel):
                                    h.Tel = homeFiledNode.InnerText;
                                    break;
                            }
                        }

                        p.Home = h;
                        break;
                }
            }

            persons.Add(p);
        }

        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }

    [Test]
    public void XmlTextReader()
    {
        XmlTextReader reader = new(_stream!);
        string info = string.Empty;
        while (reader.Read())
        {
            if (reader.Name != "Version") continue;
            info = "版本：" + reader.GetAttribute("vNo") + " 发布时间：" + reader.GetAttribute("pTime");
            break;
        }

        Console.WriteLine(info);
    }

    [TearDown]
    public void TearDown()
    {
        _stream?.Dispose();
        _stream = null;
    }
}
