using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Helpers
{
    public class PlatformCreator : MonoBehaviour
    {
        [SerializeField] private Transform platformParent;
        [SerializeField] private GameObject spawnablePlatform;
        [SerializeField] private BoxCollider spawnablePlatformTemplate;
        [SerializeField] private GameObject finishLine;


        [Title("Properties")] [SerializeField] private int platformAmount;

        private Vector3 _initialOffset;

        [Button("Create Platforms")]
        public void CreatePlatforms()
        {
#if UNITY_EDITOR
            
            for (int i = 0; i < platformAmount; i++)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, i * spawnablePlatformTemplate.size.z) + transform.position;
                GameObject spawned = PrefabUtility.InstantiatePrefab(spawnablePlatform) as GameObject;

                if (spawned == null) return;
                spawned.transform.position = pos;
                spawned.transform.SetParent(platformParent);
                spawned.name += $": {i}";
            }
            
            Vector3 lastPos = new Vector3(transform.position.x, transform.position.y, platformAmount * spawnablePlatformTemplate.size.z) + transform.position;
            GameObject spawnedFinishLine = PrefabUtility.InstantiatePrefab(finishLine) as GameObject;
            if (spawnedFinishLine == null) return;
            spawnedFinishLine.transform.position = lastPos;
            spawnedFinishLine.transform.SetParent(platformParent);

#endif
        }
    }
}