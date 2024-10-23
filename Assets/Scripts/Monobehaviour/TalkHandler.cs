using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TalkHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor = Color.white;
    public Color hoverColor = Color.red;
    private Button button;
    private Image buttonImage;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>(); 
        buttonImage.color = defaultColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = defaultColor;
    }
}
