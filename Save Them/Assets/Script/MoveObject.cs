using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
    private GameObject target;  // 마우스가 클릭한 오브젝트
    public int Degree = 90;     //90도씩 회전하므로 90으로 초기화
    public float y1 = 0f;   // y축으로 회전할 양을 0으로 초기화

    bool isRotate = false;  // 오브젝트가 회전 중인지 아닌지
    float deltaTime;    // deltaTime 저장용 변수

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
    }

    void Turn()     // 클릭했을 때 조건에 맞으면 회전시키는 함수
    {
        // 마우스 왼쪽 버튼 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();    // 현재 마우스 포인터에 있는 오브젝트 저장

            if ( target.Equals(gameObject) == true )    // 저장된 오브젝트와 마우스가 클릭한 오브젝트가 같으면
            {
                // 회전 중이면 넘어감
                if (isRotate == true) { }
                // 회전 중이 아니면 true로 바꿔주고 deltaTime 초기화
                else
                {
                    isRotate = true;
                    deltaTime = 0;
                }
            }
        }
        // 회전 중이면
        if (isRotate == true)
        {
            deltaTime += Time.deltaTime;    // deltaTime 더해가며 저장
            if (deltaTime < 1)      // deltaTime이 1초 보다 작으면
            {
                y1 += Time.deltaTime * Degree;   // Degree(90)를 deltaTime만큼 나눠서 
                gameObject.transform.rotation = Quaternion.Euler(0, y1, 0);     // y축으로 회전시킨다
            }
            else {       // 1보다 크거나 작으면 정지
                isRotate = false;
            }
        }
    }

    private GameObject GetClickedObject()    // 마우스 포인터가 있는 곳에 오브젝트가 있는지 확인
    {
        //충돌이 감지된 영역
        RaycastHit hit;
        //찾은 오브젝트
        GameObject target = null;

        //마우스 포이트 근처 좌표를 만든다.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //마우스 근처에 오브젝트가 있는지 확인
         if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }
}

