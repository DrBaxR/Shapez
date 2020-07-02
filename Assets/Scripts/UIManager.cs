using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{

    public RectTransform mainMenu,titleMenu;
    // Start is called before the first frame update
    void Start()
    {
        //titleMenu.DOAnchorPos(Vector2.zero, 0.5f);
        mainMenu.DOAnchorPos(Vector2.zero, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Store()
    {
        SceneManager.LoadScene("Store");
    }
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
