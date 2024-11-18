using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public int totalMonstersRemaining;
    public Player playerScript;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            var pos = new Vector3(Random.Range(0.0f, 2.0f), Random.Range(0.0f, 2.0f), Random.Range(0.0f, 2.0f));
            Instantiate(monster, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillMonster() {
        totalMonstersRemaining -= 1;
        if (totalMonstersRemaining == 0) {
            StartCoroutine(playerScript.generateKey("monsterKey"));
        }
    }
}
