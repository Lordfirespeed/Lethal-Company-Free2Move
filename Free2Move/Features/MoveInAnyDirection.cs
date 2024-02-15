using BepInEx.Logging;
using UnityEngine.InputSystem;

namespace Free2Move.Features;

public sealed class MoveInAnyDirection : IFeature, IPlayerInputActionFeature
{
    private static ManualLogSource _logger = null!;

    ManualLogSource IFeature.Logger {
        set => _logger = value;
    }

    public void OnEnable()
    {
        RemoveCompositeBinding();
        AddDirectBinding();
    }

    private void RemoveCompositeBinding()
    {
        var context = IPlayerInputActionFeature.PlayerMoveAction
            .ChangeCompositeBinding("Gamepad");

        if (!context.valid) return;

        context.Erase();
    }

    private void AddDirectBinding()
    {
        var existingBindingIndex = IPlayerInputActionFeature.PlayerMoveAction
            .GetBindingIndex(path: "<Gamepad>/leftStick");

        if (existingBindingIndex > 0) return;

        IPlayerInputActionFeature.PlayerMoveAction
            .AddBinding("<Gamepad>/leftStick");
    }
}
