using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorOpen : MonoBehaviour
{
    public ParticleSystem ps;
    public AudioSource audioOriginal;
    public Transform door; // The door's Transform
    public Vector3 openPosition; // Target position or rotation when opened
    public Vector3 closedPosition; // Default position or rotation when closed
    public float openSpeed = 2.0f; // Speed of opening the door

    
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Open(){
        StartCoroutine(DoorParticle());
    }
    IEnumerator DoorParticle(){
        Debug.Log("Open Door");
        // AudioSource audio = Instantiate(audioOriginal);
        Quaternion rotation = Quaternion.Euler(0,0,0);
        ParticleSystem doorParticle = Instantiate(ps,door.localPosition,rotation);
        door.localPosition = Vector3.Lerp(door.localPosition,  openPosition, Time.deltaTime * openSpeed);
        doorParticle.Play();
        audioOriginal.Play();
        yield return new WaitForSecondsRealtime(7);
        doorParticle.Stop();
        doorParticle.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
