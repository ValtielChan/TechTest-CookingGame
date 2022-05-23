using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInfo : MonoBehaviour
{
    /// <summary>
    /// Velocity value of the controller
    /// </summary>
    [SerializeField]
    private InputActionProperty velocityProperty;

    /// <summary>
    /// Velocity property
    /// </summary>
    public Vector3 Velocity { get => velocityProperty.action.ReadValue<Vector3>(); }
}
