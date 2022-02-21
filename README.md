# Serializer Helpers

Provides helpers for serializer and deserializer of data.

**NuGets**

|Name|Info|
| ------------------- | :------------------: |
|ObservableHelpers|[![NuGet](https://buildstats.info/nuget/SerializerHelpers?includePreReleases=true)](https://www.nuget.org/packages/SerializerHelpers/)|

## Installation
```csharp
// Install release version
Install-Package SerializerHelpers

// Install pre-release version
Install-Package SerializerHelpers -pre
```

## Supported frameworks
.NET Standard 2.0 and above - see https://github.com/dotnet/standard/blob/master/docs/versions.md for compatibility matrix

## Usage

### Serializer Sample
```csharp
using SerializerHelpers;

namespace YourNamespace
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> dictionary = new();
            dictionary.Add(1, "one");
            dictionary.Add(2, "two");
            dictionary.Add(3, "three");

            // The serialized value of the dictionary
            string? serialized = Serializer.Serialize(test1);
            
            // The vice-versa deserialized value
            Dictionary<int, string>? deserializedDictionary = Serializer.Deserialize<Dictionary<int, string>>(serialized);

            // "dictionary" and "deserializedDictionary" now have the same values.
        }
    }
}
```

### Custom Serializer Implementation Sample
```csharp
using SerializerHelpers;

namespace YourNamespace
{
    public class Dinosaur
    {
        public string Name { get; set; }
        
        public int Height { get; set; }
    }

    public class DinosaurSerializer : ISerializer<Dinonsaur>
    {
        public string? Serialize(Dinonsaur? value, string? defaultValue = default)
        {
            if (value == null)
            {
                return defaultValue;
            }
            return value.Name + "." + value.Height.ToString();
        }

        public Dinonsaur? Deserialize(string? data, Dinonsaur? defaultValue = default)
        {
            if (data == null)
            {
                return defaultValue;
            }
            string[] values = data.Separate('.');
            return new Dinosaur()
            {
                Name = values[0],
                Height = int.Parse(values[1])
            }
        }
    }
}
```

### Custom Serializer Sample 1
```csharp
using SerializerHelpers;

namespace YourNamespace
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Globally register the serializer.
            Serializer.Register(new DinosaurSerializer());

            Dinosaur dinosaur = new Dinosaur()
            {
                Name = "T-Rex",
                Height = 100
            }

            // The serialized value of the dinosaur
            string? serialized = Serializer.Serialize(dinosaur);
            
            // The vice-versa deserialized value
            Dinosaur? deserializedDinosaur = Serializer.Deserialize<Dinosaur>(serialized);

            // "dinosaur" and "deserializedDinosaur" now have the same values.
        }
    }
}
```

### Custom Serializer Sample 2
```csharp
using SerializerHelpers;

namespace YourNamespace
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Globally register the serializer.
            Serializer.Register(new DinosaurSerializer());

            Dictionary<int, Dinosaur> dinosaurs = new();
            dinosaurs.Add(1, new Dinosaur()
            {
                Name = "T-Rex",
                Height = 100
            });
            dinosaurs.Add(2, new Dinosaur()
            {
                Name = "Titanosauria",
                Height = 200
            });

            // The serialized value of the dinosaurs
            string? serialized = Serializer.Serialize(test1);
            
            // The vice-versa deserialized value
            Dictionary<int, Dinosaur>? deserializedDinosaurs = Serializer.Deserialize<Dictionary<int, Dinosaur>>(serialized);

            // "dinosaurs" and "deserializedDinosaurs" now have the same values.
        }
    }
}
```

### Want To Support This Project?
All I have ever asked is to be active by submitting bugs, features, and sending those pull requests down!.
