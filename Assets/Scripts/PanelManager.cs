﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    public GameObject DevicesPanel;
    public GameObject LayoutPanel;
    public Camera TopDownCam;
    public Camera MainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Devices()
    {
        MainCamera.gameObject.SetActive(true);
        TopDownCam.gameObject.SetActive(true);
        DevicesPanel.gameObject.SetActive(true);
        LayoutPanel.gameObject.SetActive(false);
        TopDownCam.rect = new Rect(0, .3f, .4f, .7f);
        MainCamera.rect = new Rect(.4f, .3f, .6f, .7f);
    }

    public void Layout()
    {
        MainCamera.gameObject.SetActive(false);
        TopDownCam.gameObject.SetActive(true);
        DevicesPanel.gameObject.SetActive(false);
        LayoutPanel.gameObject.SetActive(true);
        TopDownCam.rect = new Rect(0, .3f, .8f, .7f);
        MainCamera.rect = new Rect(0, 0, 0, 0);
    }
}