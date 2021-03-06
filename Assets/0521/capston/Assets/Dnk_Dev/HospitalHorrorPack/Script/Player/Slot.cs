﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler// OnPointerEnter 메서드를 사용할 때 필요한 인터페이스.
 {
    public int number;  //슬롯 순서번호
    public Item item;   //슬롯에 들어있는 아이템

    private ActionController playerHand;
    private GameObject child;

    private Inventory inventory; // 인벤토리 가져오기

    void Start()
    {
        playerHand = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ActionController>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {

    }

    public void OnPointerClick(PointerEventData data)               //클릭했을때
    {
        if (item.itemValue > 0)                                     //슬롯에 아이템이 있고
        {
            if (playerHand.transform.childCount > 1)                //손에 든 아이템이 있을 때(0은 캔버스)
            {
                SwapItem();                                         //아이템 스왑하고
                inventory.ShowTooltip(item, transform.position);    //툴팁 보여주기

            }
            else                                                    //손에 든 아이템이 없을 때
            {
                PopItem();                                          //아이템 꺼내고
                inventory.HideTooltip();                            //툴팁 숨기기
            }

        }
        else                                                        //슬롯에 아이템이 없고
        {
            if (playerHand.transform.childCount > 1)                //손에 든 아이템이 있을 때
            {
                PushItem();                                         // 아이템 넣고
                inventory.ShowTooltip(item, transform.position);    //툴팁 보여주기
            }
        }
    }

    public void OnPointerEnter(PointerEventData data)               //마우스가 들어왔을때
    {
        GetComponent<Image>().color = new Color32(255, 255, 255, 0);//슬롯 색 변경
        if (item.itemValue > 0)                                     //슬롯에 아이템이 있으면
        {
            inventory.ShowTooltip(item, transform.position);        //툴팁 보여주기
        }
    }

    public void OnPointerExit(PointerEventData data)                //마우스가 나갈때
    {
        GetComponent<Image>().color = new Color32(255, 255, 255, 116);// 슬롯 색 원래대로
        inventory.HideTooltip();                                    //툴팁 숨기기
    }
    
    private void PushItem()
    {
        child = playerHand.transform.GetChild(1).gameObject;
        Debug.Log(child.name + " - 넣기 완료");
        int index = playerHand.DropItemToInventory();
        inventory.AddItem(child.name, number, index);
    }

    private void PopItem()
    {
        Debug.Log(item.itemName + " - 꺼내기 완료");
        playerHand.pickupItemFromInventory(item.itemID);
        inventory.RemoveItem(item.itemName, number);
    }

    private void SwapItem()
    {
        child = playerHand.transform.GetChild(1).gameObject;
        Debug.Log(child.name + " & " + item.itemName + " - 아이템 스왑 완료");

        int id = item.itemID;
        inventory.RemoveItem(item.itemName, number);

        int index = playerHand.DropItemToInventory();
        inventory.AddItem(child.name, number, index);

        playerHand.pickupItemFromInventory(id);
    }

    /*
    public Button theButton;
    private float timeCount;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element. " + eventData);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("The cursor clicked the selectable UI element. " + eventData);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exited the selectable UI element. " + eventData);
    }
    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("OnBeginDrag: " + data.position);
        data.pointerDrag = null;
    }
    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            timeCount += Time.deltaTime;
            if (timeCount > 1.0f)
            {
                Debug.Log("Dragging:" + data.position);
                timeCount = 0.0f;
            }
        }
    }
    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log("OnEndDrag: " + data.position);
    }*/
}