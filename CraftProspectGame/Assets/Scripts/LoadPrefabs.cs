using UnityEngine;
using System.IO;
using System;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif

/*
 * Load the features
 */
public class LoadPrefabs : MonoBehaviour {

    public static int clampXBefore;
    public static int clampXAfter;
    public static int clampYval1 = -22;
    public static int clampYval2 = -68;
    public static GameObject prefab;

    public static void PrefabLoad() {
        /* 
         * Loads feature prefabs by accesing .txt file and spawning 
         * respective objects in the scene at load time. Aim is to make this file scalable
         * with different levels and stages.
        */
        clampXAfter = 95;
        Debug.Log("Load Prefab");
        LoadWildfire();
    }

    public static void LoadWildfire() {
        for (int i = 0; i < 1; i++) {
            prefab = (UnityEngine.GameObject)Resources.Load("WildfireRes-1");
            Vector3 position = new Vector3(130, -45, 0);
            Instantiate(prefab, position, Quaternion.identity);
            GameObject InstantiatedPrefab = Instantiate(prefab) as GameObject;
            // UnityEditor.Selection.activeObject = InstantiatedPrefab;
            Debug.Log("Object spawned");
        }
    }
}
