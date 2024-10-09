using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerClickHandler
{
    private Animator animator;
    [SerializeField]
    private LoadSprites loadSprites;// ����� ������� ��������� � ���������� ��� ������ �� ���� �����
    
    private void Awake()
    {
        animator = GetComponent<Animator>(); // ������ �� ��������� �������� � Awake.
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
