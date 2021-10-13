using System;

namespace PPM.UI.CLI
{
    internal class XmlModule
    {
        public XmlModule(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}