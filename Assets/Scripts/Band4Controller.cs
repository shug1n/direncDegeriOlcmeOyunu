using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Band4Controller : MonoBehaviour
{
    [SerializeField]
    List<Sprite> bandSprites = new List<Sprite>();

    [SerializeField]
    TMP_Text toleranceTxt;

    public void ChangeSpriteFonx(int spriteNum)
    {
        if(spriteNum == 10)
        {
            gameObject.SetActive(false);
        }
        else
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
            GetComponent<Image>().sprite = bandSprites[spriteNum];
        }
    }

    public void GetToleranceNumFonx(float toleranceNumLocal)
    {
        GameManager.instance.toleranceNum = toleranceNumLocal;
        if (toleranceNumLocal == 1 || toleranceNumLocal == 2 || toleranceNumLocal == 5)
        {
            toleranceTxt.fontSize = 34;
        }
        else if (toleranceNumLocal == 10 || toleranceNumLocal == 20)
        {
            toleranceTxt.fontSize = 26.5f;
        }
        else if (toleranceNumLocal == .5f || toleranceNumLocal == .1f)
        {
            toleranceTxt.fontSize = 24f;
        }
        else if (toleranceNumLocal == 0.25f)
        {
            toleranceTxt.fontSize = 16f;
        }
        else if (toleranceNumLocal == .05f)
        {
            toleranceTxt.fontSize = 17f;
        }

        toleranceTxt.text = toleranceNumLocal.ToString();
    }
}
