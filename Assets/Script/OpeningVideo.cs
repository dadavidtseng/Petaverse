using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class OpeningVideo : MonoBehaviour
    {
        private void OnEnable()
        {
            SceneManager.LoadScene("StartGameButton", LoadSceneMode.Single);
        }
    }
}