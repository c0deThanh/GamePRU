using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Canvas", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
