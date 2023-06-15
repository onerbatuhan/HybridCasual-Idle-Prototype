using System;
using DataSaveSystem.Manager;
using DesignPatterns;
using TMPro;
using UnityEngine;

namespace GameSystem.Manager
{
    public class GameController : Singleton<GameController>
    {
        public int gameTotalEarningsValue;
        public TextMeshProUGUI moneyTextUI;
        public const string EarningKey = "money";  
        public const string GemCountKeyPrefix = "GemCount_";
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
