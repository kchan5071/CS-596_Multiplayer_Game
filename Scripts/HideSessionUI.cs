using UnityEngine;

public class HideSessionUI : MonoBehaviour
{
    public void turn_off_UI()
    {
        GameObject.Find("SessionUI").SetActive(false);
    }
    public void turn_on_UI()
    {
        GameObject.Find("SessionUI").SetActive(true);
    }
}
