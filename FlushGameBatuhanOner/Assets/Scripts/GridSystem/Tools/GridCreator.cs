using GemSystem.Manager;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
#endif

namespace GridSystem.Tools
{
    public class GridCreator : MonoBehaviour
    {
        public int rowCount = 3;
        public int columnCount = 4; 
        public float distanceBetweenTops = 2.0f;
        public GameObject gridFrameObject;

#if UNITY_EDITOR
        [CustomEditor(typeof(GridCreator))]
        public class GridEditor : Editor
        {
            
            public override void OnInspectorGUI()
            {
                
                DrawDefaultInspector();
                GridCreator gridCreatorScript = (GridCreator)target;
                GUILayout.Space(10);
                EditorGUILayout.HelpBox(
                    "Girilen değerler ile Grid oluşturabilirsiniz.  ",MessageType.Info);
                GUILayout.Space(10);
                
                if (GUILayout.Button("Add"))
                {
                    
                    gridCreatorScript.AddObjects();
                }
            }
        }
#endif

        private void AddObjects()
        {
            float totalWidth = (columnCount - 1) * distanceBetweenTops; 
            float totalHeight = (rowCount - 1) * distanceBetweenTops; 
            Vector3 startPosition = transform.position - new Vector3(totalWidth / 2, 0.0f, totalHeight / 2); 
            
            GameObject gridObject = new GameObject("Grid");
            gridObject.transform.position = transform.position;

           
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    int randomValue = Random.Range(0, GemController.Instance.gemDataList.Count);
                    Vector3 spawnPosition = startPosition + new Vector3(column * distanceBetweenTops, 0.0f, row * distanceBetweenTops); // Oluşturma pozisyonu
                    GameObject newGemObject = Instantiate(GemController.Instance.gemDataList[randomValue].gemObject, spawnPosition, Quaternion.identity);
                    newGemObject.transform.parent = gridObject.transform;
                }
            }

            GameObject cloneFrameObject = Instantiate(gridFrameObject, gridObject.transform);
            var position = transform.position;
            cloneFrameObject.transform.position = new Vector3(position.x,position.y/2,position.z);
            cloneFrameObject.transform.localScale = new Vector3(columnCount * distanceBetweenTops / 10, cloneFrameObject.transform.localScale.y, rowCount * distanceBetweenTops / 10);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (EditorApplication.isPlaying) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position,new Vector3(3.5f,0,3.5f));
        }
#endif
    }
}
