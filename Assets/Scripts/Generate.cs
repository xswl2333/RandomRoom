using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generate : MonoBehaviour
{
    public enum Direction { up,down,left,right};
    public Direction direction; 

    [Header("房间预制体")]
    public GameObject roomPrefab;
    public int roomAmount;
    public Transform roomParent;//格子父物体,格子背后的image
    public Vector3 roomPos=Vector3.zero;
    public GameObject endRoom;//最后一个房间，也是boos房

    public float xOffset=2.0f;
    public float yOffset=2.0f;
    public LayerMask roomLayer;


    public List<GameObject> roomList=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //BeginGenerate();
        for(int i=0;i<roomAmount;i++)
        {
            roomList.Add(Instantiate(roomPrefab, roomPos, Quaternion.identity));

            //改变位置
            ChangeRoomPos();
        }

        roomList[0].GetComponent<Room>().setRoomType(RoomType.Init);
        //最远房间
        endRoom = roomList[0];
        foreach(var room in roomList)
        {
            if(room.transform.position.sqrMagnitude>endRoom.transform.position.sqrMagnitude)
            {
                endRoom=room;
            }

        }
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
        } while(Physics2D.OverlapCircle(roomPos, 0.2f, roomLayer));//碰撞盒的检测

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
