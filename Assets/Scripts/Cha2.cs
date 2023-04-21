using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha2 : MonoBehaviour
{
    Animator animator;
    // ÿһ֡��ִ��move�ƶ�,û�е���дPlayerController�ű�,Move��һ��������,Ĭ����0~1֮��,��������Ļ�����0
    Vector3 move;
    Rigidbody rigid;
   
    public float speed = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
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
        // ��������ϵ
        move = new Vector3(x, y, z);
    }

    // �����ƶ���Ҫ��FixedUpdate��д
    private void FixedUpdate()
    {
        // ����move��ֱ�Ӹı�����ٶ�
        Vector3 v = move * speed;
        v.y = rigid.velocity.y;
        rigid.velocity = v;

        // Ҫ�����λ��
        Vector3 point = transform.position + move;      // λ�� + ���� = �µ�λ��
        transform.LookAt(point);
        // ��ҵ�ǰ��λ��
        transform.position += move * speed * Time.deltaTime;

        //// �ø��峯��Ŀ��
        //Quaternion q = Quaternion.LookRotation(move);   // ���� ת�� ����
        //rigid.MoveRotation(q);

    }

    // ���¶�������
    void UpdateAnim()
    {
        // ����move
        //float forwardValue = move.magnitude;     // forward��ֵ��0~1.414֮�䣬���x��zͬʱȡ��1�Ļ�
        // ���ڸ����ٶȣ����Ŷ���

        animator.SetFloat("Forward", rigid.velocity.magnitude / speed);
    }
}
