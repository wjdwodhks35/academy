using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Controller : MonoBehaviour
{
    public float dropSpeed;        // 떨어지는 속도

    void Update()
    {
        transform.Translate(0, this.dropSpeed, 0);      // 스스로 떨어뜨리기 || rigidbody로 대체 가능 
        if (transform.position.y < -1.0f)                // 화면 밖(체스판 밑)으로 떨어지면 삭제
        { Destroy(gameObject); }
    }
}
