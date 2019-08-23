// Animator whose frame is set based on the Hand Controller Trigger Value
using UnityEngine;
using Valve.VR.InteractionSystem;

public class FloatAnimator : MonoBehaviour
{
    private Hand _hand;
    private float _floatMappingValue;
    public Animator Animator;

    private float _currentFloatMapping = float.NaN;
    private int _framesUnchanged = 0;

    private void Start()
    {
        _hand = GetComponent<Hand>();
        if (Animator == null)
        {
            Animator = GetComponent<Animator>();
        }

        Animator.speed = 0.0f;
            
    }

    private void Update()
    {
        if (_hand != null && _hand.controller != null)
        {
            _floatMappingValue = _hand.controller.TriggerValue;
            if (_currentFloatMapping != _floatMappingValue)
            {
                _currentFloatMapping = _floatMappingValue;
                Animator.enabled = true;
                Animator.Play(0, 0, _currentFloatMapping);
                _framesUnchanged = 0;
            }
            else
            {
                _framesUnchanged++;
                if (_framesUnchanged > 20)
                {
                    Animator.enabled = false;
                }
            }
        }
    }
}
