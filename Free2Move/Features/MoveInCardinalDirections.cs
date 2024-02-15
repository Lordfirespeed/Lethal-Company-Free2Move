using BepInEx.Logging;
using UnityEngine.InputSystem;

namespace Free2Move.Features;

public sealed class MoveInCardinalDirections : IFeature, IPlayerInputActionFeature
{
    private static ManualLogSource _logger = null!;

    ManualLogSource IFeature.Logger {
        set => _logger = value;
    }

    public void OnEnable()
    {
        RemoveDirectBinding();
        AddCompositeBinding();
    }

    private void RemoveDirectBinding()
    {
        var context = IPlayerInputActionFeature.PlayerMoveAction
            .ChangeBindingWithPath("<Gamepad>/leftStick");

        if (!context.valid) return;

        context.Erase();
    }

    private void AddCompositeBinding()
    {
        var testContext = IPlayerInputActionFeature.PlayerMoveAction
            .ChangeCompositeBinding("Gamepad");

        if (testContext.valid) return;

        var context = IPlayerInputActionFeature.PlayerMoveAction
            .AddCompositeBinding("2DVector")
            .With("up", "<Gamepad>/leftStick/up")
            .With("down", "<Gamepad>/leftStick/down")
            .With("left", "<Gamepad>/leftStick/left")
            .With("right", "<Gamepad>/leftStick/right");

        IPlayerInputActionFeature.PlayerMoveAction
            .ChangeCompositeBinding("2DVector")
            .WithName("Gamepad");
    }
}
