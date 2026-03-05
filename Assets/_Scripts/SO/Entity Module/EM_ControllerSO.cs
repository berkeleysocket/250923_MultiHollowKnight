using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Control;

[CreateAssetMenu(fileName = "EM_ControllerSO", menuName = "SO")]
public class EM_ControllerSO : ScriptableObject, IKeyboardActions
{
    private Control _controller;

    public Action<Vector2> OnPressedMoveKey;
    public Action<Vector2> OnChangedMousePos;
    public Action<Vector2> OnLeftClicked;

    #region Unity Evenet
    private void OnEnable()
    {
        if(_controller == null) _controller = new Control();

        _controller.Keyboard.Enable();
        _controller.Keyboard.SetCallbacks(this);
    }

    private void OnDisable()
    {
        _controller.Keyboard.Disable();
    }
    #endregion

    public void OnMove_Horaizontal(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();

        OnPressedMoveKey?.Invoke(dir);
    }
}
