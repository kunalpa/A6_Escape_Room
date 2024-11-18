using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    public bool isTriggered = false;
    public Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} triggered this object!");
    }
}
