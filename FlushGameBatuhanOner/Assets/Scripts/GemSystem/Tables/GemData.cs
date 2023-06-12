using UnityEngine;

namespace GemSystem.Tables
{
    [CreateAssetMenu(fileName = "NewGame", menuName = "Gem")]
    public class GemData : ScriptableObject
    {
        public string gemName;
        public float startingSalesPrice;
        public Sprite gemIcon;
        public GameObject gemObject;
       
    }
}
