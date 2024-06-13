using System;
using System.Collections.Generic;
using System.Text;
using Task2;

public class FileContentTransformation : TransformationStrategy
{

    public override IFileSystemNode transform(IFileSystemNode node)
    {
        if (node.IsDir()) return node; 
        var transformedContent = TransformContent(node.GetPrintableContent());
        return new DummyFile(node.GetPrintableName(), transformedContent, (DummyDirectory) node.GetParent());
    }

    public override string TransformContent(string content)
    {
        return content.Replace("-", "");
    }

    public override string TransformName(string name, int depth)
    {
        return name;
    }
}

