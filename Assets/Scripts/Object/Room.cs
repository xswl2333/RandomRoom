using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using Color = UnityEngine.Color;

public class Room : MonoBehaviour
{
    [Header("房间的宽高")]
    public Vector2 roomSize;
    [Header("房间的类型")]
    public RoomType type;

    public void setRoomType(RoomType type)
    {
        this.type = type;
        switch (type)
        {
            case RoomType.Normal:
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

    public void setRoomSize(Vector2 size)
    {
        roomSize.x = size.x;
        roomSize.y = size.y;
        this.gameObject.transform.localScale = new Vector3(roomSize.x, roomSize.y, 0);//set没用，只有重新赋值
    }
    public RoomType getRoomType()
    {
        return this.type;
    }

    public Vector2 getRoomSize()
    {
        return new Vector2(roomSize.x, roomSize.y);
    }
}
