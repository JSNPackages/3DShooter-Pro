using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelecter : MonoBehaviour
{

    public void PlayGame(int index) {
        SceneManager.LoadScene(index);
        
    }


    public void QuitGame() {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
