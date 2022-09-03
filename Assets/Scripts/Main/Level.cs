using Managers;

namespace Main
{
    public class Level : ReactElement<LevelSaveData>
    {
        public override void OnFocus()
        {
            GameManager.Instance.GoUpstairs();
        }

        protected override void SetLocalScale()
        {
            
        }
    }
}