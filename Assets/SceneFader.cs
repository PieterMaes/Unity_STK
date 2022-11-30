using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            LoadNextScene();
        }
    }

    public void LoadNextScene() {
        StartCoroutine(LoadFadingScene());
    }
    
    IEnumerator LoadFadingScene() {
        
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(1);
    }
    
}
