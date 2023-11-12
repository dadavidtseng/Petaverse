using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    public void Awake()
    {
        if(GameManager.instance != null)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
