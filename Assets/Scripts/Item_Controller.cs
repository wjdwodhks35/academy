using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Controller : MonoBehaviour
{
    public float dropSpeed;        // �������� �ӵ�

    void Update()
    {
        transform.Translate(0, this.dropSpeed, 0);      // ������ ����߸��� || rigidbody�� ��ü ���� 
        if (transform.position.y < -1.0f)                // ȭ�� ��(ü���� ��)���� �������� ����
        { Destroy(gameObject); }
    }
}
