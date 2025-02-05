using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class RightHandCubeScaler : MonoBehaviour
{
    XRIDefaultInputActions inputActions;
    HapticImpulsePlayer hapticImpulsePlayer;

    [SerializeField] private float h_intensity = 0.2f;
    [SerializeField] private float h_duration = 0.1f;

    [SerializeField] private GameObject cube;

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void Awake()
    {
        inputActions = new XRIDefaultInputActions();
        hapticImpulsePlayer = GetComponent<HapticImpulsePlayer>();
    }

    private void Update()
    {
        float inputValue = inputActions.XRIRightInteraction.ActivateValue.ReadValue<float>();

        if (inputValue > 0.0f)
        {
            hapticImpulsePlayer.SendHapticImpulse(h_intensity, h_duration);
        }

        cube.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f) * inputValue;
    }
}
