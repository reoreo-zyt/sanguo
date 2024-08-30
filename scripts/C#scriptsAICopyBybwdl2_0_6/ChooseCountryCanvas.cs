using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseCountryCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
    /*

public class SelectHorizontalScrollItem : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [Tooltip("图片")]
    [SerializeField] private Image image;
    [Tooltip("名称文字")]
    [SerializeField] private Text nameText;
    [Tooltip("画布组")]
    [SerializeField] private CanvasGroup canvasGroup;

    [Tooltip("选项索引")]
    public int itemIndex;
    [Tooltip("信息索引")]
    public int infoIndex;
    [Tooltip("描述文本")]
    public string description;

    private SelectHorizontalScroll selectHorizontalScroll; [HideInInspector]
    public RectTransform rectTransform;
    private bool isDrag;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

}

  
    ///<summary>
    ///设置信息
    ///summary>
    ///<param name = "sprite" > 图片 </ param >
    ///< param name="name">名称</param>
    ///<param name = "description" > 描述 </ param >
    ///< param name="infoIndex">信息索引</param>
    ///<param name = "selectHorizontalScroll" > 无限水平滚动选择列表脚本 </ param >
    public void SetInfo(Sprite sprite, string name, string description, int infoIndex,
        SelectHorizontalScroll selectHorizontalScroll)
    {
        image.sprite sprite; nameText.text = name;
        this.description description;
        this.infoIndex = infoIndex;
        this.selectHorizontalScroll selectHorizontalScroll;
    }

    public void SetAlpha(float alpha)
    {
        canvasGroup.alpha = alpha;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = false; selectHorizontalScroll.OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isDrag)
        {
            selectHorizontalScroll.Select(itemIndex, infoIndex, rectTransform);
        }
        selectHorizontalScroll.OnPointerUp(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true; selectHorizontalScroll.OnDrag(eventData);
    }
}

    */