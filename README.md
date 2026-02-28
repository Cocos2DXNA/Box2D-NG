# Box2D-NG
The next-generation port of the Box2D library.

Box2D-NG is a complete C# port of the original Data-Oriented Design (DOD) Box2D v3 C++ library. It preserves the highly optimized, memory-contiguous core of Box2D v3 while exposing a beautiful, modern Object-Oriented facade designed exclusively for C# and .NET 9.

## Features

- **DOD Performance**: Underlying storage relies on flat arrays, solver sets, and hardware intrinsic SIMD optimizations natively mapped from C++ to C#.
- **OOP Facade**: Replaces clunky opaque IDs (`b2BodyId`, `b2ShapeId`) from the C-API with garbage-collector-friendly, lightweight object wrappers (`World`, `Body`, `DistanceJoint`).
- **Fluent Definitions**: Create and configure definitions easily with chainable fluent builders.

## Getting Started

Because Box2D-NG provides a fluent configuration API, creating physics objects is concise and readable.

### 1. Creating a World
The `World` is the core solver pipeline. You can create one from a basic `WorldDef`.
```csharp
using Box2DNG;

var worldDef = new WorldDef()
    .WithGravity(new Vec2(0f, -10f))
    .WithContinuousCollision(true);

using var world = new World(worldDef);
```

### 2. Creating a Body & Fixture
Use `BodyDef` to declare the body parameters fluently, then assign geometry (Fixtures).
```csharp
// Define a completely dynamic body at (0, 10)
var bodyDef = new BodyDef()
    .AsDynamic()
    .At(0f, 10f)
    .WithLinearDamping(0.5f);

var body = world.CreateBody(bodyDef);

// Create a circle shape bounding the body
var circle = new Circle(new Vec2(0f, 0f), 1.0f);
var fixtureDef = new FixtureDef(circle)
    .WithDensity(1f)
    .WithFriction(0.3f);

body.CreateFixture(fixtureDef);
```

### 3. Simulating the World
Advance the physics sim step by step.
```csharp
float timeStep = 1.0f / 60.0f;
int subStepCount = 4;

world.Step(timeStep, subStepCount);
```

---

## Relationship to Original C++ Box2D
The original [Box2D v3 (Erin Catto)](https://box2d.org) moved to a Data-Oriented Design (DOD). Entities in the C++ API are purely opaque IDs, and data is packed into contiguous arrays to maximize CPU cache.

Box2D-NG acts as a 1:1 C# veneer. 
- It preserves the *exact* DOD mechanics internally (Islands, SIMD batched constraint solvers, Arena Allocators).
- It simplifies the end-user API by wrapping the DOD IDs into manageable `class` objects, making it idiomatic to C# without paying severe performance penalties.

## Testing & Code Coverage
Box2D-NG maintains high fidelity with the original system, backed by a significant suite of unit tests.

- **Test Framework:** MSTest / coverlet
- **Passing Tests:** 161 successful tests
- **Line Coverage:** ~66% (9,378 / 14,201 lines covered)
- **Method Coverage:** ~71%

To run the tests yourself and gather coverage locally:
```bash
cd Tests
dotnet test -c Release /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```
