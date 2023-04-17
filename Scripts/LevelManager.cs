using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterMovement.IsAlive == false)
        {
            loadLevel("Lose");
        }
    }

    public void loadLevel(string level)
    {
        Debug.Log("Attempting to load" + level);  // logs a message to the concole
        SceneManager.LoadScene(level);
    }
}
