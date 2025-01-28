using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int nextLevel;
    Respawn startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = FindObjectOfType<Respawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            startPos.transform.position = transform.position;
            SceneManager.LoadScene(nextLevel);
        }
    }
}
