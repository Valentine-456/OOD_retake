using System;
using System.Collections.Generic;
using System.Text;
using Task2;

public abstract class TransformationStrategy
{
    public abstract IFileSystemNode transform(IFileSystemNode node);
    public abstract string TransformName(string name, int depth);
    public abstract string TransformContent(string content);
}
