using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public List<ActiveSkills> skills;
    public Image explosionIcon;
    public Image invulnerabilityIcon;
    public Text explosionCooldownText;
    private float timer;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skills[0].currentCoolDown >= skills[0].coolDown)
            {
                skills[0].isReady = true;
                //timer = skills[0].coolDown;
                
                
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(skills[1].currentCoolDown >= skills[1].coolDown)
            {
                skills[1].isReady = true;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (skills[2].currentCoolDown >= skills[2].coolDown)
            {
                skills[2].isReady = true;

            }
        }
       /* if(!skills[0].isReady)
        {
            skills[0].currentCoolDown = 0;
        }*/
    }

    void Update()
    {
        /*(foreach(ActiveSkills s in skills)
        {
            if(s.currentCoolDown<s.coolDown)
            {
                s.isReady = false;
                s.currentCoolDown += Time.deltaTime;
                timer -= Time.deltaTime;
                //s.skillIcon.fillAmount = s.currentCoolDown / s.coolDown;
                explosionIcon.fillAmount = s.currentCoolDown / s.coolDown;
                explosionCooldownText.text = ((int)timer % 60).ToString();
           }*/
        if (skills[0].currentCoolDown < skills[0].coolDown)
        {
            skills[0].isReady = false;
            skills[0].currentCoolDown += Time.deltaTime;
            explosionIcon.fillAmount = skills[0].currentCoolDown / skills[0].coolDown;
            // explosionCooldownText.text = ((int)timer % 60).ToString();
        }
        if (skills[1].currentCoolDown < skills[1].coolDown && player.isDamageable)
        {
            skills[1].isReady = false;
            skills[1].currentCoolDown += Time.deltaTime;
            invulnerabilityIcon.fillAmount = skills[1].currentCoolDown / skills[1].coolDown;


        }
        else if (!player.isDamageable)
        {
            invulnerabilityIcon.fillAmount = 0;
        }
        if (skills[2].currentCoolDown < skills[2].coolDown)
        {
            skills[2].isReady = false;
            skills[2].currentCoolDown += Time.deltaTime;
        }
    }
}
