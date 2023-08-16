using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
   public int width, height;
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

   public RoomType getRoomType()
   {
       return this.type;
   }
}
