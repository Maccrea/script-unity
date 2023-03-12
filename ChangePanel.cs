using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour
{
    public GameObject ThisPanel;
    public GameObject TargetPanel;

    public void _ChangePanel()
    {
        ThisPanel.SetActive(false);
        TargetPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
