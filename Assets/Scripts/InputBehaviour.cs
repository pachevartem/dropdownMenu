using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputBehaviour : MonoBehaviour
{
    [SerializeField] private InputField _inputField;

    [SerializeField] private Dropdown _dropdown;

    public List<string> words = new List<string>();

    void Start()
    {
        words = setupWords();

        _dropdown.options.Clear();
        _inputField.onEndEdit.AddListener(arg0 => tempp());

    }

    List<string> FindWords(string name)
    {
        var _resultList = new List<string>();

        foreach (string s in words)
        {
            if (s.Contains(name))
            {
                _resultList.Add(s);
            }
        }

        return _resultList;
    }

    void Update()
    {
      
       
    }

    IEnumerator SetFocusOnInput()
    {
        yield return 0;

        //inputField.MoveTextEnd(false);
    }

    void tempp()
    {
        _dropdown.options = datas(FindWords(_inputField.text));
        
        _dropdown.Hide();
        _dropdown.Show();
       
        EventSystem.current.SetSelectedGameObject(_inputField.gameObject, null);
        _inputField.selectionAnchorPosition = 0;
        
        if (_inputField.text.Length > 0)
        {
            _inputField.caretPosition = _inputField.text.Length;
        }
        _inputField.selectionFocusPosition = _inputField.text.Length;
        _inputField.ForceLabelUpdate();
        
        Debug.Log("00");
//        StartCoroutine(UpdateDropDown());
    }

    IEnumerator UpdateDropDown()
    {
        yield return null;
  
       
        
        Debug.Log("C-03");
    }

    List<string> setupWords()
    {
        var _tempList = new List<string>();

        _tempList.Add("artem");
        _tempList.Add("anton");
        _tempList.Add("vladimir");
        _tempList.Add("vladlena");

        return _tempList;
    }

    List<Dropdown.OptionData> datas(List<string> lib)
    {
        var _tempoptionData = new List<Dropdown.OptionData>();
        foreach (string s in lib)
        {
            _tempoptionData.Add(new Dropdown.OptionData(s));
        }

        return _tempoptionData;
    }
}