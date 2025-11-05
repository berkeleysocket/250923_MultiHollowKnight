using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public SpriteRenderer SpriteRendererCompo { get; private set; }
    private void Awake()
    {
        SpriteRendererCompo = GetComponent<SpriteRenderer>();
    }
    public void Moved_Handler(Vector2 moveDir)
    {
        Debug.Log("Flip");
        bool flip = moveDir.x < 0;
        SpriteRendererCompo.flipX = flip;
    }
}
