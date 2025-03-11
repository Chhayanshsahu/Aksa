using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void PlayGame ()
   {
    SceneManager.LoadScene ("CutScene");
   }

   public void QuitGame ()
   {
    Application.Quit ();
   
   }
}
