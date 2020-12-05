using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Invoke("loadfirstscene", 2f);
    }
    void loadfirstscene()
    {
        SceneManager.LoadScene(1);
    }
}
