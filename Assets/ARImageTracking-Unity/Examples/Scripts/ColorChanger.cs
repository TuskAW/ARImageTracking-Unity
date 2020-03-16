using UnityEngine;

namespace ARImageTracking.Example
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField]
        private Color[] _Colors = 
        {
            new Color(0/255f, 184/255f, 212/255f), // Color code: #00B8D4
            new Color(197/255f, 17/255f, 98/255f), // Color code: #C51162
            new Color(255/255f, 171/255f, 0/255f), // Color code: #FFAB00
        };

        private Material _Material;
        private Renderer _Renderer;
        private int _CurrentColorIndex;

        void Start()
        {
            _Renderer = this.gameObject.GetComponent<MeshRenderer>();
            _Material = new Material(_Renderer.material);

            _Renderer.material = _Material;
        }

        public void ChangeCurrentColor()
        {
            _CurrentColorIndex++;
            _CurrentColorIndex =  _CurrentColorIndex % _Colors.Length;
            _Material.SetColor("_Color", _Colors[_CurrentColorIndex]);
        }
    }
}
