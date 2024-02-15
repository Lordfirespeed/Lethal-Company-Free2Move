/*
 * Copyright (c) 2024 Lordfirespeed.
 * Lordfirespeed licenses this file to you under the LGPL-3.0-OR-LATER license.
 */

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
        ResetBindingMode();
    }

    private void ResetBindingMode()
    {
        IPlayerInputActionFeature.PlayerMoveAction
            .ChangeCompositeBinding("Gamepad")
            .WithPath("2DVector");
    }
}
