using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public void StartGameFonx()
    {
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        animator.SetTrigger("start");
        AudioManager.instance.PlaySoundFonx("swooshSound");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("gameplayScene");

        AudioManager.instance.PlaySoundFonx("swooshSound");
    }
}
