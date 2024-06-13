using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task2;

public class DFSIterator : IIterator
{
    private Stack<IFileSystemNode> stack = new Stack<IFileSystemNode>();

    public DFSIterator(IFileSystemNode root)
    {
        stack.Push(root);
    }

    public bool HasNext()
    {
        return stack.Count > 0;
    }

    public IFileSystemNode doNext()
    {
        if (!HasNext()) throw new InvalidOperationException();
        var current = stack.Pop();
        if (current.IsDir())
        {
            var directory = (DummyDirectory)current;
            var child = directory.FirstChild;
            while (child != null)
            {
                stack.Push(child);
                child = child.Next;
            }
        }
        return current;

    }
}

