using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HashSet<string> backpack = new HashSet<string>();
    public int totalCollectableItemsCount;

    public bool checkFullBackpack() {
        return backpack.Count == totalCollectableItemsCount;
    }

    public void AddToBackpack(string item) {
        backpack.Add(item);
    }
}
