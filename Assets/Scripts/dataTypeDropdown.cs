﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dataTypeDropdown : MonoBehaviour {
    Dropdown mDropdown;
    database bodydb;
    // Use this for initialization
    void Start () {
        mDropdown = GetComponent<Dropdown>();
        bodydb = GameObject.FindGameObjectWithTag("Database").GetComponent<database>();
        transform.gameObject.SetActive(false);
        mDropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(mDropdown);
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void DropdownValueChanged(Dropdown change)
    {
        database.Body body;
        Dropdown bodyOption = GameObject.Find("PlayUI/Canvas/Panel/bodyInput/bodyOption").GetComponent<Dropdown>();
        Dropdown inputFileOption = GameObject.Find("PlayUI/Canvas/Panel/bodyInput/inputFileOption").GetComponent<Dropdown>();
        body = bodydb.getDatabyName(inputFileOption.value, bodyOption.options[bodyOption.value].text);
        Dropdown dirOption = GameObject.Find("PlayUI/Canvas/Panel/bodyInput/dirOption").GetComponent<Dropdown>();
        

        if (body.name != "NotFound") GameObject.FindGameObjectWithTag("Database").GetComponent<DataGenerator>().createList(body, dirOption.options[dirOption.value].text, change.options[change.value].text);
    }
}
