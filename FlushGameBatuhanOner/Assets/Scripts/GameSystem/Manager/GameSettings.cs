using Unity.VisualScripting;
using UnityEngine;

namespace GameSystem.Manager
{
    public class GameSettings : DesignPatterns.Singleton<GameSettings>
    {
        [Header("[Gem Event Settings]")] 
        [Space(10)]
        public float scaleGrowthTime;
        public float collectibleScaleLimit;
        public float yAxisAddValue;
        public float yAxisRiseSpeed;
        public float rotationSpeed;
        public Vector3 rotationAngles;
        // [Space(10)]
        // [Header("Gem Event Settings")] 

    }
}
