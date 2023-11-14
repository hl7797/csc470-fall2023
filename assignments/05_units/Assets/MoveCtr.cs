//using System.Collections;
//using System.Collections.Generic;
//using System.Net.Http.Headers;
using UnityEngine;



enum StateEnum
{
    Idle,
    Walk
}
public class MoveCtr : MonoBehaviour
{
    public float moveSpeed;
    float stopDistance = 0.2f;
    Vector3 desPos;
    Vector3 lookPos;
    Vector3 desDir;
    Quaternion desRot;

    StateEnum currentState;

    Transform skillArea;
    bool readyToUseSkill = false;
    public GameObject Skill;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        skillArea = transform.Find("SkillArea");
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();


        switch (currentState)
        {
            case StateEnum.Idle:
                Idling();
                break;
                case StateEnum.Walk:
                Walking();
                break;
        }

       

        if (Input.GetMouseButtonDown(1))
        {
            CancelSkill();
            Move();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            readyToUseSkill = true;
            GetReadyToUseSkill();
          
        }
        if (Input.GetMouseButtonDown(0) && readyToUseSkill== true)
        {
            UseSkill();
            GameObject fire = Instantiate(Skill, transform.position, Quaternion.identity);        
            Destroy(fire,5f);

        }
    }
    private void UseSkill()
    {
        currentState = StateEnum.Idle;
        animator.SetBool("Skill", true);
        CancelSkill();
    }
    private void CancelSkill()
    {
        skillArea.gameObject.SetActive(false);
        readyToUseSkill = false;
    }

    private void GetReadyToUseSkill()
    {
        skillArea.gameObject.SetActive(true);
        skillArea.GetComponent<MeshFilter>().mesh = CreateMesh();
    }

    Mesh CreateMesh()
    {
        int segments = 10;
        float outRadius = 3f;
        float innerRadius = 1f;
        float angle = 360;
        Vector3[] vertices = new Vector3[segments * 2 + 2];
        int[] triangles = new int[segments * 6];
        Vector2[]uv = new Vector2[vertices.Length];
        float rad = Mathf.Deg2Rad * angle;
        float startRad = rad;
        float deltaRad = rad / segments;
        for(int i = 0; i<vertices.Length; i+=2)
        {
            float cosA = Mathf.Cos(startRad);
            float sinA = Mathf.Sin(startRad);
            vertices[i] = new Vector3(cosA*outRadius,0,sinA*outRadius);
            vertices[i+1] = new Vector3(cosA * innerRadius, 0, sinA * innerRadius);
            startRad -= deltaRad;
        }
        for (int i = 0, j= 0; i < triangles.Length; i+=6, j+=2)
        {
            triangles[i] = j;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
            triangles[i + 3] = j + 3;
            triangles[i + 4] = j + 2;
            triangles[i + 5] = j + 1;
        }
        for(int i =0;  i < uv.Length; i++)
        {
            uv[i] = new Vector2(vertices[i].x / outRadius, vertices[i].z / outRadius);
        }
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.name = "Hello";
        return mesh;
    }

   
    private void Idling()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Skill", false);
        //animator.SetBool("Hit", false);
    }

    private void Walking () 
    {
        animator.SetBool("Walking", true);
        animator.SetBool("Skill", false);
       // animator.SetBool("Hit", false);
        transform.Translate(desDir.normalized * Time.deltaTime * moveSpeed,Space.World);
        transform.rotation = Quaternion.Lerp(transform.rotation, desRot, Time.deltaTime *10);
        float distance = Vector3.Distance(transform.position, desPos);
        if (distance <= stopDistance)
        {
            currentState = StateEnum.Idle;
        }
    }

    private void Move()
    {
       
        currentState = StateEnum.Walk;
        desPos = lookPos;
        desDir = desPos - transform.position;
        GameObject tmp = new GameObject();
        tmp.transform.position = transform.position;
        tmp.transform.LookAt(desPos);
        desRot = tmp.transform.rotation;
       Destroy(tmp );
       
    }

    void GetMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit hitInfo;
        if (Physics.Raycast( ray, out hitInfo ) )
        {
            Vector3 mousePos = hitInfo.point;
            lookPos = mousePos;
            lookPos.y = transform.position.y;
            

        }
     }
    
}
