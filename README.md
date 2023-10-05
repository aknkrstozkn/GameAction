# GameAction Class

## Description
`GameAction` is a custom Action class accompanied by its helper. Designed for game development, its primary intent is to offer a more secure and efficient means of using Actions.

## Usage

### Declaration
Declaring a `GameAction` is slightly different than a standard Action. Below is a comparison:

**Default Action**:  
```csharp
public Action<int> CollectableTriggered;
```
GameAction:

```csharp
public GameAction<int> CollectableTriggered = new GameAction<int>(nameof(OnCollectableTriggered), ref _onDestroy);
```
## Constructor Parameters:
When using GameAction, there are two essential parameters for its constructor:

### Name for Logging: 
This serves as the name of the GameAction and is intended for logging purposes.
### Optional Destroy Trigger Action: 
A trigger action, provided for static usage security. It's purposefully crafted to clear GameActions when the associated action gets invoked.
