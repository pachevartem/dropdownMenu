using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputBehaviour : MonoBehaviour
{
    [SerializeField] 
    private InputField _inputField;

    [SerializeField] 
    private Dropdown _dropdown;

    public List<string> words = new List<string>();
    
    void Start()
    {
        words = setupWords();
        
        _dropdown.options.Clear();
//        _dropdown.options = datas(words);
        _inputField.onValueChanged.AddListener(arg0 => tempp());
        _dropdown.Show();
//        _inputField.ActivateInputField();
        
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
        _dropdown.options = datas(FindWords(_inputField.text));
       
    }


    void tempp()
    {

        (_dropdown as MyDropDown).rrrrr(FindWords(_inputField.text));
//        _dropdown.Hide();
//        _dropdown.Show();
        
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

