using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.01f;
    public float Timer = 60.0f;

    // 선언은 flaot라도 대입한 숫자의 값에 f를 넣지 않으면 정수를 받는다.
    private float RandX;
    private float RandZ;
    private int RandChance;
    public void SetParameter(float sp, float spd, int rt)    //(생성 속도, 떨어지는 속도, 떨어지는 확률)
    {
        span = sp;
        speed = spd;
        ratio = rt;
    }

    void Update()
    {
        RandChance = Random.Range(1, 11);   // 1~10까지 랜덤한 수 배출
        this.delta += Time.deltaTime;
        this.Timer -= Time.deltaTime;

        if (this.delta > this.span)
        {
            GameObject item;
            RandX = Random.Range(-1, 2);
            RandZ = Random.Range(-1, 2);

            this.delta = 0;
            if (RandChance <= ratio)
            { item = Instantiate(bombPrefab, new Vector3(RandX, 4, RandZ), Quaternion.identity); }
            else
            { item = Instantiate(applePrefab, new Vector3(RandX, 4, RandZ), Quaternion.identity); }

            item.GetComponent<Item_Controller>().dropSpeed = this.speed;

            Debug.Log(RandChance);
        }
    }
}
