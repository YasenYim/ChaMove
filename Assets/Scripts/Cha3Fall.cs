using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha3Fall : MonoBehaviour
{
    Animator animator;
    // ÿһ֡��ִ��move�ƶ�,û�е���дPlayerController�ű�,Move��һ��������,Ĭ����0~1֮��   ��������Ļ�����0
    Vector3 move;
    CharacterController cc;   // ��ҿ�����
    public float speed = 3;
    [Range(0.0f,1.0f)]
    public float testSpeed = 1;
    bool isGround = true;
    float vy = 0;  // vy�Ǽ�¼�������ʱ����ٶȴ�С

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
        move = new Vector3(x, 0, z);

        // ��һ֡�ƶ�������,��С
        Vector3 FrameMove = move * speed * Time.deltaTime;

        if (isGround) { vy = 0; }   // vy��Ӱ����һ֡��λ��
        else { vy += Physics.gravity.y * Time.deltaTime; }  // v = gt �������ٶ�

        // ��һ֡��Сλ��y = �ٶ�vy * ��һ֡��ʱ��
        FrameMove.y = vy * Time.deltaTime;

        // �����ƶ�����
        transform.LookAt(transform.position + FrameMove);

        // ͨ��ccȥ�ƶ���������ֱ�Ӹ�transform
        cc.Move(FrameMove);
    }

    private void FixedUpdate()
    {
        // �ӽŵ�20cm���ϵ�λ�����´�һ������
        // �������ص�ǰ������ʼ�㣬�����Ƿ���
        Ray ray = new Ray(transform.position + new Vector3(0, 0.2f, 0), Vector3.down);
        RaycastHit hit;   // ������Ϣ
        Color c = Color.white;   // û�д��е�ʱ��,Ĭ����ɫ�ǰ�ɫ
        isGround = false;
        if(Physics.Raycast(ray,out hit,0.35f))
        {
            c = Color.red;   // ������У���ɫ�ĳɺ�ɫ
            isGround = true;
        }
        Debug.DrawLine(transform.position + new Vector3(0, 0.2f, 0), transform.position - new Vector3(0, 0.15f, 0),c);
    }


    // ���¶�������
    void UpdateAnim()
    {
        //animator.SetFloat("Forward", move.magnitude);
        animator.SetFloat("Forward", cc.velocity.magnitude / speed * testSpeed);
    }
}
