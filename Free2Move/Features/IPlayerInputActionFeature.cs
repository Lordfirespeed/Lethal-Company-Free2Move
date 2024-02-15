/*
 * Copyright (c) 2024 Lordfirespeed.
 * Lordfirespeed licenses this file to you under the LGPL-3.0-OR-LATER license.
 */

using UnityEngine.InputSystem;

namespace Free2Move.Features;

public interface IPlayerInputActionFeature
{
    static InputActionAsset PlayerInputActions => IngamePlayerSettings.Instance.playerInput.actions;

    static InputAction PlayerMoveAction => PlayerInputActions.FindAction("Move", true);
}
