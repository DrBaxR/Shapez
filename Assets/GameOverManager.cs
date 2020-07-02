using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public Image experienceBar;
    public Image background;
    public Text experienceText;
    public Text gameOverText;
    public LevelSystem levelSystem;
    public int level;
    

    private bool putExperience;
    private float currentExperience;
    private float requiredExperience;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
        experienceBar.enabled = false;
        background.enabled = false;
        level = PlayerPrefs.GetInt("PlayerLevel");
        PlayerPrefs.SetFloat("CurrentExperience", 300);
        currentExperience = PlayerPrefs.GetFloat("CurrentExperience");
        requiredExperience = PlayerPrefs.GetFloat("RequiredExperience");
        experienceText.enabled = false;
        experienceText.text = currentExperience + "/" + requiredExperience;
        gameOverText.text = "Game Over";
      
        putExperience = false;
        
        // experienceBar.fillAmount = Mathf.Lerp(experienceBar.fillAmount, currentExperience / requiredExperience, 10f * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {

        // if(putExperience)
        StartCoroutine(GameOverText());
        // experienceBar.fillAmount = Mathf.Lerp(experienceBar.fillAmount, currentExperience / requiredExperience,10f * Time.deltaTime);

        // experienceBar.fillAmount = currentExperience / requiredExperience;


    }

    private IEnumerator GameOverText()
    {
        yield return new WaitForSeconds(1f);
        gameOverText.enabled = true;
        yield return new WaitForSeconds(2f);
        background.enabled = true;
        experienceBar.enabled = true;
        experienceText.enabled = true;
        //yield return new WaitForSeconds(0.5f);
        // Progress();
        do
        {
            experienceBar.fillAmount = Mathf.Lerp(experienceBar.fillAmount, currentExperience / requiredExperience, 0.2f * Time.deltaTime);
            //yield return new WaitForSeconds(1f);
          
            if (experienceBar.fillAmount == 1)
            {
                Debug.Log("Level up");
                level++;
                PlayerPrefs.SetInt("PlayerLevel", level);
                levelSystem.UpdateRequiredExperience();
                

                if (currentExperience >= requiredExperience)
                {
                    

                    experienceBar.fillAmount = 0;
                    currentExperience = currentExperience - requiredExperience;
                   //d  levelSystem.RankUp();
                    requiredExperience = PlayerPrefs.GetFloat("RequiredExperience");
                    experienceText.text = currentExperience + "/" + requiredExperience;


                }
            }
        } while (currentExperience <0);






    }

    private void Progress()
    {
        experienceBar.fillAmount = Mathf.Lerp(experienceBar.fillAmount, currentExperience / requiredExperience, 10f * Time.deltaTime);
        //yield return new WaitForSeconds(1f);
        if(experienceBar.fillAmount==1)
        {
            if(currentExperience>=requiredExperience)
            {
                experienceBar.fillAmount = 0;
            }
        }
    }

    private void IncrementProgress()
    {
       // targetProgress = experienceBar.fillAmount + 
    }
}
