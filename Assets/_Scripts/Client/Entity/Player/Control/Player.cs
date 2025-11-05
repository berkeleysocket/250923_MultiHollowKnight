using UnityEngine;

public class Player : Entity
{
    [SerializeField] private InputInfo_Player inputInfo;
    public Movement MovementCompo { get; private set; }
    public Renderer RendererCompo { get; private set; }
    public AnimationPlayer AniPlayerCompo { get; private set; }

    private void Awake()
    {
        MovementCompo = GetComponent<Movement>();

        AniPlayerCompo = GetComponentInChildren<AnimationPlayer>();
        RendererCompo = GetComponentInChildren<Renderer>();

        Debug.Assert(MovementCompo != null, "<color=red>MovementCompo is null!!</color>");

        Debug.Assert(AniPlayerCompo != null, "<color=red>AniPlayerCompo is null!!</color>");
        Debug.Assert(RendererCompo != null, "<color=red>RendererCompo is null!!</color>");

        if (MovementCompo != null && inputInfo != null)
            inputInfo.OnChangedPlayerPos += MovementCompo.SetMoveDir;

        if (AniPlayerCompo != null && inputInfo != null)
            inputInfo.OnChangedPlayerPos += (dir) =>
            {
                AniParmType parmT = AniParmType.IsMove;
                bool isMove = dir != Vector2.zero;

                AniPlayerCompo.SetAnimation(parmT, isMove);
            };
        if (RendererCompo != null && inputInfo != null)
            inputInfo.OnChangedMousePos += RendererCompo.FilpX;
        if (inputInfo != null)
            inputInfo.OnLeftClicked += (pos) => Debug.Log($"<color=yellow>Left Click!! / Pos : {pos}");
    }
}
