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
        SetAnalogBindingMode();
    }

    private void SetAnalogBindingMode()
    {
        IPlayerInputActionFeature.PlayerMoveAction
            .ChangeCompositeBinding("Gamepad")
            .WithPath("2DVector(mode=2)");
    }
}
