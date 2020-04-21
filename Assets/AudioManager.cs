using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> laserClip;
    public List<AudioClip> deathSound;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string clip)
    {
        switch(clip) {
            case "laserSound":
                audioSource.PlayOneShot(laserClip[Random.RandomRange(0, laserClip.Count)]);
                break;
            case "deathSound":
                audioSource.PlayOneShot(deathSound[Random.RandomRange(0, deathSound.Count)]);
                break;
        }
    }
}
