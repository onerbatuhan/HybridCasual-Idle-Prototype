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
        public void DataSave(Dictionary<string,int> objectCounts,string objectCountKeyPrefix)
        {
            List<string> keys = new List<string>();
            foreach (var kvp in objectCounts)
            {
                string key = objectCountKeyPrefix + kvp.Key;
                int value = kvp.Value;
                PlayerPrefs.SetInt(key, value);
                keys.Add(key);
            }

            PlayerPrefs.SetString("objectCountsKeys", string.Join(",", keys.ToArray()));
            PlayerPrefs.Save();
        }

        public void DataLoad(Dictionary<string,int> objectCounts,string objectCountKeyPrefix)
        {
            objectCounts.Clear();
            foreach (var key in PlayerPrefs.GetString("objectCountsKeys", "").Split(','))
            {
                if (!string.IsNullOrEmpty(key) && PlayerPrefs.HasKey(key))
                {
                    string gemName = key.Substring(objectCountKeyPrefix.Length);
                    int gemCount = PlayerPrefs.GetInt(key);
                    objectCounts.Add(gemName, gemCount);
                }
            }
        }
    }
}
