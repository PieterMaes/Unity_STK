using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_changer : MonoBehaviour
{
    [Header("Goto this scene")]
    public string name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//Function gets called when startbutton is pushed (On Click)
	public void ChangeScene (string name)
    {
		SceneManager.LoadScene(name);
	}
}
