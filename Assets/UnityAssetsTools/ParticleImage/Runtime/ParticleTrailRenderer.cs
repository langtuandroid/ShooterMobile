using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityAssetsTools.ParticleImage.Runtime
{
    [AddComponentMenu("UI/Particle Image/Trail Renderer")]
    public class ParticleTrailRenderer : MaskableGraphic
    {
        private ParticleImage _particle;
        private List<UIVertex> _vertexList = new List<UIVertex>();

        public ParticleImage particle
        {
            get => _particle;
            set => _particle = value;
        }

        private VertexHelper _vertexHelper = new VertexHelper();

        public VertexHelper vertexHelper
        {
            get => _vertexHelper;
            set => _vertexHelper = value;
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            
            vertexHelper.GetUIVertexStream(_vertexList);

            vh.AddUIVertexTriangleStream(_vertexList);
            
            _vertexHelper.Clear();
        }
    }
}