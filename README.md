# Composite Pattern in C#

This repository explores the Composite Pattern, one of the structural design patterns defined by the Gang of Four (GoF) in their foundational book on design patterns. The Composite Pattern is designed to compose objects into tree structures to represent part-whole hierarchies, allowing clients to treat individual objects and compositions uniformly.

## Types of Composite Pattern

In the context of the Composite Pattern, we often deal with two types of objects:

1. **Leaf**: Represents leaf objects in the composition. A leaf has no children.
2. **Composite**: Represents a component that has children. It can store leaf components and composite components.

The key idea is to have both Leaf and Composite objects implement a common interface or extend the same abstract class, providing a uniform way to interact with them.

## Example in C#

Below is a simple implementation of the Composite Pattern in C#. In this example, we create a common interface `IComponent` that both `Leaf` and `Composite` classes implement. This interface contains a method `PerformOperation()` that both leaf and composite objects use to perform an operation.

### IComponent.cs

```csharp
public interface IComponent
{
    void PerformOperation();
}
```

### Leaf.cs

```csharp
public class Leaf : IComponent
{
    private string name;

    public Leaf(string name)
    {
        this.name = name;
    }

    public void PerformOperation()
    {
        Console.WriteLine($"Leaf {name} performs an operation.");
    }
}
```

### Composite.cs

```csharp
public class Composite : IComponent
{
    private List<IComponent> children = new List<IComponent>();
    private string name;

    public Composite(string name)
    {
        this.name = name;
    }

    public void AddChild(IComponent component)
    {
        children.Add(component);
    }

    public void RemoveChild(IComponent component)
    {
        children.Remove(component);
    }

    public void PerformOperation()
    {
        Console.WriteLine($"Composite {name} performs an operation.");
        foreach (var child in children)
        {
            child.PerformOperation();
        }
    }
}
```

### Program.cs

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create composite structures
        var root = new Composite("Root");
        var leftChild = new Composite("Left");
        var rightChild = new Composite("Right");
        var leftLeaf = new Leaf("Left Leaf");
        var rightLeaf = new Leaf("Right Leaf");

        root.AddChild(leftChild);
        root.AddChild(rightChild);
        leftChild.AddChild(leftLeaf);
        rightChild.AddChild(rightLeaf);

        // Perform operation
        root.PerformOperation();
    }
}
```

This example demonstrates the basic structure and implementation of the Composite Pattern in C#. The `Composite` class can contain both `Leaf` and other `Composite` objects, allowing for the creation of complex tree structures. The `PerformOperation` method illustrates how operations can be applied both to individual leaves and to composites, which in turn recursively apply the operation to their children, demonstrating the uniform treatment of objects and compositions.
