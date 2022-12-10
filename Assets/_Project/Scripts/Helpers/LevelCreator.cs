using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Helpers
{
    public class LevelCreator : MonoBehaviour
    {
        
        [BoxGroup("Platform")] [SerializeField] private Transform platformParent;
        [BoxGroup("Platform")] [SerializeField] private GameObject spawnablePlatform;
        [BoxGroup("Platform")] [SerializeField] private BoxCollider spawnablePlatformTemplate;
        [BoxGroup("Platform")] [SerializeField] private GameObject finishLine;
        [BoxGroup("Platform")] [SerializeField] private int platformAmount;
        
        [BoxGroup("Collectable")] [SerializeField] private Transform collectableParent;
        [BoxGroup("Collectable")] [SerializeField] private GameObject[] collectablePrefabs;
        [BoxGroup("Collectable")] [SerializeField] private int collectableSpawnAmount;
        [BoxGroup("Collectable")] [SerializeField] private float[] collectableXOffsets;
        [BoxGroup("Collectable")] [SerializeField] private float collectableZOffset;
        
        
        

        [HorizontalGroup("Create Buttons")]
        [Button("Create Platforms")]
        public void CreatePlatforms()
        {
#if UNITY_EDITOR
            for (int i = 0; i < platformAmount; i++)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, i * spawnablePlatformTemplate.size.z) + transform.position;
                GameObject spawned = PrefabUtility.InstantiatePrefab(spawnablePlatform) as GameObject; // We need to use IF Editor check since this is a editor method..

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
        

        [HorizontalGroup("Create Buttons")]
        [Button("Create Collectables")]
        public void CreateCollectables()
        {
#if UNITY_EDITOR
            for (int i = 0; i < collectableSpawnAmount; i++)
            {
                GameObject randomCollectable = collectablePrefabs[Random.Range(0, collectablePrefabs.Length)];
                Vector3 pos = new Vector3(collectableXOffsets[Random.Range(0, collectableXOffsets.Length)], transform.position.y, i * collectableZOffset) + new Vector3(transform.position.x, transform.position.y, transform.position.z + collectableZOffset); // We need to use IF Editor check since this is a editor method..
                GameObject spawned = PrefabUtility.InstantiatePrefab(randomCollectable) as GameObject;
                
                if (spawned == null) return;
                spawned.transform.position = pos;
                spawned.transform.SetParent(collectableParent);
            }
#endif
        }


    }
}