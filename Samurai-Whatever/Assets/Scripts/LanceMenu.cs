using UnityEngine;

public class LanceMenu : MonoBehaviour
{
    [SerializeField] GameObject MenuPause;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { if (!MenuPause.activeSelf)
            {
                MenuPause.SetActive(true);
                Time.timeScale = 0;
            } else
            {
                MenuPause.SetActive(false);
                Time.timeScale = 1;
            }
            
            
        }
        
    }
}
