using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore
{
    public class HandleImage
    {
        private String urlImage;
        public HandleImage(String url)
        {
            this.urlImage = url;
        }

        //Load image throught link
        private Image handleUrlImageByNET()
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(this.urlImage);
                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(stream);
                    return image;
                }
            }
        }

        //private Image handleUrlImageBySrc()
        //{

        //}
    }
}
