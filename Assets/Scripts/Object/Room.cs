using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public int width, height;
    public RoomType type;

    public GameObject doorLeft, doorRight, doorUp, doorDown;//������Ÿ���λ�õ���

    public bool roomLeft, roomRight, roomUp, roomDown;//�ж����������Ƿ��з���

    public int stepToStart;//�����ʼ����������

    public int doorNumber;//��ǰ������ŵ�����/�������

    void Start()
    {
        //��Ӧ��������Ƿ���ʾ��������Ӧ�����Ƿ�����������
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
        //��������ʼ����������
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
