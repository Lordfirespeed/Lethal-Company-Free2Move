using UnityEngine.InputSystem;

namespace Free2Move.Features;

public interface IPlayerInputActionFeature
{
    static InputActionAsset PlayerInputActions => IngamePlayerSettings.Instance.playerInput.actions;

    static InputAction PlayerMoveAction => PlayerInputActions.FindAction("Move", true);
}
