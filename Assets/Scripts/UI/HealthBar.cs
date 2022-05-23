using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    /// <summary>
    /// Reference to health status
    /// </summary>
    [SerializeField]
    private HealthStatus healthStatus;

    /// <summary>
    /// Attached health bar sprite
    /// </summary>
    [SerializeField]
    private Image healthBar;

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)healthStatus.Health / (float)healthStatus.MaxHealth;
    }
}
