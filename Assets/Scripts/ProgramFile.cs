using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProgramType { antivirus, cleaner }
public class ProgramFile : MonoBehaviour {

    public string programName;
    public float programFileSize;
    public FileUI fileUI;
    public ProgramType programType;

    private void Start()
    {
        fileUI.UpdateFileSizeUI(programFileSize);
        fileUI.fileNameText.text = programName;
        Debug.Log("haha");
    }
}
