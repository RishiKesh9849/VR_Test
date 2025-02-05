using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class RightHandSpawn : MonoBehaviour
{
    XRIDefaultInputActions inputActions;
    HapticImpulsePlayer hapticImpulsePlayer;
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private float forceAmount = 100f;
    [SerializeField] private float h_intensity = 1f;
    [SerializeField] private float h_duration = 1f;

    private void Awake()
    {
        inputActions = new XRIDefaultInputActions();
        hapticImpulsePlayer = GetComponent<HapticImpulsePlayer>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    void Start()
    {
        inputActions.XRIRightInteraction.Activate.performed += Activate_performed;
    }

    private void Activate_performed(InputAction.CallbackContext obj)
    {
        hapticImpulsePlayer.SendHapticImpulse(h_intensity, h_duration);
        var sphereObj = Instantiate(spherePrefab, transform.position, Quaternion.identity);
        sphereObj.GetComponent<Rigidbody>().velocity = transform.forward * forceAmount;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
