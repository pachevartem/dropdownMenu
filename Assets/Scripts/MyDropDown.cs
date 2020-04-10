using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyDropDown : Dropdown
{
    protected override void OnDidApplyAnimationProperties()
    {
        base.OnDidApplyAnimationProperties();
    }

    protected override void OnCanvasGroupChanged()
    {
        base.OnCanvasGroupChanged();
    }

    protected override void OnCanvasHierarchyChanged()
    {
        base.OnCanvasHierarchyChanged();
    }

    public override bool IsInteractable()
    {
        return base.IsInteractable();
    }

    protected override void OnRectTransformDimensionsChange()
    {
        base.OnRectTransformDimensionsChange();
    }

    protected override void InstantClearState()
    {
        base.InstantClearState();
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
    }

    public override Selectable FindSelectableOnLeft()
    {
        return base.FindSelectableOnLeft();
    }

    public override Selectable FindSelectableOnRight()
    {
        return base.FindSelectableOnRight();
    }

    public override Selectable FindSelectableOnUp()
    {
        return base.FindSelectableOnUp();
    }

    public override Selectable FindSelectableOnDown()
    {
        return base.FindSelectableOnDown();
    }

    public override void OnMove(AxisEventData eventData)
    {
        base.OnMove(eventData);
    }

//    public override void OnPointerDown(PointerEventData eventData)
//    {
//        base.OnPointerDown(eventData);
//    }
//
//    public override void OnPointerUp(PointerEventData eventData)
//    {
//        base.OnPointerUp(eventData);
//    }
//
//    public override void OnPointerEnter(PointerEventData eventData)
//    {
//        base.OnPointerEnter(eventData);
//    }
//
//    public override void OnPointerExit(PointerEventData eventData)
//    {
//        base.OnPointerExit(eventData);
//    }
//
//    public override void OnSelect(BaseEventData eventData)
//    {
//        base.OnSelect(eventData);
//    }
//
//    public override void OnDeselect(BaseEventData eventData)
//    {
//        base.OnDeselect(eventData);
//    }

    public override void Select()
    {
        base.Select();
    }

//    public override void OnPointerClick(PointerEventData eventData)
//    {
//        base.OnPointerClick(eventData);
//    }
//
//    public override void OnSubmit(BaseEventData eventData)
//    {
//        base.OnSubmit(eventData);
//    }
//
//    public override void OnCancel(BaseEventData eventData)
//    {
//        base.OnCancel(eventData);
//    }

    protected override GameObject CreateBlocker(Canvas rootCanvas)
    {
        Debug.Log("CreateBlocker");
        var a = base.CreateBlocker(rootCanvas);
        a.GetComponent<Image>().raycastTarget = false;
        return a;
//        return base.CreateBlocker(rootCanvas);
    }

    protected override void DestroyBlocker(GameObject blocker)
    {
        base.DestroyBlocker(blocker);
    }

    public void rrrrr(List<string> items)
    {
        foreach (var s in options)
        {
            var _tempDropdownItem = new DropdownItem();

            if (_tempDropdownItem.text != null)
            {
                _tempDropdownItem.text.text = s.text;
            }

            DestroyItem(_tempDropdownItem);
        }
//        DestroyDropdownList(template.gameObject);

        CreateDropdownList(template.gameObject);
        foreach (string s in items)
        {
//            CreateItem(itemText.);
        }
    }

    protected override GameObject CreateDropdownList(GameObject template)
    {
        Debug.Log("CreateDropdownList");
        return base.CreateDropdownList(template);
    }

    protected override void DestroyDropdownList(GameObject dropdownList)
    {
        Debug.Log("DestroyDropdownList");

        base.DestroyDropdownList(dropdownList);
    }

    protected override DropdownItem CreateItem(DropdownItem itemTemplate)
    {
        Debug.Log("CreateItem");

        return base.CreateItem(itemTemplate);
    }

    protected override void DestroyItem(DropdownItem item)
    {
        Debug.Log("DestroyItem");

        base.DestroyItem(item);
    }
}