using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public int width, height;
    public RoomType type;

    public GameObject doorLeft, doorRight, doorUp, doorDown;//用来存放各个位置的门

    public bool roomLeft, roomRight, roomUp, roomDown;//判断上下左右是否有房间

    public int stepToStart;//距离初始点的网格距离

    public int doorNumber;//当前房间的门的数量/入口数量

    void Start()
    {
        //对应方向的门是否显示，关联对应方向是否有其他房间
        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);
    }

    public void setRoomType(RoomType type)
    {
        this.type = type;
        switch (type)
        {
            case RoomType.Normal:
                this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(170f / 255f, 120f / 255f, 110f / 255f);
                break;
            case RoomType.Init:
                this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(170f / 255f, 120f / 255f, 110f / 255f);
                break;
            case RoomType.Boss:
                this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(124f / 255f, 56f / 255f, 65f / 255f);
                break;
            case RoomType.Elite:
                this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(90f / 255f, 90f / 255f, 190f / 255f);
                break;
        }

    }

    public RoomType getRoomType()
    {
        return this.type;
    }

    public void UpdateRoom()
    {
        //计算距离初始点的网格距离
        stepToStart = (int)(Mathf.Abs(transform.position.x / 2) + Mathf.Abs(transform.position.y / 2));

        if (roomUp)
            doorNumber++;
        if (roomDown)
            doorNumber++;
        if (roomLeft)
            doorNumber++;
        if (roomRight)
            doorNumber++;
    }

}
