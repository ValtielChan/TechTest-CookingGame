using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(HealthStatus))]
[RequireComponent(typeof(AudioSource))]
public class Knife : MonoBehaviour
{
    /// <summary>
    /// The sound played when you cut stuff
    /// </summary>
    [SerializeField]
    private AudioClip chopSound;

    /// <summary>
    /// The damages inflicted by the knife
    /// </summary>
    [SerializeField]
    private int damage = 10;

    /// <summary>
    /// The damages inflicted to itself
    /// </summary>
    [SerializeField]
    private int durabilityDamage = 2;

    /// <summary>
    /// The controller velocity threshold to take the cut in account
    /// </summary>
    [SerializeField]
    private float cutVelocityThreshold = 1.5f;

    /// <summary>
    /// Haptic vibration amplitude
    /// </summary>
    private const float vibrationAmplitude = 1.0f;

    /// <summary>
    /// Haptic vibration time
    /// </summary>
    private const float vibrationTime = 0.15f;

    /// <summary>
    /// The knife alignement tolerence to take the cut in account
    /// </summary>
    private const float alignementTolerence = 0.5f;

    /// <summary>
    /// Attached Audio Source
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Attached Grab Interactable
    /// </summary>
    private XRGrabInteractable grabInteractable;

    /// <summary>
    /// The Controller Info attached to the Interactor
    /// </summary>
    private ControllerInfo controllerInfo;

    // Attached Health Status
    private HealthStatus healthStatus;

    /// <summary>
    /// Game Manager
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// The Game Object that display the tears effect
    /// </summary>
    private TearsEffect tearsEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Get every needed components
        grabInteractable = GetComponent<XRGrabInteractable>();
        healthStatus = GetComponent<HealthStatus>();
        audioSource = GetComponent<AudioSource>();

        gameManager = FindObjectOfType<GameManager>();
        tearsEffect = FindObjectOfType<TearsEffect>();
    }

    private void OnTriggerEnter(Collider col)
    {
        // Only detect the enemy tagged GO
        if (col.gameObject.tag.Equals("Enemy"))
        {
            // Check if the movement is vigorous enough
            if (controllerInfo && Mathf.Abs(controllerInfo.Velocity.y) > cutVelocityThreshold)
            {
                // Check if the player try to cut with the right knife orientation (here the edge of the knife is oriented tranform.forward)
                float verticalAlignment = Vector3.Dot(transform.forward, -Vector3.up);

                // With Dot product the more the value is close to 1.0f the more the 2 vectors are aligned. Here is a tolerence of 0.5 (~45°)
                if (verticalAlignment > alignementTolerence)
                {
                    // Damage enemy
                    col.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);

                    // Sound and haptic feedback
                    controllerInfo.GetComponent<XRBaseController>().SendHapticImpulse(vibrationAmplitude, vibrationTime);

                    audioSource.PlayOneShot(chopSound);

                    // Activate the cry effect
                    if (tearsEffect)
                    {
                        tearsEffect.CryMore();
                    }

                    // Auto damage the knife so it breaks eventually
                    healthStatus.Damage(durabilityDamage);
                }
            }
        }
    }

    public void OnGrabbed()
    {
        // Get the current controller informations when grabbed
        controllerInfo = grabInteractable.selectingInteractor.GetComponent<ControllerInfo>();

        // Try to start the game when a knife is grabbed
        // The gameManager will do nothing if the game already started
        if (gameManager)
        {
            gameManager.StartGame();
        }
    }
}
