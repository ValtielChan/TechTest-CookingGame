using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialStep_KnifeBreak : TutorialStep
{
    /// <summary>
    /// Reference to the right interactor
    /// </summary>
    [SerializeField]
    private XRBaseInteractor rightInteractor;

    /// <summary>
    /// Reference to the left interactor
    /// </summary>
    [SerializeField]
    private XRBaseInteractor leftInteractor;

    // Start is called before the first frame update
    void Start()
    {
        // Break knife if there's one hold so the player has to grab a new one
        if (rightInteractor.selectTarget != null)
        {
            rightInteractor.selectTarget.gameObject.SendMessage("Damage", 50);
        }
        if (leftInteractor.selectTarget != null)
        {
            leftInteractor.selectTarget.gameObject.SendMessage("Damage", 50);
        }
    }

    /// <inheritdoc/>
    protected override bool CheckValidation()
    {
        // Return true if a new knife has been grabbed
        validated = (rightInteractor.selectTarget != null) || (leftInteractor.selectTarget != null);

        return validated;
    }

}
