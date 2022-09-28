using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace LifePlanner
{
    class Serialize
    {

        public static void SerializeList(List<Form> formlist)
        {
            Stream stream = new FileStream("form_list.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(stream, formlist);
            stream.Close();
        }

        public static List<Form> DeSerializeList()
        {
            Stream stream = new FileStream("form_list.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            List<Form> list = (List<Form>)b.Deserialize(stream);
            stream.Close();

            return list;
        }
    }
}
