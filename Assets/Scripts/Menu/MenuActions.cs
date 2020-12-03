using UnityEngine;

public class MenuActions : MonoBehaviour
{
    public void MENU_ACTION_GotoPage(string mainMenu)
    {
        Application.LoadLevel("mainMenu");
        FindObjectOfType<AudioManager>().Stop("EndMusic");
        FindObjectOfType<AudioManager>().Play("Theme");
        
    }
}