using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelecter : MonoBehaviour
{

    public void PlayGame() {
        SceneManager.LoadScene("CreateOrJoinLobby");
    }


    public void QuitGame() {
        Application.Quit();
    }
}
