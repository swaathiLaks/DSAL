using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace treeViewAssignment2
{
    internal class FileIO
    {
        public string for_user = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "dsal_2227171_user");

        public void serialize(string fileName, List<Object> myObjects)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(stream, myObjects);
                stream.Close();
            }
        }

        public List<Object> deserialize(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                List<Object> myObjects = (List<Object>)formatter.Deserialize(stream);
                return myObjects;
            }
        }
    }
}
