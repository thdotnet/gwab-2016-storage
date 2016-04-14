using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Image
    {
        public string Url { get; set; }

        public byte[] Content { get; set; }

        public override string ToString()
        {
            if(string.IsNullOrWhiteSpace(Url) == false)
            {
                string[] temp = Url.Split('/');
                return temp[temp.Length - 1];
            }
            return "";
        }
    }
}