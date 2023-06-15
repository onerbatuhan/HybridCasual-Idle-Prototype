using System.Collections.Generic;
using DesignPatterns;
using UnityEngine;

namespace DataSaveSystem.Manager
{
    public class DataController : Singleton<DataController>
    {
        public void DataSave(int value,string key)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }

        public int DataLoad( string key)
        {
           return PlayerPrefs.GetInt(key);
        }
        public void DataSave(Dictionary<string,int> gemCounts,string gemCountKeyPrefix)
        {
            List<string> keys = new List<string>();
            foreach (var kvp in gemCounts)
            {
                string key = gemCountKeyPrefix + kvp.Key;
                int value = kvp.Value;
                PlayerPrefs.SetInt(key, value);
                keys.Add(key);
            }

            PlayerPrefs.SetString("GemCountsKeys", string.Join(",", keys.ToArray()));
            PlayerPrefs.Save();
        }

        public void DataLoad(Dictionary<string,int> gemCounts,string gemCountKeyPrefix)
        {
            gemCounts.Clear();
            foreach (var key in PlayerPrefs.GetString("GemCountsKeys", "").Split(','))
            {
                if (!string.IsNullOrEmpty(key) && PlayerPrefs.HasKey(key))
                {
                    string gemName = key.Substring(gemCountKeyPrefix.Length);
                    int gemCount = PlayerPrefs.GetInt(key);
                    gemCounts.Add(gemName, gemCount);
                }
            }
        }
    }
}
