using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFile : MonoBehaviour
{
    public SaveMgr saveMgr;

    // Start is called before the first frame update
    void Start()
    {
        saveMgr = GameObject.FindGameObjectWithTag("GameManger").GetComponent<SaveMgr>();
    }

    public void FileDelete()
    {
        saveMgr.DeleteSave();
    }
}
