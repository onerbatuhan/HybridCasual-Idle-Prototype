using System.Linq;
using GemSystem.Manager;
using GemSystem.Tables;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
#endif

namespace GemSystem.Tools
{
    public class GemCreator : MonoBehaviour
    {
        public string gemName;
        public float startingSalesPrice;
        public Sprite gemIcon;
        public GameObject gemObject;
        private string filePath = "Assets/Scripts/ScriptTableObjects/Gems";

#if UNITY_EDITOR
        [CustomEditor(typeof(GemCreator))]
        public class GemCreatorEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();
                GemCreator gemCreator = (GemCreator)target;
                GUILayout.Space(10);
                EditorGUILayout.HelpBox(
                    "Gem değerlerini kullanarak bir ScriptableObject oluşturur." +
                    "'Assets/Scripts/ScriptTableObjects/Gems' dosyasında oluşturduğunuz ScriptTableObject'i görebilirsiniz." +
                    "Aynı değerlere sahip birden fazla Table nesnesi türetemezsiniz.",MessageType.Info);
                GUILayout.Space(10);
                
                if (GUILayout.Button("Add"))
                {
                    gemCreator.Add();
                }
            }
        }
#endif

        private void Add()
        {
           
            foreach (GemData gemData in GemDataAccessController.Instance.gemDataList)
            {
                if (gemData.gemName != gemName) continue;
                Debug.LogError("Aynı isime sahip bir Gem Data var.");
                return;
            }

            
            // Scriptable Object create
            GemData newGemData = ScriptableObject.CreateInstance<GemData>();
            newGemData.gemName = gemName;
            newGemData.startingSalesPrice = startingSalesPrice;
            newGemData.gemIcon = gemIcon;
            newGemData.gemObject = gemObject;
            GemDataAccessController.Instance.gemDataList.Add(newGemData);

            // folder save
            string folderName = gemName + ".asset";
            string currentFilePath = filePath + "/" + folderName;
            AssetDatabase.CreateAsset(newGemData, currentFilePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("Gem başarıyla oluşturuldu. Dosya yolundan kontrol edebilirsin.: " + currentFilePath);
        }
    }
}