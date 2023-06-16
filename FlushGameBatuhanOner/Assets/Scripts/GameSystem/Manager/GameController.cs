
using DataSaveSystem.Manager;
using DesignPatterns;
using TMPro;

namespace GameSystem.Manager
{
    public class GameController : Singleton<GameController>
    {
        public int gameTotalEarningsValue;
        public TextMeshProUGUI moneyTextUI;  //UISystem>Events>UIElementsDataEvent'e al.
        public const string EarningKey = "money";  
        public const string GemCountKeyPrefix = "GemCount_";
        public const string ObjectCountsKey = "objectCountsKeys";
        private void Start()
        {
            LoadEarningValue();
        }

        private void LoadEarningValue()
        {
            gameTotalEarningsValue = DataController.Instance.DataLoad(EarningKey);
            moneyTextUI.text = gameTotalEarningsValue.ToString();
        }
    }
}
