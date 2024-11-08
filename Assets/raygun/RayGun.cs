using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    public OVRInput.RawButton shootingButton;
    public LineRenderer linePrefab;
    public Transform shootingPoint;
    public float maxLineDistance = 5;
    public float lineShowTimer = 0.3f;
    public AudioSource source;
    public AudioClip shootingAudioClip;
    public GameObject rayImpactPrefab;
    public LayerMask layerMask;
    private int totalMonsters = 5;
    public GameObject key;
    public Player playerScript;
    public CodePanel codePanel;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(shootingButton)) {
            Shoot();
        }
        
    }

    public void Shoot() {
        source.PlayOneShot(shootingAudioClip);

        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDistance, layerMask);

        Vector3 endpoint = Vector3.zero;

        if (hasHit) {
            endpoint = hit.point;
            UnderwaterCreature monster = hit.transform.GetComponentInParent<UnderwaterCreature>();
            CodePanel panel = hit.transform.GetComponentInParent<codePanel>();
            
            if (monster) {
                hit.collider.enabled = false;
                monster.Kill();
                totalMonsters -= 1;
                if (totalMonsters == 0) {
                    Vector3 keyPos = Vector3.zero;
                    keyPos.z = 3;
                    Instantiate(key, keyPos, transform.rotation);

                    playerScript.AddToBackpack("monsterKey");
                }
            } else if (panel){
                codePanel.HandleSquareHit(hit.transform.gameObject);
            } 
            else {
                GameObject rayImpact = Instantiate(rayImpactPrefab, hit.point, Quaternion.LookRotation(-hit.normal));
                Destroy(rayImpact, 1);
            }

        } else {
            endpoint = shootingPoint.position + shootingPoint.forward * maxLineDistance;
        }

        LineRenderer line = Instantiate(linePrefab);
        line.positionCount = 2;
        line.SetPosition(0, shootingPoint.position);
        line.SetPosition(1, endpoint);

        Destroy(line.gameObject, lineShowTimer);
    }
}
