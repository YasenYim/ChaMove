using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha1 : MonoBehaviour
{
    Animator animator;
    // ÿһ֡��ִ��move�ƶ�,û�е���дPlayerController�ű�,Move��һ��������,Ĭ����0~1֮��,��������Ļ�����0
    Vector3 move;

    public float speed = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �����ƶ�����
        Move(h, 0, v);

        // ���¶���
        UpdateAnim();
    }


    // �ƶ�����
    void Move(float x,float y,float z)
    {
        // ��������ϵ
        move = new Vector3(x, y, z);

        // Ҫ�����λ��
        Vector3 point = transform.position + move;      // λ�� + ���� = �µ�λ��
        transform.LookAt(point);
        // ��ҵ�ǰ��λ��
        transform.position += move * speed * Time.deltaTime;
    }


    // ���¶�������
    void UpdateAnim()
    {
        float forward = move.magnitude;         // forward��ֵ��0~1.414֮�䣬���x��zͬʱȡ��1�Ļ�
        animator.SetFloat("Forward", forward);
    }
}
