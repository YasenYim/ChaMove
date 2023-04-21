using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha1 : MonoBehaviour
{
    Animator animator;
    // 每一帧都执行move移动,没有单独写PlayerController脚本,Move是一个输入量,默认是0~1之间,如果不按的话就是0
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

        // 调用移动函数
        Move(h, 0, v);

        // 更新动画
        UpdateAnim();
    }


    // 移动函数
    void Move(float x,float y,float z)
    {
        // 世界坐标系
        move = new Vector3(x, y, z);

        // 要看向的位置
        Vector3 point = transform.position + move;      // 位置 + 向量 = 新的位置
        transform.LookAt(point);
        // 玩家当前的位置
        transform.position += move * speed * Time.deltaTime;
    }


    // 更新动画函数
    void UpdateAnim()
    {
        float forward = move.magnitude;         // forward的值在0~1.414之间，如果x，z同时取到1的话
        animator.SetFloat("Forward", forward);
    }
}
