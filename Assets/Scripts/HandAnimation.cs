using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public enum HandType
{
    Right,
    Left
};

public class HandAnimation : MonoBehaviour
{
    XRIDefaultInputActions inputActions;
    Animator anim;

    [SerializeField] private HandType handType;
    private void Awake()
    {
        inputActions = new XRIDefaultInputActions();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        if (handType == HandType.Left)
        {
            inputActions.XRILeftInteraction.ActivateValue.performed += ActivateValue_performed;
            inputActions.XRILeftInteraction.SelectValue.performed += SelectValue_performed;
        }
        else if (handType == HandType.Right)
        {
            inputActions.XRIRightInteraction.ActivateValue.performed += ActivateValue_performed;
            inputActions.XRIRightInteraction.SelectValue.performed += SelectValue_performed;
        }
    }


    private void SelectValue_performed(InputAction.CallbackContext obj)
    {
        anim.SetFloat("Grip", obj.ReadValue<float>());
    }

    private void ActivateValue_performed(InputAction.CallbackContext obj)
    {
        anim.SetFloat("Trigger", obj.ReadValue<float>());
    }

}
