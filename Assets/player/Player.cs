using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HashSet<string> backpack = new HashSet<string>();
    public int totalCollectableItemsCount;
    public GameObject keyPrefab;

    public bool checkFullBackpack() {
        return backpack.Count == totalCollectableItemsCount;
    }

    public void AddToBackpack(string item) {
        backpack.Add(item);
    }

    public IEnumerator generateKey(string keyName) {
        Vector3 keyPos = new Vector3(0, 0, 0.5f);
        Instantiate(keyPrefab, keyPos, Quaternion.identity);
        AddToBackpack(keyName);
        yield return new WaitForSeconds(1);
        DestroyImmediate(keyPrefab, true);
    }
}
