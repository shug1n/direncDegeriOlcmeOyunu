using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Band1Controller : MonoBehaviour
{
    [SerializeField]
    List<Sprite> bandSprites = new List<Sprite>();

    [SerializeField]
    TMP_Text digit1;

    public void ChangeSpriteFonx(int spriteNum)
    {
        GetComponent<Image>().sprite = bandSprites[spriteNum];
    }

    public void ColorValueFonx(int colorValue)
    {
        GameManager.instance.firstNum = colorValue;
        digit1.text = colorValue.ToString();
    }
}
