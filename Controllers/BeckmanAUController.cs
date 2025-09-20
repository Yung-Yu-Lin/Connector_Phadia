using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using LIS_Middleware.DataDB;
using LIS_Middleware.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIS_Middleware.Controllers
{
    public class AU_ExamineItems
    {
        public static string DBILC = "DBILC";
        public static string TBILC = "TBILC";
        public static string LIP = "LIP";
        public static string CHOL = "CHOL";
        public static string TG = "TG";
        public static string HDL = "HDL";
        public static string LDL = "LDL";
        public static string ALB = "ALB";
        public static string CA = "CA";
        public static string CREA = "CREA";
        public static string GLUC = "GLUC";
        public static string IRON = "IRON";
        public static string LAC = "LAC";
        public static string MG = "MG";
        public static string UIBC = "UIBC";
        public static string TP = "TP";
        public static string PHOS = "PHOS";
        public static string BUN = "BUN";
        public static string UA = "UA";
        public static string CRP = "CRP";
        public static string CRPHS = "CRPHS";
        public static string APOA1 = "APO A1";
        public static string APOB = "APO B";
        public static string ASO = "ASO";
        public static string C3 = "C3";
        public static string C4 = "C4";
        public static string FERR = "FERR";
        public static string IgA = "IgA";
        public static string IgG = "IgG";
        public static string IgM = "IgM";
        public static string TRF = "TRF";
        public static string AAG = "AAG";
        public static string AAT = "AAT";
        public static string B2M = "B2M";
        public static string CER = "CER";
        public static string HAPT = "HAPT";
        public static string PALB = "PALB";
        public static string RF = "RF";
        public static string W340O = "W340-O";
        public static string W480O = "W480-O";
        public static string W600O = "W600-O";
        public static string R100O = "R100-O";
        public static string R150O = "R150-O";
        public static string S1ulO = "S1ul-O";
        public static string S2ulO = "S2ul-O";
        public static string S5ulO = "S5ul-O";
        public static string UACR = "UACR";
        public static string GLOB = "GLOB";
        public static string AG = "A/G";
        public static string TIBC = "TIBC";
        public static string UCSFP = "UCSFP";
        public static string UALB = "UALB";
        public static string AMM = "AMM";
        public static string ALC = "ALC";
        public static string ALP = "ALP";
        public static string ALT = "ALT";
        public static string UCREA = "UCREA";
        public static string AST = "AST";
        public static string AMY = "AMY";
        public static string CHE = "CHE";
        public static string CK = "CK";
        public static string CKMB = "CK-MB";
        public static string GGT = "GGT";
        public static string LDH = "LDH";
        public static string HCY = "HCY";
        public static string ACT = "ACT";
        public static string CARB = "CARB";
        public static string GEN = "GEN";
        public static string LITH = "LITH";
        public static string PHE = "PHE";
        public static string PHY = "PHY";
        public static string SAL = "SAL";
        public static string THE = "THE";
        public static string VPA = "VPA";
        public static string VANC = "VANC";
        public static string LIH = "LIH";
        public static string Na = "Na";
        public static string K = "K";
        public static string Cl = "Cl";
        public static string AMIK = "AMIK";
        public static string EVER = "EVER";
        public static string TAC = "TAC";
        public static string CSAL = "CSAL";
        public static string CSAH = "CSAH";
        public static string IgE = "IgE";
        public static string W340I = "W340-I";
        public static string W480I = "W480-I";
        public static string W600I = "W600-I";
        public static string S5ulI = "S5ul-I";
        public static string S2ulI = "S2ul-I";
        public static string S1ulI = "S1ul-I";
        public static string R150I = "R150I";
        public static string R10 = "R10";
        public static string AC = "AC";
        public static string AC1 = "AC1";
        public static string PC = "PC";
    }

    [Route("AU")]
    public class BeckmanAUController : Controller
    {
        private static readonly string[] ExamineItems = new[]
        {
            "DBILC", "TBILC", "LIP", "CHOL", "TG", "HDL", "LDL", "ALB", "CA", "CREA", "GLUC", "IRON", "LAC", "MG", "UIBC", "TP", "PHOS", "BUN", "UA", "CRP", "CRPHS", "APO A1", "APO B", "ASO", "C3", "C4", "FERR", "IgA", "IgG", "IgM", "TRF", "AAG", "AAT", "B2M", "CER", "HAPT", "PALB", "RF", "W340-O", "W480-O", "W600-O", "R100-O", "R150-O", "S1ul-O", "S2ul-O", "S5ul-O", "UACR", "GLOB", "A/G", "TIBC", "UCSFP", "UALB", "AMM", "ALC", "ALP", "ALT", "UCREA", "AST", "AMY", "CHE", "CK", "CK-MB", "GGT", "LDH", "HCY", "ACT", "CARB", "GEN", "LITH", "PHE", "PHY", "SAL", "THE", "VPA", "VANC", "LIH", "Na", "K", "Cl", "AMIK", "EVER", "TAC", "CSAL", "CSAH", "IgE", "W340-I", "W480-I", "W600-I", "S5ul-I", "S2ul-I", "S1ul-I", "R150I", "R100I", "AC", "AC1", "PC"
        };

        Dictionary<string, string> AU_ExamineItems_Dic = new Dictionary<string, string>()
        {
            { AU_ExamineItems.DBILC, "001" },
            { AU_ExamineItems.TBILC, "003" },
            { AU_ExamineItems.LIP, "005" },
            { AU_ExamineItems.CHOL, "006" },
            { AU_ExamineItems.TG, "007" },
            { AU_ExamineItems.HDL, "008" },
            { AU_ExamineItems.LDL, "009" },
            { AU_ExamineItems.ALB, "010" },
            { AU_ExamineItems.CA, "012" },
            { AU_ExamineItems.CREA, "013" },
            { AU_ExamineItems.GLUC, "014" },
            { AU_ExamineItems.AC, "014" }, // 08/07 台南張老闆 要求 AC, AC1, PC 都指向 GLUC
            { AU_ExamineItems.AC1, "014" }, // 08/07 台南張老闆 要求 AC, AC1, PC 都指向 GLUC
            { AU_ExamineItems.PC, "014" }, // 08/07 台南張老闆 要求 AC, AC1, PC 都指向 GLUC
            { AU_ExamineItems.IRON, "015" },
            { AU_ExamineItems.LAC, "016" },
            { AU_ExamineItems.MG, "017" },
            { AU_ExamineItems.UIBC, "018" },
            { AU_ExamineItems.TP, "019" },
            { AU_ExamineItems.PHOS, "020" },
            { AU_ExamineItems.BUN, "021" },
            { AU_ExamineItems.UA, "022" },
            { AU_ExamineItems.CRP, "023" },
            { AU_ExamineItems.CRPHS, "024" },
            { AU_ExamineItems.APOA1, "025" },
            { AU_ExamineItems.APOB, "026" },
            { AU_ExamineItems.ASO, "027" },
            { AU_ExamineItems.C3, "028" },
            { AU_ExamineItems.C4, "029" },
            { AU_ExamineItems.FERR, "030" },
            { AU_ExamineItems.IgA, "031" },
            { AU_ExamineItems.IgG, "032" },
            { AU_ExamineItems.IgM, "033" },
            { AU_ExamineItems.TRF, "034" },
            { AU_ExamineItems.AAG, "035" },
            { AU_ExamineItems.AAT, "036" },
            { AU_ExamineItems.B2M, "037" },
            { AU_ExamineItems.CER, "038" },
            { AU_ExamineItems.HAPT, "039" },
            { AU_ExamineItems.PALB, "041" },
            { AU_ExamineItems.RF, "042" },
            { AU_ExamineItems.W340O, "044" },
            { AU_ExamineItems.W480O, "045" },
            { AU_ExamineItems.W600O, "046" },
            { AU_ExamineItems.R100O, "047" },
            { AU_ExamineItems.R150O, "048" },
            { AU_ExamineItems.S1ulO, "049" },
            { AU_ExamineItems.S2ulO, "050" },
            { AU_ExamineItems.S5ulO, "051" },
            { AU_ExamineItems.UACR, "057" },
            { AU_ExamineItems.GLOB, "058" },
            { AU_ExamineItems.AG, "059" },
            { AU_ExamineItems.TIBC, "060" },
            { AU_ExamineItems.UCSFP, "061" },
            { AU_ExamineItems.UALB, "062" },
            { AU_ExamineItems.AMM, "063" },
            { AU_ExamineItems.ALC, "064" },
            { AU_ExamineItems.ALP, "065" },
            { AU_ExamineItems.ALT, "066" },
            { AU_ExamineItems.UCREA, "067" },
            { AU_ExamineItems.AST, "068" },
            { AU_ExamineItems.AMY, "070" },
            { AU_ExamineItems.CHE, "071" },
            { AU_ExamineItems.CK, "072" },
            { AU_ExamineItems.CKMB, "073" },
            { AU_ExamineItems.GGT, "074" },
            { AU_ExamineItems.LDH, "075" },
            { AU_ExamineItems.HCY, "078" },
            { AU_ExamineItems.ACT, "079" },
            { AU_ExamineItems.CARB, "080" },
            { AU_ExamineItems.GEN, "082" },
            { AU_ExamineItems.LITH, "083" },
            { AU_ExamineItems.PHE, "084" },
            { AU_ExamineItems.PHY, "085" },
            { AU_ExamineItems.SAL, "086" },
            { AU_ExamineItems.THE, "087" },
            { AU_ExamineItems.VPA, "088" },
            { AU_ExamineItems.VANC, "089" },
            { AU_ExamineItems.LIH, "096" },
            { AU_ExamineItems.Na, "097" },
            { AU_ExamineItems.K, "098" },
            { AU_ExamineItems.Cl, "099" },
            { AU_ExamineItems.AMIK, "106" },
            { AU_ExamineItems.EVER, "107" },
            { AU_ExamineItems.TAC, "108" },
            { AU_ExamineItems.CSAL, "109" },
            { AU_ExamineItems.CSAH, "110" },
            { AU_ExamineItems.IgE, "111" },
            { AU_ExamineItems.W340I, "113" },
            { AU_ExamineItems.W480I, "114" },
            { AU_ExamineItems.W600I, "115" },
            { AU_ExamineItems.S5ulI, "116" },
            { AU_ExamineItems.S2ulI, "117" },
            { AU_ExamineItems.S1ulI, "118" },
            { AU_ExamineItems.R150I, "119" },
            { AU_ExamineItems.R10, "120" }
        };

        // GET AU/getItems/{Barcode}
        // 第一步：當儀器Call連線程式，連線程式就會發送 HttpRequest 來這一支API 取得AU要檢驗的項目
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
                                                      ItemsCode = AU_ExamineItems_Dic[o.Equitemid],
                                                      ItemsName = o.Equitemid
                                                  }).ToList();
                    // 針對 總鐵結合能（TIBC）= 不飽和鐵結合能（UIBC）+ 鐵蛋白（IRON） 特別處理：
                    Orders _tibcCount = pendingOrders.FindAll(x => x.ItemsName == AU_ExamineItems.TIBC).FirstOrDefault();
                    int _uibcCount = pendingOrders.FindAll(x => x.ItemsName == AU_ExamineItems.UIBC).Count;
                    int _ironCount = pendingOrders.FindAll(x => x.ItemsName == AU_ExamineItems.IRON).Count;
                    if (_tibcCount != null && _uibcCount == 0)
                    {
                        pendingOrders.Add(new Orders{
                            BarCode = _tibcCount.BarCode,
                            PatientID = _tibcCount.PatientID,
                            PatientName = _tibcCount.PatientName,
                            PatientGender = _tibcCount.PatientGender,
                            ItemsCode = AU_ExamineItems_Dic[AU_ExamineItems.UIBC],
                            ItemsName = AU_ExamineItems.UIBC
                        });
                    }
                    if (_tibcCount != null && _ironCount == 0)
                    {
                        pendingOrders.Add(new Orders
                        {
                            BarCode = _tibcCount.BarCode,
                            PatientID = _tibcCount.PatientID,
                            PatientName = _tibcCount.PatientName,
                            PatientGender = _tibcCount.PatientGender,
                            ItemsCode = AU_ExamineItems_Dic[AU_ExamineItems.IRON],
                            ItemsName = AU_ExamineItems.IRON
                        });
                    }

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
        // 第二步：當檢驗項目經連線程式送往儀器後，更新檢驗項目的狀態和日期
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
        // 第三步：當檢驗項目經儀器將結果送往連線程式，更新檢驗項目的結果值和結果日期
        [HttpPost("setItemsResult")]
        public Response setItemsResult([FromBody] OrderItems orderItems)
        {
            // 回傳的物件
            Response response = new Response();

            try
            {
                string itemsCode = AU_ExamineItems_Dic.FirstOrDefault(x => x.Value == orderItems.ItemsCode).Key;
                using (BeckManContext beckManContext = new BeckManContext())
                {
                    var updateItems = (from o in beckManContext.ExOrders
                                       where o.Barcode == orderItems.BarCode && o.Equitemid == itemsCode
                                       select o).FirstOrDefault();
                    if (updateItems != null)
                    {
                        DateTime completeTime = DateTime.Now;
                        updateItems.Dwflag = "2";
                        updateItems.MDate = completeTime.ToString("yyyyMMdd");
                        updateItems.MTime = completeTime.ToString("HHmmss");
                        updateItems.ChdV = orderItems.ItemsResult;
                        updateItems.Meno = orderItems.ItemsFlag;
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
    }
}
