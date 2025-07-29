using System;
using SkipList.Node;
using SkipList.SkipList;

namespace SkipListTests;

public class SkipListTest
{
    [Fact]
    public void TestName()
    {
        // Given
        SkipList<int> skipListInts = [];

        // When

        // Then
        Assert.NotNull(skipListInts);
    }

    [Fact]
    public void TestInsertNumberToSkipListInts()
    {
        // Given
        SkipList<int> skipListInts = [];

        // When
        skipListInts.Insert(5);
        var value = skipListInts.Search(5);

        // Then
        Assert.NotNull(value);
        Assert.IsType<SkipListNode<int>>(value);
        Assert.Equal(5, value.Value);
    }

    [Fact]
    public void TestDeleteExistingValue()
    {
        // Given
        SkipList<int> skipList = [];
        skipList.Insert(10);
        skipList.Insert(20);
        skipList.Insert(30);

        var existingValue = skipList.Search(20);
        Assert.NotNull(existingValue);

        // When
        skipList.Delete(20);

        // Then
        var deletedValue = skipList.Search(20);
        Assert.Null(deletedValue);

        Assert.NotNull(skipList.Search(10));
        Assert.NotNull(skipList.Search(30));
    }

    [Fact]
    public void TestDeleteNonExistingValue()
    {
        // Given
        SkipList<int> skipList = [];
        skipList.Insert(10);
        skipList.Insert(30);

        // When 
        skipList.Delete(20);

        // Then 
        Assert.NotNull(skipList.Search(10));
        Assert.NotNull(skipList.Search(30));
        Assert.Null(skipList.Search(20));
    }

    [Fact]
    public void TestDeleteFromEmptyList()
    {
        // Given
        SkipList<int> skipList = [];

        // When
        skipList.Delete(10);

        // Then
        Assert.Null(skipList.Search(10));
    }


    [Fact]
    public void TestUpdateExistingValue()
    {
        // Given
        SkipList<int> skipList = [];
        skipList.Insert(10);
        skipList.Insert(20);
        skipList.Insert(30);

        Assert.NotNull(skipList.Search(20));

        // When
        skipList.Update(20, 25);

        // Then
        Assert.Null(skipList.Search(20)); 
        Assert.NotNull(skipList.Search(25)); 
        Assert.NotNull(skipList.Search(10));
        Assert.NotNull(skipList.Search(30));
    }

    [Fact]
    public void TestUpdateNonExistingValue()
    {
        // Given
        SkipList<int> skipList = [];
        skipList.Insert(10);
        skipList.Insert(30);

        // When 
        skipList.Update(20, 25);

        // Then 
        Assert.NotNull(skipList.Search(25));
        Assert.NotNull(skipList.Search(10));
        Assert.NotNull(skipList.Search(30));
        Assert.Null(skipList.Search(20));
    }

    [Fact]
    public void TestUpdateToExistingValue()
    {
        // Given
        SkipList<int> skipList = [];
        skipList.Insert(10);
        skipList.Insert(20);
        skipList.Insert(30);

        // When 
        skipList.Update(20, 30);

        // Then 
        Assert.Null(skipList.Search(20));
        Assert.NotNull(skipList.Search(30));
        Assert.NotNull(skipList.Search(10));
    }

}
