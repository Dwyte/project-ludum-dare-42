using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour {

    public float score;
    public static ScoreManager scoreManager;

    private void Start()
    {
        if(scoreManager == null)
        {
            scoreManager = this;
        }else if(scoreManager != this){
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
    }
}
