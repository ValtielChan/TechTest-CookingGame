using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(AudioSource))]
public class TearsEffect : MonoBehaviour
{
    /// <summary>
    /// Sound effect played when the tears are wiped
    /// </summary>
    [SerializeField]
    private AudioClip wipeSound;

    /// <summary>
    /// Attached particle system emission module
    /// </summary>
    private EmissionModule emission;

    /// <summary>
    /// Attached audio source
    /// </summary>
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        emission = GetComponent<ParticleSystem>().emission;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Stop effect when the hand is close enough from the eyes
        if (other.gameObject.tag.Equals("Hand"))
        {
            Wipe();
        }
    }

    /// <summary>
    /// Intensifie the tears effect
    /// </summary>
    /// <param name="amount">The factor to increase the effect by</param>
    public void CryMore(int amount = 1)
    {
        emission.rateOverTime = emission.rateOverTime.constant + 1.0f;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Stop the tear effect
    /// </summary>
    public void Wipe()
    {
        if (emission.rateOverTime.constant > 0.0f)
        {
            emission.rateOverTime = 0.0f;
            audioSource.Stop();
            audioSource.PlayOneShot(wipeSound);
        }
    }
}
