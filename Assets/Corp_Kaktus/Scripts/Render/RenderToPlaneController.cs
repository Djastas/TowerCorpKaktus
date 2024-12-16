using UnityEditor;
using UnityEngine;


namespace Corp_Kaktus.Scripts.Render
{
    public class RenderToPlaneController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        
        [Header("Serialize field to save in editor")]
        
        [SerializeField] private GameObject instance;
        [SerializeField] private MeshRenderer plane;
        [SerializeField] private RenderTexture renderTexture;
        
        [ContextMenu("Init")]
        private void Init()
        {
            Clear();
            renderTexture = new RenderTexture(Screen.currentResolution.height,Screen.currentResolution.width,16);

            if (mainCamera)
            {
                mainCamera.targetTexture = renderTexture;
            }
            else
            {
                Debug.LogWarning("Cant create Render plane because main camera not found"); 
                return;
            }

            var i = Resources.Load<GameObject>("CameraPrefab");
            instance = Instantiate(i);
            
            plane = instance.GetComponentInChildren<MeshRenderer>();

            plane.sharedMaterial.mainTexture = renderTexture;

            var transformLocalScale = new Vector2(Screen.currentResolution.width,Screen.currentResolution.height).normalized;
            var scaleCoefficient = 1/transformLocalScale.y ;
            var localScale = new Vector3(transformLocalScale.x,transformLocalScale.y,1) * scaleCoefficient;
            plane.transform.localScale = localScale;
            
        }

        [ContextMenu("Clear")]
        private void Clear()
        {
            if (instance) { DestroyImmediate(instance); }

            if (mainCamera)
            {
                mainCamera.targetTexture = null;
            }
        }

        private void Start()
        {
            Init();
        }

        [MenuItem("Tools/RenderToPlain/Init %q")]
        public static void InitStatic() => FindObjectOfType<RenderToPlaneController>().Init();
    }
}