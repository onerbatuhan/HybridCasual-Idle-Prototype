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
        private void Start()
        {
            LoadEarningValue();
        }

        private void LoadEarningValue()
        {
            gameTotalEarningsValue = DataController.Instance.DataLoad("money");
            moneyTextUI.text = gameTotalEarningsValue.ToString();
        }
    }
}
