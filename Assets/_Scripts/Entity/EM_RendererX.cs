using UnityEngine;

namespace Ksy.Entity.Module
{
    public class EM_RendererX : MonoBehaviour
    {
        public bool IsFilp { get; private set; }

        private SpriteRenderer _spRenderer;

        public void Init(SpriteRenderer spRenderer)
        {
            this._spRenderer = spRenderer;
        }

        #region Module
        public void FilpX(Vector2 dir)
        {
            if (dir == Vector2.zero) return;
            bool flip = dir.x < 0;

            _spRenderer.flipX = flip;
            IsFilp = flip;
        }
        public void FilpX(bool value)
        {
            _spRenderer.flipX = value;
            IsFilp = value;
        }
        #endregion
    }
}