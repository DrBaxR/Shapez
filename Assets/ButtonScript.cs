using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class ButtonScript : MonoBehaviour
{
    public Slider rechargeSlider;
    public Image sliderFill;

    public float rechargeEnd;
    public float rechargeTime = 5.0f;

    public Color startColor;
    public Color endColor;

    private Animator animator;
    private PressedButtonBehaviour pressedButtonBehaviour;
    private CooldownButtonBehaviour cooldownButtonBehaviour;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pressedButtonBehaviour = animator.GetBehaviour<PressedButtonBehaviour>();
        pressedButtonBehaviour.buttonScript = this;
        cooldownButtonBehaviour = animator.GetBehaviour<CooldownButtonBehaviour>();
        cooldownButtonBehaviour.buttonScript = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartRecharge()
    {
        rechargeEnd = Time.time + rechargeTime;
        rechargeSlider.value = 1.0f;
    }

    public void SetOverlay()
    {
        rechargeSlider.value = (rechargeEnd - Time.time) / rechargeTime;
        sliderFill.color = Color.Lerp(startColor, endColor, 1 - rechargeSlider.value);
    }

    public void EndRecharge()
    {
        rechargeSlider.value = 0.0f;
    }
}
