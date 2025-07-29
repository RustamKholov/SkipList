using System;
using System.Collections;
using SkipList.Node;

namespace SkipList.SkipList;

public class SkipList<T>(int maxLevel = 16) : IEnumerable<T>, ISkipList<T> where T : IComparable<T>
{
    private readonly SkipListNode<T> _header = new(default!, maxLevel);
    private readonly SkipListNode<T> _end = new(default!, maxLevel);
    private readonly int _maxLevel = maxLevel;
    private readonly Random _random = new();

    public void Delete(T value)
    {
        var current = _header;
        SkipListNode<T>[] update = new SkipListNode<T>[_maxLevel + 1];

        for (var i = _maxLevel; i >= 0; i--)
        {
            while (current.Forward[i] != null && current.Forward[i].Value.CompareTo(value) < 0)
            {
                current = current.Forward[i];
            }
            update[i] = current;
        }

        current = current.Forward[0];

        if (current != null && current.Value.CompareTo(value) == 0)
        {
            for (int i = 0; i < current.Forward.Count; i++)
            {
                update[i].Forward[i] = current.Forward[i];
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Insert(T value)
    {
        var current = _header;
        SkipListNode<T>[] update = new SkipListNode<T>[_maxLevel + 1];
        for (var i = _maxLevel; i >= 0; i--)
        {
            while (current.Forward[i] != null && current.Forward[i].Value.CompareTo(value) < 0)
            {
                current = current.Forward[i];
            }
            update[i] = current;
        }
        current = current.Forward[0];
        if (current == null || current.Value.CompareTo(value) != 0)
        {
            int level = MakeRandomLevel();
            SkipListNode<T> newNode = new(value, level);
            for (int i = 0; i <= level; i++)
            {
                newNode.Forward[i] = update[i].Forward[i];
                update[i].Forward[i] = newNode;
            }
        }
    }

    public SkipListNode<T>? Search(T value)
    {
        var current = _header;
        for (var i = _maxLevel; i >= 0; i--)
        {
            while (current.Forward[i] != null && current.Forward[i].Value.CompareTo(value) < 0)
            {
                current = current.Forward[i];
            }
        }
        current = current.Forward[0];
        if (current != null && current.Value.CompareTo(value) == 0)
        {
            return current;
        }
        return null;
    }

    public void Update(T oldValue, T newValue)
    {
        Delete(oldValue);
        Insert(newValue);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private int MakeRandomLevel()
    {
        int level = 0;
        while (level < _maxLevel && _random.NextDouble() < 0.5)
        {
            level++;
        }
        return level;
    }
}
