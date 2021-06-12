using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    ChangeRoom changeRoom;
    private int indexScene;

    // Start is called before the first frame update
    void Awake()
    {
        changeRoom = FindObjectOfType<ChangeRoom>();
        changeRoom.switchRoom += OnChangeRoom;

        indexScene = 1;
    }

    private void OnChangeRoom(object sender, EventArgs e)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(indexScene + 1, LoadSceneMode.Additive);
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(indexScene);
    }
}
