using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterCreature : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Kill() {
        animator.SetTrigger("Death");
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}