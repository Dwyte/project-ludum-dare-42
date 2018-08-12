using UnityEngine;
using TMPro;

public class FileStorageUI : MonoBehaviour {

    public TMP_Text spaceText;
    public Transform weaponTransform;


    private void Start()
    {
        weaponTransform = FindObjectOfType<FileStorageWeapon>().transform;
    }

    // Update is called once per frame
    void Update () {
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - weaponTransform.position.y <= 0f)
        {
            transform.position = new Vector2(weaponTransform.position.x, weaponTransform.position.y + 1f);
        }
        else
        {
            transform.position = new Vector2(weaponTransform.position.x, weaponTransform.position.y - 0.7f);
        }
	}

    public void UpdateSpaceLeftUI(float newValue)
    {
        spaceText.text = newValue.ToString("0.00") + " mb";
    }
}
