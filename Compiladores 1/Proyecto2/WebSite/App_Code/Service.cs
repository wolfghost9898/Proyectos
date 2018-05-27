using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

    public byte[] getImagenes(string fileName)
    {
        try
        {
            FileInfo fInfo = new FileInfo(System.Web.Hosting.HostingEnvironment.MapPath
            ("~/Imagenes/") +
            fileName);
            long numBytes = fInfo.Length;
            double dLen = Convert.ToDouble(fInfo.Length / 1000000);
            if (dLen < 4)
            {
                FileStream fStream = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath
                        ("~/Imagenes/") +
                        fileName,
            FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);

                // convert the file to a byte array
                byte[] data = br.ReadBytes((int)numBytes);
                br.Close();
                return data;
            }
        }
        catch(Exception e)
        {
            return null;

        }
        return null;

    }

    public string guardarImagen(byte[] f, string fileName)
    {
        try
        {
            MemoryStream ms = new MemoryStream(f);
            FileStream fs = new FileStream
                    (System.Web.Hosting.HostingEnvironment.MapPath
                    ("~/Imagenes/") +
                    fileName, FileMode.Create);
            ms.WriteTo(fs);
            ms.Close();
            fs.Close();
            fs.Dispose();
            return "ok";

        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }
}
