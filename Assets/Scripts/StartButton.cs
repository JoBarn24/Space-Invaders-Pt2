using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void LoadCreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
