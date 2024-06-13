using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Task2;

public class FileTransformation : TransformationStrategy
{
    private DummyDirectory Root { get; set; }

    public FileTransformation(DummyDirectory root)
    {
        Root = root;
    }
    public override IFileSystemNode transform(IFileSystemNode node)
    {
        int depth = GetDepth(node);
        string transformedName = TransformName(((DummyNode)node).Name, depth);
        if(node.IsDir())
        {
            return new DummyDirectory(transformedName);
        } else
        {
            return new DummyFile(transformedName, node.GetPrintableContent(), Root);
        }
    }

    public override string TransformContent(string content)
    {
        return content;
    }

    public override string TransformName(string name, int depth)
    {
        return "|" + new string('-', depth) + name;
    }

    private int GetDepth(IFileSystemNode node)
    {
        int depth = 0;
        var current = node;
        while (current.GetParent() != null)
        {
            depth++;
            current = current.GetParent();
        }
        return depth;
    }
}

