using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Control;

[CreateAssetMenu(fileName = "PlayerInput", menuName = "SO/Input/Player")]
public class PlayerInput : ScriptableObject, IKeyboardActions
{
    private Control _listener;
    public Vector2 MoveDir { get; private set; }
    public Vector2 MousePos { get; private set; }

    public Action<Vector2> OnChangedPlayerPos;
    public Action<Vector2> OnChangedMousePos;
    public Action<Vector2> OnLeftClicked;

    #region Unity Evenet
    private void OnEnable()
    {
        if(_listener == null) _listener = new Control();

        _listener.Keyboard.Enable();
        _listener.Keyboard.SetCallbacks(this);
    }

    private void OnDisable()
    {
        _listener.Keyboard.Disable();
    }
    #endregion

    public void OnMove_Horaizontal(InputAction.CallbackContext context)
    {
        //이벤트가 호출되어서 움직이고 있는 방향 값을 넘겨줌.
        Vector2 dir = context.ReadValue<Vector2>();

        //프로퍼티에 받은 값을 할당함.
        MoveDir = dir;

        OnChangedPlayerPos?.Invoke(dir);
    }
}
