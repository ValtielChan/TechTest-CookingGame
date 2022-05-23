using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    /// <summary>
    /// List of every tutorial steps
    /// </summary>
    [SerializeField]
    private List<TutorialStep> steps;

    /// <summary>
    /// The current step index
    /// </summary>
    private int currentStep = 0;

    /// <summary>
    /// Event fired when the tutorial ends
    /// </summary>
    public event UnityAction OnTutorialEnd;

    // Start is called before the first frame update
    void Start()
    {
        foreach(TutorialStep ts in steps)
        {
            ts.OnValidate += NextStep;
        }
    }

    /// <summary>
    /// Start the tutorial sequence
    /// </summary>
    public void StartTutorial()
    {
        if (steps.Count > 0)
        {
            currentStep = 0;
            steps[0].gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Pass to the next step of the tutorial
    /// </summary>
    private void NextStep()
    {
        if (steps.Count > 0)
        {
            steps[currentStep].gameObject.SetActive(false);

            currentStep++;

            if (currentStep < steps.Count)
            {
                steps[currentStep].gameObject.SetActive(true);
            }
            else
            {
                OnTutorialEnd?.Invoke();
            }
        }
        else
        {
            OnTutorialEnd?.Invoke();
        }
    }
}
