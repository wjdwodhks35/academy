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
                transform.position = new Vector3(x, 0, z); //  y값에 0 대신 transform.position.y라고 적으면 더욱 좋다.
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            Debug.Log("사과");                // 충돌 체크(사과)
            aud.PlayOneShot(this.appleSE);    // 사과 먹었을 때
            gm.GetApple();
        }
        else if (other.CompareTag("Bomb"))
        {
            Debug.Log("폭탄");                // 충돌 체크(폭탄)
            aud.PlayOneShot(this.bombSE);     // 폭탄 먹었을 때
            gm.GetBomb();
        }
        Destroy(other.gameObject);      // 삭제
    }
}
