using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDropDownReload : MonoBehaviour
{
    [SerializeField]
    private InputField _inputField;
    [SerializeField]
    private GameObject _contentObject;

    public GameObject prefabsUIButton;
    public List<string> words = new List<string>();
    
    
    private Dictionary<string, Transform> myButtons = new Dictionary<string, Transform>();
    
    void AddButton(string name)
    {
        var obj = Instantiate(prefabsUIButton);
        obj.transform.SetParent(_contentObject.transform);
        var myText = obj.GetComponentInChildren<Text>();
        myText.text = name;
        
        myButtons.Add(name,obj.transform);
    }

    void GenerateDropDownMenu(List<string> words)
    {
        foreach (var word in words)
        {
            AddButton(word);
        }
    }

    void ClearDropDownMenu()
    {
        foreach (KeyValuePair<string,Transform> keyValuePair in myButtons)
        {
            Destroy(keyValuePair.Value.gameObject);
        }
        myButtons.Clear();
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
    
    void Start()
    {
        words = setupWords();
        
        _inputField.onValueChanged.AddListener(OnValueChange);
    }

    private void OnValueChange(string arg0)
    {
        ClearDropDownMenu();
        GenerateDropDownMenu(FindWords(arg0));
    }
}
