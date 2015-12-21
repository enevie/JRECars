using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System;
using System.Web;
using System.Drawing;

namespace JRECars.Managers
{
	public class PathManager
	{
		public IList<string> GetAllPictures(string nameOfFolder)
		{
			var path = HttpContext.Current.Server.MapPath(nameOfFolder);

			return Directory.GetFiles(path);
		}

		public byte[] ImageToByteArray(HttpPostedFileBase model)
		{
			var array = new Byte[model.ContentLength];
			model.InputStream.Position = 0;
			model.InputStream.Read(array, 0, model.ContentLength);
			return array;
		}

		//public File ByteArrayToImage(byte[] bytesArr)
		//{
		//	if (bytesArr == null)
		//	{
		//		return null;
		//	}
			
			
		//	return File(bytesArr, "image / jpg","asda.jpg");
		//}

	}
}