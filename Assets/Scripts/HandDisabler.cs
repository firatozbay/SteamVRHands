using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

//Makes the Hand Models Disappear for interactable objects containing this component
[RequireComponent(typeof(Interactable))]
public class HandDisabler : MonoBehaviour {
    
    private void OnDetachedFromHand(Hand hand)
    {
        hand.GetComponent<FloatAnimator>().Animator.gameObject.SetActive(true);
        hand.otherHand.GetComponent<FloatAnimator>().Animator.gameObject.SetActive(true);
    }

    private void OnAttachedToHand(Hand hand)
    {
        hand.GetComponent<FloatAnimator>().Animator.gameObject.SetActive(false);
        hand.otherHand.GetComponent<FloatAnimator>().Animator.gameObject.SetActive(false);
    }
}
