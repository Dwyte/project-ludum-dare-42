using UnityEngine;
using UnityEngine.SceneManagement;

public class FileStorageHealth : MonoBehaviour {

    public float storageCapacity;
    public float totalSpaceLeft;

    public Color infectedColor;


    private void Start()
    {
        totalSpaceLeft = storageCapacity;
        FindObjectOfType<FileStorageUI>().UpdateSpaceLeftUI(totalSpaceLeft);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyFiles")
        {
            if (collision.GetComponent<EnemyFile>().compressed)
            {
                if (collision.GetComponent<CompressedFiles>().isFolder)
                {
                    collision.GetComponent<CompressedFiles>().OpenFolder();
                }
            }

            StoreFile(collision.GetComponent<EnemyFile>().fileSize);

            if (collision.GetComponent<EnemyFile>().virus)
                Infect();

            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ProgramFiles")
        {
            if (collision.GetComponent<ProgramFile>().programType == ProgramType.antivirus)
            {
                StoreFile(collision.GetComponent<ProgramFile>().programFileSize);
                Normalize();
            }
            else if (collision.GetComponent<ProgramFile>().programType == ProgramType.cleaner)
            {
                totalSpaceLeft *= 1.25f;

                if (totalSpaceLeft > storageCapacity)
                    totalSpaceLeft = storageCapacity;

                Destroy(collision.gameObject);


                FindObjectOfType<FileStorageUI>().UpdateSpaceLeftUI(totalSpaceLeft);
            }

            Destroy(collision.gameObject);
        }
    }

    public void StoreFile(float fileSize)
    {
        totalSpaceLeft -= fileSize;
        FindObjectOfType<FileStorageUI>().UpdateSpaceLeftUI(totalSpaceLeft);

        FindObjectOfType<AudioManager>().Play("Hurt");

        if (totalSpaceLeft <= 0)
        {
            Debug.Log("You run out of space");
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void Infect()
    {
        GetComponent<FileStorageMovement>().speed = GetComponent<FileStorageMovement>().infectedSpeed;
        GetComponent<FileStorageMovement>().dashForce = GetComponent<FileStorageMovement>().infectedDashForce;
        GetComponent<SpriteRenderer>().color = infectedColor;


        FindObjectOfType<ProgramSpawner>().SpawnAntiVirus();
    }

    public void Normalize()
    {
        GetComponent<FileStorageMovement>().speed = GetComponent<FileStorageMovement>().startSpeed;
        GetComponent<FileStorageMovement>().dashForce = GetComponent<FileStorageMovement>().startDashForce;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}   
