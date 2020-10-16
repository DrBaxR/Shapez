using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int level;
    public static float currentExperience;
    public float experienceRequired;
    public float[] requiredExperiencePerLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("PlayerLevel", 0);
        if (PlayerPrefs.GetInt("PlayerLevel") != 0)
        {
            level = PlayerPrefs.GetInt("PlayerLevel");
        }
        else level = 1;
        UpdateRequiredExperience();
        currentExperience = PlayerPrefs.GetFloat("CurrentExperience");
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentExperience);   
       // RankUp();
    }

    public void RankUp()
    {
        if(currentExperience>=experienceRequired)
        {

            level++;
            Debug.Log("Level " + level);
            PlayerPrefs.SetInt("PlayerLevel", level);
            UpdateRequiredExperience();

           // currentExperience = 0;
            
        }
    }

    public void UpdateRequiredExperience()
    {
        for (int i = 1; i <= level; i++)
        {
            if (i != 1)
            {
                requiredExperiencePerLevel[i] = (int)(requiredExperiencePerLevel[i - 1] + requiredExperiencePerLevel[i - 1] * 10 / 100);
            }
            else requiredExperiencePerLevel[i] = 100f;

        }
        experienceRequired = requiredExperiencePerLevel[level];
        PlayerPrefs.SetFloat("RequiredExperience", requiredExperiencePerLevel[level]);
        level = PlayerPrefs.GetInt("PlayerLevel");
    }

    public static void UpdateExperience(float experiencePoints)
    {
        currentExperience += experiencePoints;
        PlayerPrefs.SetFloat("CurrentExperience", currentExperience);
    }
}
