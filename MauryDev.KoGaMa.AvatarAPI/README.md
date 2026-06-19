# 📦 MauryDev.KoGaMa.AvatarAPI

`MauryDev.KoGaMa.AvatarAPI` is a specialized library designed for managing, manipulating, and persisting avatar data for the KoGaMa ecosystem. It provides the necessary data structures and logic to handle avatar compositions, equipment mapping, bone positioning, and spatial constraint validation.

## 🚀 Overview

The library acts as the data logic layer between the technical definition of an avatar (where parts are located and their size limits) and the actual instance of an avatar equipped by a user.

The core workflow is based on three pillars:
1. **Registry**: Static definitions of "where" and "how" each body part must exist.
2. **Info**: The current state of an avatar (which models are equipped in which slots).
3. **Serialization**: The ability to save and load this state via a `Stream`.

---

## 🛠️ Detailed Architecture

### 1. `PartIndex` (Enumeration)
Defines the available slots for equipment. This is the primary key for any operation involving avatar parts.
- **Members**: `Head`, `Torso`, `RArm`, `LArm`, `RUpLeg`, `RLowLeg`, `LUpLeg`, `LLowLeg`, `Holster`, `Size`.

### 2. `AvatarPartRegistry` (Static Registry)
The "Source of Truth" for the library. This static class contains immutable definitions for every part of the body.
- **Function**: Maps each `PartIndex` to a `PartDefinition`.
- **Utility**: Allows the system to determine, for example, that the `Head` slot has a specific bone position and bounding box constraints for model construction.

### 3. `PartDefinition` (Data Model)
Contains the technical constraints and metadata for each avatar slot:
- **`Name`**: Human-readable name of the part.
- **`BonePosition`**: The `Vector3` offset where the model should be anchored.
- **`MinCubes`**: The minimum number of cubes required for the part to be valid.
- **`BoxMin` / `BoxMax`**: Vectors defining the allowed area for the part's construction (Bounding Box).

### 4. `AvatarInfo` (Core Logic)
The main class representing an individual avatar. It manages a dictionary of `ModelInfo` objects indexed by `PartIndex`.

**Key Capabilities:**
- **Equipment Management**: Methods to `Equip(index, model)` and `Unequip(index)` parts.
- **Fast Access**: Implements an indexer, allowing direct access via `avatarInfo[PartIndex.Head]`.
- **Validation**: The `IsFullyEquipped()` method checks if essential parts (Head and Torso) are present.
- **Integration**: Provides shortcuts like `GetBonePosition(index)` which internally query the `AvatarPartRegistry`.

### 5. `ISerializer` (Interface)
Defines the contract for any data persistence implementation. Since the library remains agnostic to the storage format (JSON, XML, Binary), you can implement your own serializer by adhering to this interface.

---

## 💻 Usage Examples

### Creating and Equipping an Avatar
```csharp
using MauryDev.KoGaMa.AvatarAPI;
using MauryDev.KoGaMa.AvatarAPI.Enums;
using MauryDev.KoGaMa.ModelAPI.Model; // Source of ModelInfo

// 1. Instantiate avatar information
AvatarInfo myAvatar = new AvatarInfo();

// 2. Define model information (hypothetical)
ModelInfo headModel = new ModelInfo { /* model data */ };
ModelInfo torsoModel = new ModelInfo { /* model data */ };

// 3. Equip parts to slots
myAvatar.Equip(PartIndex.Head, headModel);
myAvatar.Equip(PartIndex.Torso, torsoModel);

// 4. Check if the avatar is ready for instantiation/rendering
if (myAvatar.IsFullyEquipped()) 
{
    Console.WriteLine("Basic avatar configured successfully!");
}
```

### Querying Technical Definitions
```csharp
// Get the bone position for the Right Upper Leg
Vector3 bonePos = myAvatar.GetBonePosition(PartIndex.RUpLeg);

// Get the full definition to validate construction limits
var definition = myAvatar.GetDefinition(PartIndex.Head);
Console.WriteLine($"Head requires at least {definition.MinCubes} cubes.");
Console.WriteLine($"Head Bounding Box Max: {definition.BoxMax}");
```

### Implementing a Custom Serializer
```csharp
public class JsonAvatarSerializer : ISerializer
{
    public void Serialize(Stream stream, AvatarInfo avatar)
    {
        // Logic to convert AvatarInfo to JSON and write to the stream
    }

    public AvatarInfo Deserialize(Stream stream)
    {
        // Logic to read JSON from the stream and reconstruct AvatarInfo
        return new AvatarInfo(); 
    }
}
```

---

## ⚙️ Technical Specifications

- **Target Framework**: `.NET Standard 2.0` (Ensures compatibility with .NET Core, .NET Framework, and Unity).
- **C# Version**: `7.3`.
- **Dependencies**:
    - `MauryDev.KoGaMa.ModelAPI`: For the `ModelInfo` class definition.
    - `System.Numerics.Vectors`: Used for positional and dimensional calculations (`Vector3`).

## 📂 Namespace Structure

- `MauryDev.KoGaMa.AvatarAPI`: Core classes and business logic.
- `MauryDev.KoGaMa.AvatarAPI.Enums`: Type definitions and enumerations.
- `MauryDev.KoGaMa.AvatarAPI.Models`: Data models and part definitions.

---
**Author:** Maury