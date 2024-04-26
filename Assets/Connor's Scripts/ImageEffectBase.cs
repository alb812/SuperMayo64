using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof (Camera))]
    [AddComponentMenu("")]
    public class ImageEffectBase : MonoBehaviour
    {
        public Shader shader;

        private Material m_Material;

        protected Material material
        {
            get
            {
                if (m_Material == null)
                {
                    m_Material = new Material(shader);
                    m_Material.hideFlags = HideFlags.HideAndDontSave;
                }
                return m_Material;
            }
        }

		// Tutorial said to declare OnDisable as a protected virtual void but I'm not sure
		// what that means. Couldn't find an answer when I looked it up either. But if I change it,
		// the code breaks lol.
        protected virtual void OnDisable()
        {
            if (m_Material)
            {
                DestroyImmediate(m_Material);
            }
        }
    }
}