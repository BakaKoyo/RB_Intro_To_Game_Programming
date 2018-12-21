using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UI_Script : MonoBehaviour
{

    public void LeveToLoad(string LevelLoad)
    {
        SceneManager.LoadScene(LevelLoad, LoadSceneMode.Single);
    }

}
