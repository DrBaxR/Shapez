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
    

    private bool putExperience;
    private float currentExperience;
    private float requiredExperience;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
        experienceBar.enabled = false;
        background.enabled = false;
        PlayerPrefs.SetFloat("CurrentExperience", 40);
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
        StartCoroutine(GameOverText());
      // if(putExperience)
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
        experienceBar.fillAmount = Mathf.Lerp(  experienceBar.fillAmount, currentExperience / requiredExperience, 2f * Time.deltaTime);


    }
}
