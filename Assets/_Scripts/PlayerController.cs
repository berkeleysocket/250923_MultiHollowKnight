using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 InputDir { get; private set; }
    private void Update()
    {
        Input_PlayerDir();
        Debug.Log(InputDir);
    }

    private void Input_PlayerDir()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) dir.y += 1f;
        else if (Input.GetKeyUp(KeyCode.W)) dir.y = 0f;
        if (Input.GetKey(KeyCode.S)) dir.y -= 1f;
        else if (Input.GetKeyUp(KeyCode.S)) dir.y = 0f;
        if (Input.GetKey(KeyCode.A)) dir.x -= 1f;
        else if (Input.GetKeyUp(KeyCode.A)) dir.x = 0f;
        if (Input.GetKey(KeyCode.D)) dir.x += 1f;
        else if (Input.GetKeyUp(KeyCode.D)) dir.y = 0f;

        InputDir = dir;
    }
}
