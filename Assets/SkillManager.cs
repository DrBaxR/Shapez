using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public List<ActiveSkills> skills;
    public Image explosionIcon;
    public Text explosionCooldownText;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skills[0].currentCoolDown >= skills[0].coolDown)
            {
                skills[0].isReady = true;
                timer = skills[0].coolDown;
                
                
            }
        }
       /* if(!skills[0].isReady)
        {
            skills[0].currentCoolDown = 0;
        }*/
    }

    void Update()
    {
        foreach(ActiveSkills s in skills)
        {
            if(s.currentCoolDown<s.coolDown)
            {
                s.isReady = false;
                s.currentCoolDown += Time.deltaTime;
                timer -= Time.deltaTime;
                //s.skillIcon.fillAmount = s.currentCoolDown / s.coolDown;
                explosionIcon.fillAmount = s.currentCoolDown / s.coolDown;
                explosionCooldownText.text = ((int)timer % 60).ToString();
;            }
        }
    }
}
