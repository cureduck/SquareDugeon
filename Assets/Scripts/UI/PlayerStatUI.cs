using Managers;

namespace UI
{
    public class PlayerStatUI : StatusUI<PlayerStatUI>
    {
        public void Start()
        {
            Fighter = GameManager.Instance.GamePlayerData;
        }
    }
}