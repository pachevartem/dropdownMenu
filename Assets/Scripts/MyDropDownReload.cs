using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDropDownReload : MonoBehaviour
{
    [SerializeField]
    private InputField _inputField = null;
    [SerializeField]
    private GameObject _contentObject = null;

    public GameObject prefabsUIButton;
    public List<string> words = new List<string>();

    public Font Font;
    public Color ColorFont;
    
    private Dictionary<string, Transform> myButtons = new Dictionary<string, Transform>();
    
    void GenerateDropDownMenu(List<string> words)
    {
        foreach (var word in words)
        {
            AddButton(word, _contentObject.transform, (RectTransform) _inputField.transform);
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

    GameObject GetNewUIButton()
    {
        GameObject button = new GameObject("UIButton", typeof(RectTransform),typeof(CanvasRenderer), typeof(Image), typeof(Button));
        GameObject textObject = new GameObject("text", typeof(Text));
        textObject.gameObject.transform.SetParent(button.transform);
        Text text = textObject.GetComponent<Text>();
        text.font = Font;
        text.alignment = TextAnchor.MiddleLeft;
        text.color = ColorFont;
        ((RectTransform) textObject.transform).anchorMin = new Vector2(0,0);
        ((RectTransform) textObject.transform).anchorMax = new Vector2(1,1);
        
        // ((RectTransform) textObject.transform).rect.Set(0,0,0,0);
        ((RectTransform) textObject.transform).offsetMin = new Vector2(10,0);
        ((RectTransform) textObject.transform).offsetMax = new Vector2(0,0);

        return button;
    }
    
    void AddButton(string name, Transform content, RectTransform inputField)
    {
        var obj = GetNewUIButton();
        obj.transform.SetParent(content.transform);
        var myText = obj.GetComponentInChildren<Text>();
        myText.text = name;

        var grigLayout = content.GetComponent<GridLayoutGroup>();
        
        var rect = inputField.rect;
        grigLayout.cellSize = new Vector2(rect.width,rect.height);
        
        myButtons.Add(name,obj.transform);
    }

    

}
