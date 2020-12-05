using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    [Header("General-Speed")]
    [Tooltip("In ms^ -1")][SerializeField] float Controlspeed = 9f;
    [Tooltip("In ms^ -1")] [SerializeField] float xRange =5.5f;
    [Tooltip("In ms^-1")] [SerializeField] float yRange =3.6f;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor =-5f; //For Nose Up/Down 
    [SerializeField] float positionYawFactor = 7f;// For Yaw


    [Header("Control-Throw Based")]
    [SerializeField] float controlPitchFactor = -30f;// For Sensitivity of Nose
    [SerializeField] float controlRollFactor = -15f;//For Roll


    [SerializeField] GameObject[] guns;
   

    float xThrow;
    float yThrow;
    bool isControlEnabled = true;

    

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled == true)
        {
            processTranslation();
            processRotation();
            processFiring();
        }

    }

     public void OnplayerDeath()
    {
        isControlEnabled = false;
    }

    private void processRotation()
    {
        
        float pitchDueToControl =yThrow * controlPitchFactor;
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitch = pitchDueToControl + pitchDueToPosition;
        
        
        float yaw = transform.localPosition.x * positionYawFactor;


        float roll = xThrow * controlRollFactor;


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    
  

    private void processTranslation()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xoffset = xThrow * Controlspeed * Time.deltaTime;
        float NewXPos = transform.localPosition.x + xoffset;
        float clampedXPos = Mathf.Clamp(NewXPos, -xRange, xRange);
        //for Y Axis

         yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yoffset = yThrow * Controlspeed * Time.deltaTime;
        float NewYPos = transform.localPosition.y + yoffset;
        float clampedYPos = Mathf.Clamp(NewYPos, -yRange, yRange);



        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    private void processFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            setGunsactive(true);
        }
        else
        {
            setGunsactive(false);
        }

      
    }

    private void setGunsactive(bool isactive)
    {
        foreach(GameObject gun in guns)
        {
            var emmissionModule = gun.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isactive;
            
        }
    }

    
   
}
