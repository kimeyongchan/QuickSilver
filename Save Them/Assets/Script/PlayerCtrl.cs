using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Attack,
    Dead,
}

public class PlayerCtrl : MonoBehaviour
{
    public PlayerState PS;

    public Vector3 lookDirection;
    public float Speed = 0f;
    public float WalkSpeed = 6f;
    public float RunSpeed = 12f;

    void KeyBoardInput()
    {
        float xx = Input.GetAxisRaw("Vertical");    //방향에 따라 1,-1 반환
        float zz = Input.GetAxisRaw("Horizontal");

        if (PS != PlayerState.Attack)
        {
            //방향키로 캐릭터 이동
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
               Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                lookDirection = xx * Vector3.forward + zz * Vector3.right;
                Speed = WalkSpeed;
                PS = PlayerState.Walk;

                //Shift + 방향키 : 뛴다.
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Speed = RunSpeed;
                    PS = PlayerState.Run;
                }
            }

            //멈춤
            if (xx == 0 && zz == 0 && PS != PlayerState.Idle)
            {
                PS = PlayerState.Idle;
                Speed = 0f;
            }
        }
    }

    void LookUpdate()
    {
        //방향의 변환에 따라 캐릭터도 천천히 회전
        Quaternion R = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 10f);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);  //캐릭터 위치 이동
    }

    void Update()
    {
        KeyBoardInput();
        LookUpdate();
    }
}