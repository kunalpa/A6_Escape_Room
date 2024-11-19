using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeSwitch : MonoBehaviour
{
    public float extendSpeed = 0.1f;  // Speed of extension/collapse
    public GameObject blade;
    public AudioClip SwitchOn, SwitchOff;
    public bool weaponActive; // State of the lightsaber (on/off)
    private float scaleMin = 0f;      // Minimum scale (collapsed)
    private float scaleMax;           // Maximum scale (fully extended)
    private float extendDelta;        // Interpolation value for scaling
    private float scaleCurrent;       // Current scale of the lightsaber blade
    private float localScaleX;        // Initial x scale
    private float localScaleZ;        // Initial z scale
    private AudioSource audioSource;

    void Awake()
    {
        // Save initial x and z scale values
        localScaleX = transform.localScale.x;
        localScaleZ = transform.localScale.z;

        // Set maximum scale to the current y scale
        scaleMax = transform.localScale.y;

        // Set the current scale to maximum since we assume the lightsaber starts extended
        scaleCurrent = scaleMax;

        // Calculate the interpolation value
        extendDelta = scaleMax / extendSpeed;

        // Set initial state of the lightsaber to on
        weaponActive = true;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for input to toggle lightsaber on/off
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Invert extendDelta based on the current state
            extendDelta = weaponActive ? -Mathf.Abs(extendDelta) : Mathf.Abs(extendDelta);
            weaponActive = !weaponActive;  // Toggle weapon state
            if (weaponActive)
            {
                audioSource.PlayOneShot(SwitchOn);
            }
            else
            {
                audioSource.PlayOneShot(SwitchOff);
            }
        }

        // Adjust the current scale based on extendDelta and time
        scaleCurrent += extendDelta * Time.deltaTime;

        // Clamp the scale to be within the min and max range
        scaleCurrent = Mathf.Clamp(scaleCurrent, scaleMin, scaleMax);

        // Apply the current scale to the transform's local y-axis
        transform.localScale = new Vector3(localScaleX, scaleCurrent, localScaleZ);

        // Update the weapon state based on whether the current scale is greater than 0
        weaponActive = scaleCurrent > 0;
        if (weaponActive)
        {
            blade.SetActive(true);
        }
        else
        {
            blade.SetActive(false);
        }
    }
}
