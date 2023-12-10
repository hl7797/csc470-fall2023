
using UnityEngine;


public class MouseComponent : MonoBehaviour
{
    public SFader sceneFader;
    
   
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void LateUpdate()
    {
      
        if(Input.GetKey(KeyCode.E))
        {
            sceneFader.FadeOut("SampleScene");
            
        }
    }

   
}
