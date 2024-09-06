using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletFirePos;
    private int bullet = 6;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && bullet > 0)
        {
            animator.SetTrigger("shoot");
            StartCoroutine(AnimationDelay());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bullet = 6;
        }
    }

    public IEnumerator AnimationDelay()
    {
        Debug.Log("애니메이션 시작");
        yield return new WaitForSeconds(1.85f); 
        Debug.Log("총알 생성됨");
        Instantiate(Bullet, BulletFirePos.position, BulletFirePos.rotation);
        bullet--;
    }
}
