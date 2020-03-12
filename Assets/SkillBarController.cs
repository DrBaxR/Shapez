using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarController : MonoBehaviour
{
    /* public Image imageCooldown;
     public float coolDown = 5;
     public Text coolDownText;
     bool isCooldown;
     float amount;
     // Start is called before the first frame update
     void Start()
     {
         coolDownText.enabled=false;
     }

     // Update is called once per frame
     void Update()
     {
         if(Input.GetKeyDown(KeyCode.Space))
         {
             isCooldown = true;
             coolDownText.enabled = true;
             amount = coolDown;
         }

         if(isCooldown)
         {
             coolDownText.text = ((int)amount).ToString();
             amount -= Time.deltaTime;

             imageCooldown.fillAmount += 1 / coolDown * Time.deltaTime;
             if(imageCooldown.fillAmount>=1)
             {
                 imageCooldown.fillAmount = 0;
                 isCooldown = false;
             }
         }
     }*/

    public List<ActiveSkills> skills;

    private void FixedUpdate()
    {
        if(skills[0].currentCoolDown>=skills[0].coolDown)
        {
            skills[0].isReady = true;
            skills[0].currentCoolDown = 0;
        }

    }

    private void Update()
    {
        foreach(ActiveSkills s in skills)
        {
            if(s.currentCoolDown<s.coolDown)
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.coolDown;
            }
        }
    }
}
