using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{
    private ScenTransition scenTransitions;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("map1", LoadSceneMode.Single );

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scenTransitions = FindObjectOfType<ScenTransition>();
    }

}
