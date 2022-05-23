using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    /// <summary>
    /// Reference to player Health status
    /// </summary>
    [SerializeField]
    private HealthStatus playerHealthStatus;

    /// <summary>
    /// Effect's quad renderer
    /// </summary>
    [SerializeField]
    private Renderer renderer;

    /// <summary>
    /// Displayed damage color
    /// </summary>
    [SerializeField]
    private Color damageColor = Color.red;

    /// <summary>
    /// Color fade speed
    /// </summary>
    [SerializeField]
    private float fadeSpeed = 1.0f;

    /// <summary>
    /// Max effect's color alpha
    /// </summary>
    private float maxAlpha;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthStatus.OnDamage += DisplayEffect;
        maxAlpha = damageColor.a;

        damageColor.a = 0.0f;
        UpdateColor();
    }

    /// <summary>
    /// Set max transparency when damages are recieved
    /// </summary>
    private void DisplayEffect()
    {
        damageColor.a = maxAlpha;
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColor();
    }

    /// <summary>
    /// UUpdate quad material color
    /// </summary>
    void UpdateColor()
    {
        damageColor.a -= Time.deltaTime * fadeSpeed;
        damageColor.a = Mathf.Clamp01(damageColor.a);
        renderer.sharedMaterial.SetColor("_BaseColor", damageColor);
    }
}
