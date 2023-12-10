
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    public TMP_Text endInfo;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (GameManager.Instance.endGame == true)
        {
            endInfo.text = " Mission accomplished";
        }
        else if (GameManager.Instance.endGame == false)
        {
            endInfo.text = " Mission failed";
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

   public void restart()
    {
        SceneManager.LoadScene("Start");
    }
}

