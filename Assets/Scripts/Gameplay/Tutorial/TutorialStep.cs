using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialStep : MonoBehaviour
{
    /// <summary>
    /// Has the step been already validated
    /// </summary>
    protected bool validated;

    /// <summary>
    /// Event fired when the step is validated
    /// </summary>
    public event UnityAction OnValidate;

    // Update is called once per frame
    void Update()
    {
        if (!validated && CheckValidation())
        {
            OnValidate?.Invoke();
        }
    }

    /// <summary>
    /// Check if the validation statement of the step is fullfiled
    /// </summary>
    /// <returns>Validation statement</returns>
    protected abstract bool CheckValidation();
}
