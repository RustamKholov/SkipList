# Skip List Implementation in C#

An educational implementation of a Skip List data structure in C# with .NET 9.0, demonstrating probabilistic data structures and their operations.

## 📚 What is a Skip List?

A Skip List is a probabilistic data structure that maintains a sorted collection of elements with expected O(log n) time complexity for search, insertion, and deletion operations. It uses multiple levels of linked lists, where higher levels act as "express lanes" to skip over elements, providing efficient search performance similar to balanced trees but with simpler implementation.

## 🎯 Educational Goals

This project demonstrates:
- **Probabilistic Data Structures**: Understanding how randomization can improve algorithmic performance
- **Generic Programming**: Implementation using C# generics with type constraints
- **Interface Design**: Clean separation of concerns with `ISkipList<T>` interface
- **Unit Testing**: Comprehensive test coverage using xUnit framework

## 🔍 Algorithm Complexity

| Operation | Average Case | Worst Case |
|-----------|-------------|------------|
| Search    | O(log n)    | O(n)       |
| Insert    | O(log n)    | O(n)       |
| Delete    | O(log n)    | O(n)       |
| Update    | O(log n)    | O(n)       |



