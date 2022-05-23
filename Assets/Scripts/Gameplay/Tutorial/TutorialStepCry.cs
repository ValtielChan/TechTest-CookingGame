using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TutorialStepCry : TutorialStep
{
    /// <summary>
    /// Reference to Tears particle system
    /// </summary>
    [SerializeField]
    private ParticleSystem tearsParticleSystem;

    /// <summary>
    /// Tears particle system emission module
    /// </summary>
    private EmissionModule emission;

    // Start is called before the first frame update
    void Start()
    {
        emission = tearsParticleSystem.emission;
        emission.rateOverTime = 3.0f;
    }

    /// <inheritdoc/>
    protected override bool CheckValidation()
    {
        // Return the value of particle system when the tears effect has been stoped
        validated = emission.rateOverTime.constant == 0.0f;
        return validated;
    }
}
