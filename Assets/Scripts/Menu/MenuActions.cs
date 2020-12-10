using UnityEngine;

public class MenuActions : MonoBehaviour
{
    public void MENU_ACTION_GotoPage(string mainMenu)
    {
        FindObjectOfType<AudioManager>().Stop("bossmusic");
        FindObjectOfType<AudioManager>().Stop("EndMusic");
        FindObjectOfType<AudioManager>().Stop("ShopMusic");
        FindObjectOfType<AudioManager>().Play("Theme");
        Application.LoadLevel("mainMenu");
    }
}