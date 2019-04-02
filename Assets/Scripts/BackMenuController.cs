using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenuController : MonoBehaviour
{
    // Start is called before the first frame update
   public void BackStartGame()
    {
        SceneManager.LoadScene("Start");
    }
}
