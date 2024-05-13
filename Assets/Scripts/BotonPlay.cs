using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonPlay : MonoBehaviour
{

    public Animator animator; // Referencia al Animator de la animacion
    public string sceneToLoad; // Nombre de la escena a cargar

    private Button button;
    
    private float Tiempo_Anim_Inicial = 5f;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayAnimationAndLoadScene);
    }

    private void PlayAnimationAndLoadScene()
    {
        // Reproduce la animacion
        animator.SetTrigger("TriggerPlay");

        // Espera a que termine la animacion antes de cargar la escena
        StartCoroutine(LoadSceneAfterAnimation());
    }

    private IEnumerator LoadSceneAfterAnimation()
    {
        yield return new WaitForSeconds(Tiempo_Anim_Inicial); //animator.GetCurrentAnimatorStateInfo(0).length

        // Carga la escena especificada
        SceneManager.LoadScene(sceneToLoad);
    }

}
