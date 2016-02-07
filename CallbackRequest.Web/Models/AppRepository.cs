using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace CallbackRequest.Web.Models
{
    public class AppRepository
    {
        private readonly string _filePath;

        public AppRepository()
        {
            _filePath = HostingEnvironment.MapPath("~/store.txt");
            // должны быть уверены, что файл, в который будем сохранять записи, существует
            using (var fs = new FileStream(_filePath, FileMode.OpenOrCreate)) { }
        }

        public IEnumerable<CallbackModel> GetAllCallbacks()
        {
            try
            {
                var res = new List<CallbackModel>();
                using (var sr = new StreamReader(_filePath))
                {
                    var line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        var arrData = line.Split(',');
                        res.Add(new CallbackModel
                        {
                            Name = arrData[0],
                            Phone = arrData[1],
                            CreatedAt = DateTime.Parse(arrData[2])
                        });
                    }
                }

                return res.OrderBy(x=>x.CreatedAt);
            }
            catch (Exception)
            {
                // todo log exception
                return new List<CallbackModel>();
            }
        }

        public bool SaveCallback(CallbackModel entity)
        {
            try
            {
                using (var sw = new StreamWriter(_filePath, true))
                {
                    sw.WriteLine(string.Format("{0},{1},{2}", entity.Name, entity.Phone, DateTime.UtcNow));
                }
                return true;
            }
            catch (Exception)
            {
                // todo log exception
                return false;
            }
        }
    }
}