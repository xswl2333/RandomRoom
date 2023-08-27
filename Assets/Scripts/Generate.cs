using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Generate : MonoBehaviour
{

    public enum Direction { up, down, left, right };
    public Direction direction;

    public float xOffset = 2.0f;
    public float yOffset = 2.0f;

    public GameObject roomPrefab;
    public Transform roomParent;//格子父物体,格子背后的image

    public Vector3 roomPos = Vector3.zero;
    public Vector3 roomSize = Vector3.zero;
    public int roomAmount = 40;
    public float radius = 2.0f;

    public List<Room> roomList = new List<Room>();

    void Start()
    {

        for (int i = 0; i < roomAmount; i++)
        {
            var size = GetRandomPointInCircle(radius);
            roomSize = new Vector3((float)size.x*2, (float)size.y*2, 0);
            roomList.Add(Instantiate(roomPrefab, roomPos, Quaternion.identity).GetComponent<Room>());
            roomList[i].setRoomSize(roomSize);
            ChangeRoomPos();
        }
    }

    //单位圆随机生成大小
    public Vector2 GetRandomPointInCircle(float radius)
    {
        float angle = 2 * Mathf.PI * Random.value;//0-1之间随机
        float len = Random.value + Random.value;
        len = len < 1.0f ? len : 2 - len;//单位圆
        return new Vector2(Mathf.Cos(angle) * len * radius, Mathf.Sin(angle) * len * radius);
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
        } while (Physics2D.OverlapCircle(roomPos, 1.0f));//碰撞盒的检测

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
