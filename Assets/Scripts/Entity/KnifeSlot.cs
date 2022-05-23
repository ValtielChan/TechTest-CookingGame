using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KnifeSlot : MonoBehaviour
{
    /// <summary>
    /// The knife prefab to spawn in the slot
    /// </summary>
    [SerializeField]
    private GameObject knifePrefab;

    /// <summary>
    /// The current knife instance in the slot
    /// </summary>
    private XRGrabInteractable currentKnife;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewKnife();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentKnife.isSelected)
        {
            SpawnNewKnife();
        }
    }

    /// <summary>
    /// Make a new knife appears in the slot
    /// </summary>
    public void SpawnNewKnife()
    {
        currentKnife = Instantiate(knifePrefab, transform.position, transform.rotation).GetComponent<XRGrabInteractable>();

        //currentKnife.transform.localPosition = Vector3.zero;
        //currentKnife.transform.localRotation = Quaternion.identity;


    }
}
