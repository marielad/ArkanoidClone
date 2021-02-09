using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip deathSound;
    public AudioClip bounceSound;
    public AudioClip brickSound;
    public AudioClip winSound;
    public AudioClip buttonSound;
    public AudioClip highScoreSound;

    private AudioSource audioSource;

    void Awake()
    {
        AudioManager.instance = this;
        audioSource = GetComponent<AudioSource>();
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeathSound(){
        audioSource.PlayOneShot(deathSound);
    }

    public void PlayBounceSound()
    {
        audioSource.PlayOneShot(bounceSound);
    }
    public void PlayBrickSound()
    {
        audioSource.PlayOneShot(brickSound);
    }
    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }
    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
    public void PlayHighScoreSound()
    {
        audioSource.PlayOneShot(highScoreSound);
    }
}
