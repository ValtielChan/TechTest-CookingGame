using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthStatus))]
public abstract class Enemy : MonoBehaviour
{
    /// <summary>
    /// Enemy walk speed
    /// </summary>
    [SerializeField]
    protected float walkSpeed = 1.0f;

    /// <summary>
    /// Damage inflited to the player
    /// </summary>
    [SerializeField]
    protected int damage = 10;

    /// <summary>
    /// Attached Health Status
    /// </summary>
    protected HealthStatus healthStatus;

    protected void Start()
    {
        healthStatus = GetComponent<HealthStatus>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Damage Zone")) {

            // Damage player
            col.gameObject.SendMessageUpwards("Damage", damage);

            healthStatus.Die(); // Suicide
        }
    }
}
