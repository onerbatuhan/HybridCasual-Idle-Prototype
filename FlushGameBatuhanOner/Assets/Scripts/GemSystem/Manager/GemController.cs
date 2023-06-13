using System.Collections.Generic;
using DesignPatterns;
using GemSystem.Tables;
using UnityEngine;

namespace GemSystem.Manager
{
    public class GemController : Singleton<GemController>
    {
        public List<GemData> gemDataList;
        public List<GameObject> gemObjectList;


        protected override void Awake()
        {
            gemDataList.RemoveAll(item => item == null);
        }
    }
}
