using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStepDestroyedObject : TutorialStep
{
    /// <summary>
    /// The list of object to check
    /// </summary>
    [SerializeField]
    private List<GameObject> objectsToCkeck;

    /// <inheritdoc/>
    protected override bool CheckValidation()
    {
        bool allObjectsDestroyed = true;

        // return true if all the objects has been destroyed
        foreach(GameObject go in objectsToCkeck)
        {
            if (go != null)
            {
                allObjectsDestroyed = false;
                break;
            }
        }

        validated = allObjectsDestroyed;
        return validated;
    }
}
