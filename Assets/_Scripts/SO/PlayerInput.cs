using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Control;

[CreateAssetMenu(fileName = "EntityControllerSO", menuName = "SO")]
public class EntityControllerSO : ScriptableObject, IKeyboardActions
{
    private Control _listener;

    public Action<Vector2> OnChangedDir;
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
        Vector2 dir = context.ReadValue<Vector2>();

        OnChangedDir?.Invoke(dir);
    }
}
