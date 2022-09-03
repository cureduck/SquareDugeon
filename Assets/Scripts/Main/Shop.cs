using UI;

namespace Main
{
    public class Shop : ReactElement<ShopSaveData>
    {
        public override void OnFocus()
        {
            ShopUI.Instance.Load(this);
        }

        protected override void SetLocalScale()
        {
            
        }
    }
}