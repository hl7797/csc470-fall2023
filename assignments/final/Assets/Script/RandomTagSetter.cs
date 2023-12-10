
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] possibleTags;

    void Start()
    {
        
        string randomTag = GetRandomTag();

        
        gameObject.tag = randomTag;

        Debug.Log("Tag set to: " + randomTag);
    }

    
    string GetRandomTag()
    {
        if (possibleTags.Length == 0)
        {
            Debug.LogError("No tags defined in possibleTags array!");
            return null;
        }

        int randomIndex = Random.Range(0, possibleTags.Length);
        return possibleTags[randomIndex];
    }


// Update is called once per frame
void Update()
    {
        
    }
}
