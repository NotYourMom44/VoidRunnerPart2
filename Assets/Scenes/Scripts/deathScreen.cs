using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class deathScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
        Debug.Log("sdfghjk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
