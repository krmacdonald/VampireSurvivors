using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public playerLifeManager lifeScript;
    public Sprite[] beadSprites;
    public GameObject beadImage;
    public GameObject crossMask;
    private RectTransform maskSize;
    private int spriteIndex;
    // Start is called before the first frame update
    void Start()
    {
        maskSize = crossMask.GetComponent<RectTransform>();
        maskSize.sizeDelta = new Vector2(100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        maskSize.sizeDelta = new Vector2(100, lifeScript.repentance);
        spriteIndex = (int)(lifeScript.health / 5.88235294);
        if(spriteIndex == 0 && lifeScript.health != 0)
        {
            spriteIndex = 1;
        }
        beadImage.GetComponent<Image>().sprite = beadSprites[17-spriteIndex];
    }


}
