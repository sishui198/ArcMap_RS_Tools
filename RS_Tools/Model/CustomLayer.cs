using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace RS_Tools.Model
{
    class CustomLayer
    {
        public CustomLayer(ILayer layer)
        {
            _layer = layer;
            Name = _layer.Name;
        }

        private ILayer _layer;
        public ILayer Layer
        {
            get { return _layer; }
            set
            {
                if (_layer != value)
                {
                    _layer = value;
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public IFeatureLayer FeatureLayer()
        {
            return Layer as IFeatureLayer;
        }

        public IFeatureClass FeatureClass()
        {
            return ((IFeatureLayer)Layer).FeatureClass;
        }
    }
}
