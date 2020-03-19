using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{

    public RectTransform mainMenu,titleMenu;
    // Start is called before the first frame update
    void Start()
    {
        titleMenu.DOAnchorPos(Vector2.zero, 0.5f);
        mainMenu.DOAnchorPos(Vector2.zero, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
