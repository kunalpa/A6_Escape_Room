using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public float follow_range;
    public float vision_range;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getDistance();
        if (distance < follow_range) {
            this.agent.SetDestination(this.target.transform.position);
        }
        
    }
    
    void getDistance()
    {
        if (target != null)
        {
            distance = (target.transform.position - this.agent.transform.position).magnitude;
        }
    }
}
