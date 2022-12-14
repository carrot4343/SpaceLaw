using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inventory : MonoBehaviour
{
    private static int MAX_ITEM_SLOT = 3;
    private static int MAX_ITEM_TYPE = 3;
    private static int STAGE_ENEMY_NUM;
    private bool[] isItemSlotFull = new bool[MAX_ITEM_SLOT+1];
    private int[] itemSlot = new int[MAX_ITEM_SLOT+1];
    public float playerInitSpeed, playerInitJumpPower;
    GameObject[] enemies;
    Player player;
    

    public GameObject[] itemObjectType = new GameObject[MAX_ITEM_TYPE + 1];

    void Start()
    {
        STAGE_ENEMY_NUM = FindObjectsOfType<Enemy>().Length;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = FindObjectOfType<Player>();
        for (int i = 0; i <= MAX_ITEM_SLOT; i++)
        {
            isItemSlotFull[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getNewItem(int itemType)
    {
        for(int i = 1; i <= MAX_ITEM_SLOT; i++)
        {
            if (isItemSlotFull[i] == false)
            {
                itemSlot[i] = itemType;
                isItemSlotFull[i] = true;
                GameObject itemobj;
                itemobj = Instantiate(itemObjectType[itemType], UI_manager.instance.inventorySlot[i-1].transform, false);
                itemobj.transform.localScale = new Vector3(300, 300, 300);
                //itemobj.transform.rotation = Quaternion.Euler(0, -40, 0);
                itemobj.layer = 5;
                break;
            }
        }
    }

    public void useItem(int itemSlotNum)
    {
        if(isItemSlotFull[itemSlotNum])//입력받은 아이템 슬롯에 아이템이 있는지 확인
        {
            isItemSlotFull[itemSlotNum] = false;
            if (itemSlotNum == 1)//아이템 슬롯 1번의 효과 발동
            {
                checkAndUseItem(itemSlotNum);
            }
            else if (itemSlotNum == 2)
            {
                checkAndUseItem(itemSlotNum);
            }
            else if (itemSlotNum == 3)
            {
                checkAndUseItem(itemSlotNum);
            }
            else
            {
                Debug.Log("WrongItemSlot");
            }
        }
        else
        {
            Debug.Log("Slot " + itemSlotNum + " is empty");
        }
    }
    private void checkAndUseItem(int itemSlotNum)
    {
        Destroy(UI_manager.instance.inventorySlot[itemSlotNum - 1].transform.GetChild(1).gameObject);
        switch (itemSlot[itemSlotNum])//아이템 타입 체크
        {
            case 1:
                useItemType1();
                break;
            case 2:
                useItemType2();
                break;
            case 3:
                useItemType3();
                break;
            default:
                Debug.Log("Wrong itemType");
                break;
        }
    }

    private void useItemType1() //모든 적 일시정지
    {
        Debug.Log("used1");
        for (int i = 0; i < STAGE_ENEMY_NUM; i++)
        {
            enemies[i].GetComponent<NavMeshAgent>().speed = 0.0f;
        }
        Invoke("rollBackEnemySpeed", 5f);
    }

    private void useItemType2() //일정시간동안 플레이어 속도 증가
    {
        Debug.Log("used2");
        player.speed = playerInitSpeed * 2.0f;
        player.jumppower = playerInitJumpPower * 1.5f;
        Invoke("rollBackPlayerStatus", 5f);
    }

    private void useItemType3() //체력 회복
    {
        Debug.Log("used3");
        Stg_manager.instance.increaseLife();
    }

    private void rollBackEnemySpeed()
    {
        for (int i = 0; i < STAGE_ENEMY_NUM; i++)
        {
            enemies[i].GetComponent<NavMeshAgent>().speed = 4.5f;
        }
    }

    private void rollBackPlayerStatus()
    {
        player.speed = playerInitSpeed;
        player.jumppower = playerInitJumpPower;
    }

    public bool getIsItemSlotFull(int itemSlotNum)
    {
        return isItemSlotFull[itemSlotNum];
    }

    public int getItemSlot(int itemSlotNum)
    {
        return itemSlot[itemSlotNum];
    }
}
