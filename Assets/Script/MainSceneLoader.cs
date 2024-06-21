using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class MainSceneLoader : MonoBehaviour
    {
        private void OnEnable()
        {
            SceneManager.LoadScene("Petaverse", LoadSceneMode.Single);
        }
    }
}