using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerClickHandler
{
    private Animator animator;
    [SerializeField]
    private LoadSprites loadSprites;// лучше ручками назначить в инспекторе чем искать по всей сцене
    
    private void Awake()
    {
        animator = GetComponent<Animator>(); // ссылку на компомент получаем в Awake.
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        OnClick();
    }
    
    private void OnClick()
    {
        animator.SetBool("anim", true);
        loadSprites.load();
    }
    
}
