using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    Animator animator, animator2, animator3, animator4;

    [SerializeField]
    GameObject colorPanel, colorPanel2, colorPanel3, colorPanel4;

    [SerializeField]
    GameObject resultPanel;

    [SerializeField]
    TMP_Text ohmTxt, tolerancedOhmTxt;

    bool isOpenLocal, isOpenLocal2, isOpenLocal3, isOpenLocal4 = false;

    public bool canPress = true;

    public int firstNum = 0, secondNum = 0, powerNum = 0;

    public float toleranceNum = 1f;

    private void Awake()
    {
        instance = this;
    }

    public void PressedColorButtonFonx()
    {
        if(canPress)
        {
            if (isOpenLocal == false)
            {
                animator.SetBool("isOpen", true);
                canPress = false;
                isOpenLocal = true;
                if (isOpenLocal2 == true)
                {
                    canPress = true;
                    PressedColorButtonFonx2();
                    canPress = false;
                }
                else if (isOpenLocal3 == true)
                {
                    canPress = true;
                    PressedColorButtonFonx3();
                    canPress = false;
                }
                else if (isOpenLocal4 == true)
                {
                    canPress = true;
                    PressedColorButtonFonx4();
                    canPress = false;
                }
                else
                {
                    Invoke("CanPressAgainFonx", .5f);
                }
            }
            else
            {
                animator.SetBool("isOpen", false);
                canPress = false;
                isOpenLocal = false;
                Invoke("CanPressAgainFonx", .5f);
            }
        }
    }

    public void PressedColorButtonFonx2()
    {
        if(canPress)
        {
            if (isOpenLocal2 == false)
            {
                animator2.SetBool("isOpen", true);
                isOpenLocal2 = true;
                canPress = false;
                if (isOpenLocal == true)
                {
                    canPress = true;
                    PressedColorButtonFonx();
                    canPress = false;
                }
                else if (isOpenLocal3 == true)
                {
                    canPress = true;
                    PressedColorButtonFonx3();
                    canPress = false;
                }
                else if (isOpenLocal4 == true)
                {
                    canPress = true;
                    PressedColorButtonFonx4();
                    canPress = false;
                }
                else
                {
                    Invoke("CanPressAgainFonx", .5f);
                }
            }
            else
            {
                animator2.SetBool("isOpen", false);
                canPress = false;
                isOpenLocal2 = false;
                Invoke("CanPressAgainFonx", .5f);
            }
        }
    }
    public void PressedColorButtonFonx3()
    {
        if(canPress)
        {
            if (isOpenLocal3 == false)
            {
                animator3.SetBool("isOpen", true);
                canPress = false;
                isOpenLocal3 = true;
                if (isOpenLocal == true)
                {
                    canPress = true;
                    PressedColorButtonFonx();
                    canPress = false;
                }
                else if (isOpenLocal2 == true)
                {
                    canPress = true;
                    PressedColorButtonFonx2();
                    canPress = false;
                }
                else if (isOpenLocal4 == true)
                {
                    canPress = true;
                    PressedColorButtonFonx4();
                    canPress = false;
                }
                else
                {
                    Invoke("CanPressAgainFonx", .5f);
                }
            }
            else
            {
                animator3.SetBool("isOpen", false);
                canPress = false;
                isOpenLocal3 = false;
                Invoke("CanPressAgainFonx", .5f);
            }
        }
    }

    public void PressedColorButtonFonx4()
    {
        if(canPress)
        {
            if (isOpenLocal4 == false)
            {
                animator4.SetBool("isOpen", true);
                isOpenLocal4 = true;
                canPress = false;
                if (isOpenLocal == true)
                {
                    canPress = true;
                    PressedColorButtonFonx();
                    canPress = false;
                }
                else if (isOpenLocal2 == true)
                {
                    canPress = true;
                    PressedColorButtonFonx2();
                    canPress = false;
                }
                else if (isOpenLocal3 == true)
                {
                    canPress = true;
                    PressedColorButtonFonx3();
                    canPress = false;
                }
                else
                {
                    Invoke("CanPressAgainFonx", .5f);
                }
            }
            else
            {
                animator4.SetBool("isOpen", false);
                canPress = false;
                isOpenLocal4 = false;
                Invoke("CanPressAgainFonx", .5f);
            }
        }
    }

    void CanPressAgainFonx()
    {
        if(canPress == true)
        {
            canPress = false;
        }
        else
        {
            canPress = true;
        }
    }

    public void CalculateFonx()
    {
        int receivedNum = firstNum * 10 + secondNum;
        int multiplier = (int)Mathf.Pow(10, powerNum);
        int ohmValue = receivedNum * multiplier;
        int ohmKiloValue = ohmValue / 1000;
        int ohmOtherValue = ohmValue % 1000;

        resultPanel.GetComponent<CanvasGroup>().DOFade(1f, .5f);
        resultPanel.GetComponent<RectTransform>().DOScale(1f, .5f).SetEase(Ease.OutBack);

        string ohmKiloStr = ohmKiloValue.ToString("N0", new System.Globalization.CultureInfo("tr-TR"));

        if (ohmOtherValue == 0)
        {
            ohmTxt.text = $"{ohmKiloStr}K Ω";   
        }
        else
        {
            ohmTxt.text = $"{ohmKiloStr}K{ohmOtherValue} Ω";
        }


        int counter = 0;
        if(toleranceNum % 1 == 0)
        {
            int realTolerance = (ohmValue * (int)toleranceNum) / 100;

            int minToleranceValue = ohmValue - realTolerance;
            int maxToleranceValue = ohmValue + realTolerance;

            int minToleranceKiloValue = minToleranceValue / 1000;
            int minToleranceOtherValue = minToleranceValue % 1000;

            int maxToleranceKiloValue = maxToleranceValue / 1000;
            int maxToleranceOtherValue = maxToleranceValue % 1000;

            string minToleranceKiloStr = minToleranceKiloValue.ToString("N0", new System.Globalization.CultureInfo("tr-TR"));
            string maxToleranceKiloStr = maxToleranceKiloValue.ToString("N0", new System.Globalization.CultureInfo("tr-TR"));

            if(minToleranceOtherValue == 0)
            {
                tolerancedOhmTxt.text = $"{minToleranceKiloStr}K Ω - {maxToleranceKiloStr}K Ω";
            }
            else
            {
                tolerancedOhmTxt.text = $"{minToleranceKiloStr}K{minToleranceOtherValue} Ω - {maxToleranceKiloStr}K{maxToleranceOtherValue} Ω";
            }

        }
        else if (toleranceNum % 1 != 0)
        {
            while (toleranceNum % 1 != 0)
            {
                counter++;
                toleranceNum *= 10;
            }

            int realTolerance = (ohmValue * (int)toleranceNum) / (100 * (int)Mathf.Pow(10, counter));

            int minToleranceValue = ohmValue - realTolerance;
            int maxToleranceValue = ohmValue + realTolerance;

            int minToleranceKiloValue = minToleranceValue / 1000;
            int minToleranceOtherValue = minToleranceValue % 1000;
            
            int maxToleranceKiloValue = maxToleranceValue / 1000;
            int maxToleranceOtherValue = maxToleranceValue % 1000;

            string minToleranceKiloStr = minToleranceKiloValue.ToString("N0", new System.Globalization.CultureInfo("tr-TR"));
            string maxToleranceKiloStr = maxToleranceKiloValue.ToString("N0", new System.Globalization.CultureInfo("tr-TR"));

            if (minToleranceOtherValue == 0)
            {
                tolerancedOhmTxt.text = $"{minToleranceKiloStr}K Ω - {maxToleranceKiloStr}K Ω";
            }
            else
            {
                tolerancedOhmTxt.text = $"{minToleranceKiloStr}K{minToleranceOtherValue} Ω - {maxToleranceKiloStr}K{maxToleranceOtherValue} Ω";
            }
        }
    }

    public void CalculateAgainFonx()
    {
        SceneManager.LoadScene("gameplayScene");
    }

    public void MainMenuFonx()
    {
        SceneManager.LoadScene("mainMenuScene");
    }

    public void ConvertionFonx(string name)
    {
        AudioManager.instance.PlaySoundFonx(name);
    }

    public void ConvertionPaintFonx(string name)
    {
        AudioManager.instance.PlayRandomPitchFonx(name);
    }

}
