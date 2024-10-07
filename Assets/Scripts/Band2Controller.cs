using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Band2Controller : MonoBehaviour
{
    [SerializeField]
    List<Sprite> bandSprites = new List<Sprite>();

    [SerializeField]
    TMP_Text digit2;

    public void ChangeSpriteFonx(int spriteNum)
    {
        GetComponent<Image>().sprite = bandSprites[spriteNum];
    }

    public void SecondColorValueFonx(int secondColorNum)
    {
        GameManager.instance.secondNum = secondColorNum;
        digit2.text = secondColorNum.ToString();
    }
}
