using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public InputActionProperty primaryButtonClick;
    public InputActionProperty secondaryButtonClick;
    public Animator handAnimator;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);

        float primaryValue = primaryButtonClick.action.ReadValue<float>();
        if (isRight)
        {
            if (primaryValue == 1) GameManager.Instance.RightPrimaryButton();
        }
        else
        {
            if (primaryValue == 1) GameManager.Instance.LeftPrimaryButton();
        }
        // (primaryValue == 1) handAnimator.SetBool("hasAmulet", true);
        //else handAnimator.SetBool("hasAmulet", false);

        float secondaryValue = secondaryButtonClick.action.ReadValue<float>();
        if (isRight)
        {
            if (secondaryValue == 1) GameManager.Instance.RightSecondaryButton();
        }
        else
        {
            if (secondaryValue == 1) GameManager.Instance.LeftSecondaryButton();
        }
        //if (isRight) GameManager.Instance.RightPrimaryButton();
        //else GameManager.Instance.LeftPrimaryButton();
        if (isRight)
        {
            if(GameManager.Instance != null)
            {
                handAnimator.SetBool("hasAmulet", GameManager.Instance.hasAmulet);
                handAnimator.SetBool("hasSword", GameManager.Instance.hasSword);
            }
            
        }
    }

}
