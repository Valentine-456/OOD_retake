using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task2;

public class BFSIterator : IIterator
{

    private Queue<IFileSystemNode> queue = new Queue<IFileSystemNode>();
    public BFSIterator(IFileSystemNode root)
    {
        queue.Enqueue(root);
    }

    public bool HasNext()
    {
        return queue.Count > 0;
    }

    public IFileSystemNode doNext()
    {
        if (!HasNext()) throw new InvalidOperationException();
        var current = queue.Dequeue();
        if (current.IsDir())
        {
            var directory = (DummyDirectory)current;
            var child = directory.FirstChild;
            while (child != null)
            {
                queue.Enqueue(child);
                child = child.Next;
            }
        }
        return current;
    }

}

