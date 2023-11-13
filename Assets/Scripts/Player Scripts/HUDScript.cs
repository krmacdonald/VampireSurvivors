using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public playerLifeManager lifeScript;
    public Sprite[] beadSprites;
    public GameObject beadImage;
    private int spriteIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteIndex = (int)(lifeScript.health / 5.88235294);
        if(spriteIndex == 0 && lifeScript.health != 0)
        {
            spriteIndex = 1;
        }
        beadImage.GetComponent<Image>().sprite = beadSprites[17-spriteIndex];
    }
}
