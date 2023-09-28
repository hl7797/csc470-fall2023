using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController cc;
    public float horizaontalMove, vertaontalMove;
    public Vector3 pos;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        horizaontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        vertaontalMove = Input.GetAxis("Vertical") * moveSpeed;
        pos = transform.forward * vertaontalMove + transform.right * horizaontalMove;
        cc.Move(pos * Time.deltaTime);


    }
}