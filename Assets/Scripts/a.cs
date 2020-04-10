using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropdownFilter : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField inputField;
    [SerializeField]
    private TMPro.TMP_Dropdown dropdown;

    private List<TMPro.TMP_Dropdown.OptionData> dropdownOptions;

    private List<TMPro.TMP_Dropdown.OptionData> dropdownOptionstmp;



    private void Start()
    {

        if (dropdown.options.Count > 0)
        {
            dropdownOptions = dropdown.options;

            dropdownOptions.Insert(0, new TMPro.TMP_Dropdown.OptionData("null"));
        }
    }

    public void FilterDropdown(string input)
    {
        if (dropdown.IsExpanded)
            dropdown.Hide();
        

        StopAllCoroutines();

        dropdown.value = 0;

        StartCoroutine(UpdateDropdown(input));
        
    }

    public void UpdateText()
    {
        if (dropdown.value != 0)
        {

            if (dropdown.options.Count > 0)
                inputField.text = dropdown.options[dropdown.value].text;


            inputField.selectionAnchorPosition = 0;
            inputField.selectionFocusPosition = inputField.text.Length;
            inputField.ForceLabelUpdate();
            dropdown.Hide();
        }
    }

    IEnumerator UpdateDropdown(string input)
    {
        StartCoroutine(SetFocusOnInput());

        yield return new WaitForSeconds(0.4f);

        dropdownOptionstmp = dropdownOptions.FindAll(option => option.text.ToUpper().IndexOf(input.ToUpper()) >= 0);

        if (dropdownOptionstmp[0].text != "null")
            dropdownOptionstmp.Insert(0, new TMPro.TMP_Dropdown.OptionData("null"));

        dropdown.options = dropdownOptionstmp;


        if (dropdown.options.Count > 1)
            if (!dropdown.IsExpanded)
                if (inputField.text != dropdown.options[1].text)
                {
                    dropdown.Show();
                    
                }

        StartCoroutine(SetFocusOnInput());
    }

    IEnumerator SetFocusOnInput()
    {        
        yield return 0;
        EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
        //inputField.MoveTextEnd(false);

        if (inputField.text.Length>0)
            inputField.caretPosition = inputField.text.Length;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (dropdown.options.Count > 1)
                inputField.text = dropdown.options[1].text;
            if (dropdown.IsExpanded)
                dropdown.Hide();
        }
    }
    
}
