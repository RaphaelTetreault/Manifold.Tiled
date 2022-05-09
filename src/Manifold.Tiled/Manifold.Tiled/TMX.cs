using System.Xml;

namespace Manifold.Tiled
{
    public class TMX
    {
        /// <summary>
        /// 
        /// </summary>
        public Map Map { get; set; } = new Map();

        public static TMX FromFile(string path)
        {
            var isExtensionTmx = path.EndsWith(".tmx");
            if (!isExtensionTmx)
                throw new FileLoadException("Provided file path is not a Tiled .tmx file.");

            var doesFileExist = File.Exists(path);
            if (!doesFileExist)
                throw new FileNotFoundException("File path does not exists.");

            string tmxText = File.ReadAllText(path);
            var tmx = FromText(tmxText);
            return tmx;
        }

        public static TMX FromText(string data)
        {
            var document = new XmlDocument();
            document.LoadXml(data);

            var tmx = new TMX();
            tmx.Map = Map.FromXml(document);

            return new TMX();
        }



    }
}
