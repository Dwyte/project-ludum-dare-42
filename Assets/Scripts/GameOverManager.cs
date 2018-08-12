using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public TMP_Text scoreText;


    private void Start()
    {
        //"*** SCORE: " + FindObjectOfType<ScoreManager>().score + "MB (0x00000008, 0x000000006, 0x00000009, 0x847075cc)";

        scoreText.text = @"A Problem has been detected and windows has been shutdown to you computer.
           
YOU_RAN_OUT_OF_SPACE

If this is the first time you've seen this error screen,
restart your computer. If this screen appears again, follow
these steps:

Check to make sure any new hardware or software is properly installed. I this is a new installation, ask your hardware or software manufacturer for and Windows updates you might need.

If problems continue, disable or remove any newly installed hardware or software. Disable BIOS memory options such as caching or shadowing. If you need to use Safe Mode to remove or disable components, restart your computer, press F8 to select Advanced Startup Options, and then select Safe Mode.

Anyway, your last game information:
*** SCORE: " + FindObjectOfType<ScoreManager>().score + @"MB (0x00000008, 0x000000006, 0x00000009, 0x847075cc)

(Press Space)";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAgain();
        }
    }

    public void PlayAgain()
    {
        FindObjectOfType<ScoreManager>().score = 0f;
        SceneManager.LoadScene("GameScene");
    }
}
