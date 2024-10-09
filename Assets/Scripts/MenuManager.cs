using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject startGameButton;

    [SerializeField]
    RawImage bg;

    [SerializeField]
    float x, y;

    private void Start()
    {
        startGameButton.GetComponent<CanvasGroup>().DOFade(1, .5f);
        startGameButton.GetComponent<RectTransform>().DOScale(.75f, .5f).SetEase(Ease.OutBack);
    }

    private void Update()
    {
        bg.uvRect = new Rect(bg.uvRect.position + new Vector2(x, y) * Time.deltaTime, bg.uvRect.size);
    }
}
