Since the provided code is part of a larger ecosystem (`MauryDev.KoGaMa`), the README should be professional, technical, and clearly explain the separation between the **Domain Model** and the **Data Transfer Object (DTO)**.

# KoGaMa Avatar Serializer (KGMT)

A specialized serialization library designed to handle KoGaMa avatar data. This library provides a robust way to convert complex avatar domain models into a compact binary format using **MessagePack**, ensuring efficient storage and transmission of avatar information.

## 🚀 Overview

The `KGMTSerializer` acts as a bridge between the internal domain representation of a KoGaMa avatar (`AvatarInfo`) and a serialized binary stream. To maintain a clean architecture, the library utilizes the **Mapper Pattern**, separating the data structure used for serialization (DTO) from the business logic model (Domain).

### Key Features
- **Efficient Binary Serialization**: Leverages [MessagePack](https://msgpack.org/) for high-performance, low-size binary data.
- **Decoupled Architecture**: Uses an `IAvatarMapper` to ensure that changes in the domain model do not necessarily break the serialization format.
- **Stream-Based**: Works directly with `System.IO.Stream`, making it compatible with files, network sockets, or memory streams.
- **Extensible**: Allows for the injection of custom mapping logic via the `IAvatarMapper` interface.

## 📦 Dependencies

To use this library, you will need the following dependencies:
- **.NET Standard 2.0+ / .NET Core / .NET 5+**
- **MessagePack**: Used for the actual binary serialization.
- **MauryDev.KoGaMa.ModelAPI**: Contains the base `CubeInfo` definitions.
- **MauryDev.KoGaMa.AvatarAPI**: Contains the base `AvatarInfo` definitions.
- **MauryDev.KoGaMa.ModelAPI.KoGaMaTools**: Contains the base `ModelMapper` definitions.

## 🛠 Architecture

The library is divided into three main components:

1. **`KGMTSerializer`**: The primary service. It orchestrates the process:
   - `Serialize`: Domain -> Mapper -> DTO -> MessagePack-> Stream.
   - `Deserialize`: Stream -> MessagePack -> DTO -> Mapper -> Domain.
2. **`AvatarMapper`**: Responsible for translating the `AvatarInfo` dictionary-like structure into a flat `AvatarInfoDTO` object.
3. **`AvatarInfoDTO`**: A lightweight data transfer object optimized for binary serialization, containing arrays of `CubeInfoDTO` for each body part (Head, Torso, Arms, Legs).

## 💻 Usage

### Basic Example

```csharp
using System.IO;
using MauryDev.KoGaMa.AvatarAPI.KoGaMaTools;
using MauryDev.KoGaMa.ModelAPI.KoGaMaTools;

// 1. Setup the serializer
var serializer = new KGMTSerializer();

// 2. Your AvatarInfo domain object
AvatarInfo myAvatar = GetAvatarFromGame(); 

// --- SERIALIZATION ---
using (FileStream fs = new FileStream("avatar.kgmt", FileMode.Create))
{
    serializer.Serialize(fs, myAvatar);
}

// --- DESERIALIZATION ---
using (FileStream fs = new FileStream("avatar.kgmt", FileMode.Open))
{
    AvatarInfo loadedAvatar = serializer.Deserialize(fs);
    // Use your loaded avatar here
}
```

### Advanced Usage (Custom Mapping)

If you need to change how the domain model is mapped to the DTO, you can implement your own `IAvatarMapper`:

```csharp
public class MyCustomMapper : IAvatarMapper 
{
    public AvatarInfoDTO ToDto(AvatarInfo avatarInfo) { /* Custom Logic */ }
    public AvatarInfo ToDomain(AvatarInfoDTO dto) { /* Custom Logic */ }
}

// Inject the custom mapper into the serializer
var serializer = new KGMTSerializer(new MyCustomMapper());
```

## 📋 API Reference

### `KGMTSerializer`
| Method | Parameters | Description |
| :--- | :--- | :--- |
| `Serialize(Stream, AvatarInfo)` | `Stream stream`, `AvatarInfo avatar` | Converts the domain model to a DTO and writes the MessagePack binary to the stream. |
| `Deserialize(Stream)` | `Stream stream` | Reads MessagePack binary from the stream, converts it to a DTO, and maps it back to the domain model. |

### `IAvatarMapper`
| Method | Description |
| :--- | :--- |
| `ToDto(AvatarInfo)` | Converts the domain object to a serializable DTO. |
| `ToDomain(AvatarInfoDTO)` | Converts the serialized DTO back into the domain object. |

## 🛠 Technical Details

### Data Mapping Logic
The `AvatarMapper` specifically handles the mapping of `Enums.PartIndex` (Head, Torso, etc.) to the corresponding properties in the `AvatarInfoDTO`. This ensures that the order and integrity of the avatar's body parts are preserved during the binary conversion.

### Complexity
- **Time Complexity**: `O(N)` where `N` is the number of cubes in the avatar.
- **Space Complexity**: `O(N)` to hold the DTO temporary representation before writing to the stream.