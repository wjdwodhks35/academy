using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket_Controller : MonoBehaviour
{
    public GameDirector gm;

    public AudioClip appleSE;
    public AudioClip bombSE;

    AudioSource aud;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z); //  y���� 0 ��� transform.position.y��� ������ ���� ����.
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            Debug.Log("���");                // �浹 üũ(���)
            aud.PlayOneShot(this.appleSE);    // ��� �Ծ��� ��
            gm.GetApple();
        }
        else if (other.CompareTag("Bomb"))
        {
            Debug.Log("��ź");                // �浹 üũ(��ź)
            aud.PlayOneShot(this.bombSE);     // ��ź �Ծ��� ��
            gm.GetBomb();
        }
        Destroy(other.gameObject);      // ����
    }
}
