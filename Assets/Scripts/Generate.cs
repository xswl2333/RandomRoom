using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Generate : MonoBehaviour
{

    public GameObject roomPrefab;
    public Transform roomParent;//格子父物体,格子背后的image
    // Start is called before the first frame update
    void Start()
    {
        BeginGenerate();
    }
    void BeginGenerate()
    {
        GameObject room1 = GameObject.Instantiate(roomPrefab, roomParent);
        room1.transform.position= Vector3.zero;
        room1.GetComponent<Room>().setRoomType(RoomType.Normal);
        GameObject room2= GameObject.Instantiate(roomPrefab, roomParent);
        room2.transform.position= new Vector3(3.0f,3.0f,0.0f);
        room2.GetComponent<Room>().setRoomType(RoomType.Boss);
        GameObject room3 = GameObject.Instantiate(roomPrefab, roomParent);
        room3.transform.position = new Vector3(-3.0f, 3.0f, 0.0f);
        room3.GetComponent<Room>().setRoomType(RoomType.Elite);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
