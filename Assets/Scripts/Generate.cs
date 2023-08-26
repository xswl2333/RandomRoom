using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generate : MonoBehaviour
{
    public enum Direction { up, down, left, right };
    public Direction direction;

    [Header("����Ԥ����")]
    public GameObject roomPrefab;
    public int roomAmount;
    public Transform roomParent;//���Ӹ�����,���ӱ����image
    public Vector3 roomPos = Vector3.zero;
    public GameObject endRoom;//���һ�����䣬Ҳ��boos��

    public float xOffset = 2.0f;
    public float yOffset = 2.0f;
    public LayerMask roomLayer;
    public int maxStep;


    public List<Room> roomList = new List<Room>();
    // Start is called before the first frame update
    public List<GameObject> farRooms = new List<GameObject>();
    public List<GameObject> lessRooms = new List<GameObject>();
    public List<GameObject> oneWayRooms = new List<GameObject>();

    void Start()
    {
        //BeginGenerate();
        for (int i = 0; i < roomAmount; i++)
        {
            roomList.Add(Instantiate(roomPrefab, roomPos, Quaternion.identity).GetComponent<Room>());

            //�ı�λ��
            ChangeRoomPos();
        }

        roomList[0].setRoomType(RoomType.Init);
        //��Զ����
        endRoom = roomList[1].gameObject;
        foreach (var room in roomList)
        {
            //if (room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
            //{
            //    endRoom = room.gameObject;
            //}

            SetupRoom(room, room.transform.position);

        }

        FindEndRoom();

        endRoom.GetComponent<Room>().setRoomType(RoomType.Boss);

    }

    public void ChangeRoomPos()
    {
        do
        {
            direction = (Direction)UnityEngine.Random.Range(0, 4);

            switch (direction)
            {
                case Direction.up:
                    roomPos += new Vector3(0, yOffset, 0);
                    break;
                case Direction.down:
                    roomPos += new Vector3(0, -yOffset, 0);
                    break;
                case Direction.left:
                    roomPos += new Vector3(-xOffset, 0, 0);
                    break;
                case Direction.right:
                    roomPos += new Vector3(xOffset, 0, 0);
                    break;
            }
        } while (Physics2D.OverlapCircle(roomPos, 0.2f, roomLayer));//��ײ�еļ��

    }


    public void SetupRoom(Room newRoom, Vector3 roomPosition)
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer);

        newRoom.UpdateRoom();
    }

    public void FindEndRoom()
    {
        //�����ֵ ��Զ��������
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].stepToStart > maxStep)
                maxStep = roomList[i].stepToStart;
        }

        //�����Զ����͵ڶ�Զ
        foreach (var room in roomList)
        {
            if (room.stepToStart == maxStep)
                farRooms.Add(room.gameObject);
            if (room.stepToStart == maxStep - 1)
                lessRooms.Add(room.gameObject);
        }

        for (int i = 0; i < farRooms.Count; i++)
        {
            if (farRooms[i].GetComponent<Room>().doorNumber == 1)
                oneWayRooms.Add(farRooms[i]);//��Զ������ĵ����ż���
        }

        for (int i = 0; i < lessRooms.Count; i++)
        {
            if (lessRooms[i].GetComponent<Room>().doorNumber == 1)
                oneWayRooms.Add(lessRooms[i]);//�ڶ�ԶԶ������ĵ����ż���
        }

        if (oneWayRooms.Count != 0)
        {
            endRoom = oneWayRooms[UnityEngine.Random.Range(0, oneWayRooms.Count)];
        }
        else
        {
            endRoom = farRooms[UnityEngine.Random.Range(0, farRooms.Count)];
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
