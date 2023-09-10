using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownChanger : MonoBehaviour
{
    public string DropDownName;

    void Start()
    {
        Dropdown ddtmp;
        ddtmp = GetComponent<Dropdown>();
        ddtmp.value = Setting.GetValue(DropDownName);
    }

    void Update()
    {

    }

    public void ChangeValue()
    {
        Dropdown ddtmp;

        ddtmp = GetComponent<Dropdown>();

        string selectedvalue = ddtmp.options[ddtmp.value].text;
        Debug.Log("ChangeValue: " + selectedvalue);

        Setting.SetValue(DropDownName, ddtmp.value);
    }
}