using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelloaddelay = 2f;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] AudioClip deathAudio;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        Startdeathsequence();
        Invoke("ReloadScene", levelloaddelay);
    }
    private void Startdeathsequence()
    {
        print("Player Dying");
        deathFX.Play();
        audioSource.PlayOneShot(deathAudio);
        SendMessage("OnplayerDeath");
        
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}


