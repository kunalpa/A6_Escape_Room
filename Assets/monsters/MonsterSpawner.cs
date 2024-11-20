using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    private int totalMonstersRemaining = 5;
    public Player playerScript;
    public float spawnRadius = 4.0f;
    public GameObject door;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totalMonstersRemaining; i++) {
            Vector3 pos = Random.insideUnitSphere * spawnRadius;
            pos = transform.TransformPoint(pos);
            Instantiate(monster, pos, Quaternion.identity, transform);
        }
    }

    public void KillMonsters() {
        Destroy(door);
        StartCoroutine(playerScript.generateKey("monsterKey"));
    }
}