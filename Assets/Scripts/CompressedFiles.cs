using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompressedFiles : MonoBehaviour {

    public ProgramFilesPackage[] files;
    public bool isFolder;

    public void OpenFolder()
    {
        int rand = Random.Range(0, files.Length);

        foreach (GameObject GO in files[rand].programs)
        {
            Instantiate(GO, transform.position, transform.rotation);
        }
    }

    public void Decompress(float fileSize)
    {
        if(fileSize < 1f)
        {
            foreach (GameObject GO in files[0].programs)
            {
                Instantiate(GO, transform.position, transform.rotation);
            }
        }
        else if (fileSize >= 1f && fileSize < 3f)
        {
            foreach (GameObject GO in files[1].programs)
            {
                Instantiate(GO, transform.position, transform.rotation);
            }
        }
        else if (fileSize >= 3f && fileSize < 10f)
        {
            foreach (GameObject GO in files[2].programs)
            {
                Instantiate(GO, transform.position, transform.rotation);
            }
        }
        else if (fileSize >= 10f && fileSize < 25f)
        {
            foreach (GameObject GO in files[3].programs)
            {
                Instantiate(GO, transform.position, transform.rotation);
            }
        }

        if(Random.Range(0,2) == 0)
        {
            foreach (GameObject GO in files[4].programs)
            {
                Instantiate(GO, transform.position, transform.rotation);
            }
        }

        if (Random.Range(0, 4) == 0)
        {
            foreach (GameObject GO in files[5].programs)
            {
                Instantiate(GO, transform.position, transform.rotation);
            }
        }
    }
}
