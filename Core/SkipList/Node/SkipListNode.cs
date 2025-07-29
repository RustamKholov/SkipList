using System;

namespace SkipList.Node;

public class SkipListNode<T>(T value, int level) where T : IComparable<T>
{
    public T Value { get; set; } = value;
    public List<SkipListNode<T>> Forward { get; set; } = [.. new SkipListNode<T>[level + 1]];
}