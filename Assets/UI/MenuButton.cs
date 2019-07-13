
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    const float NORMAL_ALPHA = 0.502f;
    const float MOUSE_OVER_ALPHA = 1.000f;

    public GameObject menuPanel;
    public GameObject buttonImage;
    public GameObject stage;
    Button thisButton;
    Image iconImage;
    StateManager stateManager;


	// Use this for initialization
	void Start () {
        iconImage = buttonImage.GetComponent<Image>();
        thisButton = GetComponent<Button>();
        stateManager = stage.GetComponent<StateManager>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnClick() {
        if(menuPanel.activeInHierarchy) {
            menuPanel.SetActive(false);
            stateManager.ReleaseInput();
        } else {
            menuPanel.SetActive(true);
            stateManager.LockInput();
        }
    }

    public void OnPointerEnter( PointerEventData eventData ) {
        ChangeAlpha(MOUSE_OVER_ALPHA);
        stateManager.LockInput();
    }

    public void OnPointerExit( PointerEventData eventData ) {
        ChangeAlpha(NORMAL_ALPHA);
        stateManager.ReleaseInput();
    }

    public void ChangeAlpha( float alpha ){
        var iconColor = iconImage.color;
        iconColor.a = alpha;
        iconImage.color = iconColor;
        var buttonColor = thisButton.image.color;
        buttonColor.a = alpha;
        thisButton.image.color = buttonColor;
    }

}
