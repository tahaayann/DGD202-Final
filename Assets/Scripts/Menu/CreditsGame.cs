using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsGame : MonoBehaviour
{
    public void StartCredits()
    {
        SceneManager.LoadScene("Credits Scene");
    }

}
