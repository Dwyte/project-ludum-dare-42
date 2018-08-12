using UnityEngine;
using TMPro;

public class FileUI : MonoBehaviour {

    public TMP_Text fileSizeText;
    public TMP_Text fileNameText;

    public void UpdateFileSizeUI(float newValue)
    {
        fileSizeText.text = newValue.ToString("0.00") + " mb";
    }
}
