using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Control;

[CreateAssetMenu(fileName = "InputInfo_Player", menuName = "SO/Input/Player")]
public class InputInfo_Player : ScriptableObject, IPlayerActions
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

        _listener.Player.Enable();
        _listener.Player.SetCallbacks(this);
    }

    private void OnDisable()
    {
        _listener.Player.Disable();
    }
    #endregion

    //플레이어가 이동 키를 누를 때 마다 호출되는 이벤트.
    public void OnMove(InputAction.CallbackContext context)
    {
        //이벤트가 호출되어서 움직이고 있는 방향 값을 넘겨줌.
        Vector2 dir = context.ReadValue<Vector2>();

        //프로퍼티에 받은 값을 할당함.
        MoveDir = dir;

        OnChangedPlayerPos?.Invoke(dir);
    }
    public void OnAim(InputAction.CallbackContext context)
    {
        Vector2 pos = context.ReadValue<Vector2>();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(pos);

        MousePos = worldPos;

        OnChangedMousePos?.Invoke(worldPos);
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        OnLeftClicked?.Invoke(MousePos);
    }
}
