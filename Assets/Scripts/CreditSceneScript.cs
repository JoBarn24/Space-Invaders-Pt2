using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ReturnToMainMenu());
    }
    
    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MenuScene");
    }
}
