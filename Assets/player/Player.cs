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
        Debug.Log("Generating key");
        Vector3 keyPos = new Vector3(2.0f, 0, 1.2f);
        keyPos = transform.TransformPoint(keyPos);
        GameObject key = Instantiate(keyPrefab, keyPos, Quaternion.identity, transform);
        key.SetActive(true);
        key.GetComponent<MeshRenderer>().enabled = true;
        AddToBackpack(keyName);
        yield return new WaitForSeconds(1);
        // DestroyImmediate(keyPrefab, true);
    }
}