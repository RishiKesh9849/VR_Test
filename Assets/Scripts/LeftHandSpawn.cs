using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class LeftHandSpawn : MonoBehaviour
{
    XRIDefaultInputActions inputActions;
    HapticImpulsePlayer hapticImpulsePlayer;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float forceAmount = 100f;
    [SerializeField] private float h_intensity = 1f;
    [SerializeField] private float h_duration = 1f;

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void Awake()    
    {
        inputActions = new XRIDefaultInputActions();
        hapticImpulsePlayer = GetComponent<HapticImpulsePlayer>();
    }

    void Start()
    {
        inputActions.XRILeftInteraction.Activate.performed += Activate_performed;
    }

    private void Activate_performed(InputAction.CallbackContext obj)
    {
        hapticImpulsePlayer.SendHapticImpulse(h_intensity, h_duration);
        var cubeObj = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        cubeObj.GetComponent<Rigidbody>().velocity = transform.forward * forceAmount;
        cubeObj.GetComponent<Rigidbody>().AddTorque(Vector3.up * 100.0f, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

}
