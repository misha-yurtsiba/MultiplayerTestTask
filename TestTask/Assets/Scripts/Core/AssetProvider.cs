using UnityEngine;

public class AssetProvider
{
    public T LoadAsset<T>(string path) where T : Component
    {
        T prefab = Resources.Load<T>(path); 
        
        if (prefab == null)
        {
            Debug.LogError($"Couldn't load asset {path}");
        }
        return prefab;
    }

    public T InstantiateAsset<T>(string path) where T : Component
    {
        T prefab = LoadAsset<T>(path);
        
        return Object.Instantiate(prefab);
    }
}