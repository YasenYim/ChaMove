using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha3 : MonoBehaviour
{
    Animator animator;
    // ÿһ֡��ִ��move�ƶ�,û�е���дPlayerController�ű�,Move��һ��������,Ĭ����0~1֮��,��������Ļ�����0
    Vector3 move;
    CharacterController cc;   // ��ҿ�����

    public float speed = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, 0, v);

        // ���¶���
        UpdateAnim();
    }
    void Move(float x, float y, float z)
    {
        move = new Vector3(x, y, z);
        // ��һ֡�ƶ�������,��С
        Vector3 m = move * speed * Time.deltaTime;

        // �����ƶ�����
        transform.LookAt(transform.position + m);

        // ͨ��ccȥ�ƶ���������ֱ�Ӹ�transform
        cc.Move(m);
    }

   

    // ���¶�������
    void UpdateAnim()
    {
        //animator.SetFloat("Forward", move.magnitude);
        animator.SetFloat("Forward", cc.velocity.magnitude / speed);
       
    }
}
