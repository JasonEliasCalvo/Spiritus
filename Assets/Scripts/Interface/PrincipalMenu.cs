using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincipalMenu : MonoBehaviour
{
    public Animator animator;

    public void Play()
    {
        StartCoroutine(ChangeScene());
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator ChangeScene()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
