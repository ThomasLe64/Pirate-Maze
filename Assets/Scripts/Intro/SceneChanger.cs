//Script to change between scenes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Animator anim;
    public Image img;
    int temp = 0;

   public void ChangeScenes(int sceneChange)
    {
        //temp = sceneChange;
        //StartCoroutine(Fade());
        SceneManager.LoadScene(sceneChange);
    }
    /*
    IEnumerator Fade()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);
        SceneManager.LoadScene(temp);
    }
    */
}
