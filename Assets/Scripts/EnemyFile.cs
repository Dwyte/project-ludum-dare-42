using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFile : MonoBehaviour {

    public string fileName;
    public Vector2 minMaxFileSize;
    public FileUI fileUI;
    public float fileSize;
    public bool compressed;
    public bool virus;
    private float totalFileSize;


    private void Start()
    {
        fileSize = Random.Range(minMaxFileSize.x, minMaxFileSize.y);
        totalFileSize = fileSize;
        fileUI.UpdateFileSizeUI(fileSize);
        fileUI.fileNameText.text = fileName;
    }

    public void TakeDeletionDamage(float deletionDamage)
    {
        if (virus)
            return;

        fileSize -= deletionDamage;
        fileUI.UpdateFileSizeUI(fileSize);

        FindObjectOfType<AudioManager>().Play("FileHurt");

        if (fileSize <= 0)
        {
            DeleteFile();
        }
    }

    public void DeleteFile()
    {
        FindObjectOfType<ScoreManager>().score += totalFileSize;
        if (compressed)
        {
            switch (GetComponent<CompressedFiles>().isFolder)
            {
                case true:
                    GetComponent<CompressedFiles>().OpenFolder();
                    break;
                case false:
                    GetComponent<CompressedFiles>().Decompress(totalFileSize);
                    break;
            }
        }
            
        Destroy(gameObject);
    }
}
