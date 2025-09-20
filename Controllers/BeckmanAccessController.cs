using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIS_Middleware.DataDB;
using LIS_Middleware.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIS_Middleware.Controllers
{
    public class Access_ExamineItems
    {
        public static string Gl199Ag = "Gl19-9Ag";
        public static string freePSA = "freePSA";
        public static string PSAHyb = "PSA-Hyb";
        public static string OV125Ag = "OV125Ag";
        public static string AFP = "AFP";
        public static string VitB12 = "VitB12";
        public static string BR153Ag = "BR15-3Ag";
        public static string DilAFP = "Dil-AFP";
        public static string CEA2 = "CEA2";
        public static string Testosterone = "Testo";
        public static string HCG5 = "HCG5";
        public static string hLH = "hLH";
        public static string Insulin = "Insulin";
    }

    [Route("Access2")]
    public class BeckmanAccessController : Controller
    {
        private static readonly string[] ExamineItems = new[]
        {
            "Gl19-9Ag", "freePSA", "PSA-Hyb", "OV125Ag", "AFP", "VitB12", "BR15-3Ag", "Dil-AFP", "CEA2", "Testo", "HCG5", "hLH", "Insulin"
        };

        Dictionary<string, string> Access_ExamineItems_Dic = new Dictionary<string, string>()
        {
            { Access_ExamineItems.Gl199Ag, "GI19-9Ag" },
            { Access_ExamineItems.freePSA, "freePSA" },
            { Access_ExamineItems.PSAHyb, "PSA-Hyb" },
            { Access_ExamineItems.OV125Ag, "OV125Ag" },
            { Access_ExamineItems.AFP, "AFP" },
            { Access_ExamineItems.VitB12, "VitB12" },
            { Access_ExamineItems.BR153Ag, "BR15-3Ag" },
            { Access_ExamineItems.DilAFP, "Dil-AFP" },
            { Access_ExamineItems.CEA2, "CEA2" },
            { Access_ExamineItems.Testosterone, "Testo" },
            { Access_ExamineItems.HCG5, "HCG5" },
            { Access_ExamineItems.hLH, "hLH" },
            { Access_ExamineItems.Insulin, "Insulin" },
        };

        // GET Access2/getItems/{Barcode}
        [HttpGet("getItems/{barcode}")]
        public Response Get(string barcode)
        {
            // 回傳的物件
            Response response = new Response();

            try
            {
                using (BeckManContext beckManContext = new BeckManContext())
                {
                    List<Orders> pendingOrders = (from o in beckManContext.ExOrders
                                                  where ExamineItems.Contains(o.Equitemid) && o.Barcode == barcode
                                                  select new Orders
                                                  {
                                                      BarCode = o.Barcode,
                                                      PatientID = o.PId,
                                                      PatientName = o.Name,
                                                      PatientGender = o.Sex == "男" ? 0 : 1,
                                                      ItemsCode = Access_ExamineItems_Dic[o.Equitemid],
                                                      ItemsName = o.Equitemid
                                                  }).ToList();
                    // 如果有項目要做
                    if (pendingOrders.Count > 0)
                    {
                        response.success = true;
                        response.message = "有醫令存在!";
                        response.data = pendingOrders;
                    }
                    else
                    {
                        response.success = false;
                        response.message = "查無醫令!";
                        response.data = null;
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "發生例外：" + ex.ToString();
                response.data = null;
                return response;
            }
        }

        // POST 更新檢驗項目已被機器讀走
        [HttpPost("setItemsQueried")]
        public Response setItemsQueried([FromBody] List<Orders> orders)
        {
            // 回傳的物件
            Response response = new Response();

            try
            {
                using (BeckManContext beckManContext = new BeckManContext())
                {
                    foreach (var item in orders)
                    {
                        (from o in beckManContext.ExOrders
                         where o.Barcode == item.BarCode && o.Equitemid == item.ItemsName
                         select o).ToList().ForEach(x => {
                             x.Dwflag = "1";
                             x.SDate = DateTime.Now.ToString("yyyyMMdd");
                             x.Dworderdate = DateTime.Now.ToString("yyyyMMddHHmmss");
                         });
                    }

                    beckManContext.SaveChanges();

                    response.success = true;
                    response.message = "讀取醫令完成！";
                    response.data = null;

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "發生例外：" + ex.ToString();
                response.data = null;

                return response;
            }
        }

        // POST 更新檢驗項目檢驗結果
        [HttpPost("setItemsResult")]
        public Response setItemsResult([FromBody] OrderItems orderitems)
        {
            // 回傳的物件
            Response response = new Response();

            try
            {
                using (BeckManContext beckManContext = new BeckManContext())
                {
                    var itemsCode = orderitems.ItemsCode;
                    if (itemsCode == "GI19-9Ag")
                    {
                        itemsCode = "Gl19-9Ag";
                    }
                    var updateItems = (from o in beckManContext.ExOrders
                                       where o.Barcode == orderitems.BarCode && o.Equitemid == itemsCode
                                       select o).FirstOrDefault();
                    if (updateItems != null)
                    {
                        DateTime completeTime = DateTime.Now;
                        updateItems.Dwflag = "2";
                        updateItems.MDate = completeTime.ToString("yyyyMMdd");
                        updateItems.MTime = completeTime.ToString("HHmmss");
                        updateItems.ChdV = orderitems.ItemsResult;
                    }

                    beckManContext.SaveChanges();

                    response.success = true;
                    response.message = "寫入醫令結果完成！";
                    response.data = null;

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "發生例外：" + ex.ToString();
                response.data = null;

                return response;
            }
        }

        // POST 更新檢驗項目檢驗 Flag(comment標籤)
        [HttpPost("setItemsFlag")]
        public Response setItemsFlag([FromBody] OrderItems orderitems)
        {
            // 回傳的物件
            Response response = new Response();

            try
            {
                using (BeckManContext beckManContext = new BeckManContext())
                {
                    var itemsCode = orderitems.ItemsCode;
                    if (itemsCode == "GI19-9Ag")
                    {
                        itemsCode = "Gl19-9Ag";
                    }
                    var updateItems = (from o in beckManContext.ExOrders
                                       where o.Barcode == orderitems.BarCode && o.Equitemid == itemsCode
                                       select o).FirstOrDefault();
                    if (updateItems != null)
                    {
                        updateItems.Meno = orderitems.ItemsFlag;
                    }

                    beckManContext.SaveChanges();

                    response.success = true;
                    response.message = "寫入醫令標籤完成！";
                    response.data = null;

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "發生例外：" + ex.ToString();
                response.data = null;

                return response;
            }
        }
    }
}
