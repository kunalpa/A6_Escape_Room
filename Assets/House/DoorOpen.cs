using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorOpen : MonoBehaviour
{
    public ParticleSystem ps;
    private Door door;
    private AudioSource audio;
    
    // Start is called before the first frame update
    void Start()

    {
        AudioSource audio = GetComponent<AudioSource>();
        Door door = GetComponent<Door>();
    }
    public void Open(){
        StartCoroutine(DoorParticle());
    }
    IEnumerator DoorParticle(){
        ParticleSystem doorParticle = Instantiate(ps);
        audio.Play();
        yield return new WaitForSecondsRealtime(3);
        Destroy(doorParticle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
