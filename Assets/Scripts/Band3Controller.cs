using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Band3Controller : MonoBehaviour
{
    [SerializeField]
    List<Sprite> bandSprites = new List<Sprite>();

    [SerializeField]
    TMP_Text powerTxt;

    public void ChangeSpriteFonx(int spriteNum)
    {
        GetComponent<Image>().sprite = bandSprites[spriteNum];
    }

    public void DefinePowerFonx(int powerNumLocal)
    {
        GameManager.instance.powerNum = powerNumLocal;
        powerTxt.text = powerNumLocal.ToString();
    }
}
