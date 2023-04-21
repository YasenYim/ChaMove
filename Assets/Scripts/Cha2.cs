using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha2 : MonoBehaviour
{
    Animator animator;
    // 每一帧都执行move移动,没有单独写PlayerController脚本,Move是一个输入量,默认是0~1之间,如果不按的话就是0
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

        // 更新动画
        UpdateAnim();
    }
    void Move(float x, float y, float z)
    {
        // 世界坐标系
        move = new Vector3(x, y, z);
    }

    // 刚体移动，要在FixedUpdate里写
    private void FixedUpdate()
    {
        // 根据move，直接改变刚体速度
        Vector3 v = move * speed;
        v.y = rigid.velocity.y;
        rigid.velocity = v;

        // 要看向的位置
        Vector3 point = transform.position + move;      // 位置 + 向量 = 新的位置
        transform.LookAt(point);
        // 玩家当前的位置
        transform.position += move * speed * Time.deltaTime;

        //// 让刚体朝向目标
        //Quaternion q = Quaternion.LookRotation(move);   // 向量 转成 朝向
        //rigid.MoveRotation(q);

    }

    // 更新动画函数
    void UpdateAnim()
    {
        // 基于move
        //float forwardValue = move.magnitude;     // forward的值在0~1.414之间，如果x，z同时取到1的话
        // 基于刚体速度，播放动画

        animator.SetFloat("Forward", rigid.velocity.magnitude / speed);
    }
}
