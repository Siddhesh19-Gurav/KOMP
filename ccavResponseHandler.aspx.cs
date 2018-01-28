using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using CCA.Util;
using KitchenOnMyPlate.Classes;
using KitchenOnMyPlate.DataAccess;
using System.Configuration;
using System.Net;
using System.Security.Policy;
using System.IO;
using System.Text;
    
public partial class ResponseHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["GoToPaymentGateway"] != "0")
            {

                string workingKey = "450273C40E328E5C121E04A20281F3E7";//put in the 32bit alpha numeric key in the quotes provided here
                CCACrypto ccaCrypto = new CCACrypto();
                //string res = "0dc0792dac490e63e124ae9d786087dfa3bee306b0b1448b8e7155c66c77b44c60f192a4f5f135208ef3ad261d2c7ca1d32fff366467f40761798c84e2aa1a54ce8820ccb6a047cfd771878374546831da73454e9a03b8bff857f4a9fa9b8999359b576dcda801dcb1e6085288cf9631c2b17a86b9b1f6f537e05374b3d3855fe726cb2d92c07d743f3a0ddc3ff971b1a0ec37489f5397ea2d82023dfbe5cfbb7552643ae9189ad6b1b06915851432897b6698b6e613e0f818bfb0217a406e6cb412fce68ef9de912d9f7ff3c1e8b4975ae30f2ad4ef35c29ca925284297d6e802dbfdaf37b7740b0935ef158985e64cfa40c591ea1ffbaa30927eb2bfb6d2318f753e250c5cff0ec142017cc48a9f09db966d92f7fd3d13c2acbb090d0177212e57ed871dc714fbc0fd26efae80d7f24e1a2a0c7d356d0cbbbe1e219b7e5e9dd4102be6a261d54d9d3a4718578dde3e44195c3732782dddc51bf4b39d91806a90804313d14e60f01640788d4916f304c6d02b05b816c97502065732ff680e05fafffa74f27c891f9bfbadf29414cac6a89e2314dcb1176bd9697e01a4672f24b5695f1926329e6285a9e74fc665bcdde1970b6e5ac03f8735d999cd409608bbd5a859580d57edab3989b8767d5dc267518464cd68a933859ea8e3188b79e41c7f7d5366ccdb6b8212d67073fcdcd31f78f8e9fe1c2eea5b3100a75b2daf0f05cbedd0df694751682ee7f9ed22f5f83673d93bc1140451fd4a540c92f9c4b5451efb36a0b79d64d4f83d33f398950e009f1991198c1750cfe6c434d9cac9221d489fabf5daef97851844a166fd8ccacc0f7035cae15bf67b95de13e0b30ee345fd94d5535bfbf445595b35728c007ca176df964e0c76f9dc612f00a229483b42d2ac537f8289834593811baea58a9def51796883c03e6550463b8a55f09d8873a52c22616edb0cb05a8a54c4d079f17949430204e6770349a5359f3ec318474ef06abb534efa7856318595a4f7dda3a3";
                //string encResponse = ccaCrypto.Decrypt(res, workingKey);
                string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);

                NameValueCollection Params = new NameValueCollection();
                string[] segments = encResponse.Split('&');
                foreach (string seg in segments)
                {
                    string[] parts = seg.Split('=');
                    if (parts.Length > 0)
                    {
                        string Key = parts[0].Trim();
                        string Value = parts[1].Trim();
                        Params.Add(Key, Value);
                    }
                }

                //My Code start
                if (Params.Count > 0)
                {
                    string orderid = Params["order_id"];
                    int paymentStatus = GetStatusNo(Params["order_status"].ToUpper());
                    int paymentMethod = GetPaymentMethodID(Params["payment_mode"].ToUpper());
                    string bankrefno = Params["bank_ref_no"];
                    string card_name = Params["card_name"];
                    string biling_name = Params["billing_name"];

                    OrderManagement.SavePayemt(Convert.ToInt32(orderid), paymentStatus, paymentMethod, card_name, bankrefno, biling_name);


                    var paymentResponse = new PaymentResponse { RequestId = orderid, PaymentDone = paymentStatus.ToString(), PaymentMethod = paymentMethod.ToString(), customerId = Params["customer_id"] };
                    Session["PaymentResponse"] = paymentResponse;
                    DBAccess.CreateSession(Params["billing_email"]);
                    Response.Redirect("ConfirmationPage.aspx");
                }
            }
            else
            {//Gateway Mode Off - for testing only
                string orderid = Request.QueryString["requestId"];
                int paymentStatus = 1;
                int paymentMethod = Convert.ToInt32(Request.QueryString["method"]);// GetPaymentMethodID(Request.QueryString["method"].ToUpper());
                string bankrefno = "1232test";
                string card_name = "rekha";
                string biling_name = "";

                OrderManagement.SavePayemt(Convert.ToInt32(orderid), paymentStatus, paymentMethod, card_name, bankrefno, biling_name);

                #region calling yourguy api

               // CallYourGuy();
                #endregion


                var paymentResponse = new PaymentResponse { RequestId = orderid, PaymentDone = paymentStatus.ToString(), PaymentMethod = paymentMethod.ToString(), customerId = "12345" };
                Session["PaymentResponse"] = paymentResponse;
                //DBAccess.CreateSession(Params["billing_email"]);
                Response.Redirect("ConfirmationPage.aspx");
            }
            //My Code end

            //for (int i = 0; i < Params.Count; i++)
            //{
            //    Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
            //}
           
         }

        int GetStatusNo(string status)
        {
            if (status == "SUCCESS")
            {
                return 1;
            }
            else if (status == "FAILURE")
            {
                return 2;
            }
            else if (status == "INVALID")
            {
                return 3;
            }
            else if (status == "ABORTED")
            {
                return 4;
            }

            return 7;
        }


        private int GetPaymentMethodID(string id)
        {
            int strMethod = 0;

            switch (id)
            {
                case "NET BANKING":
                    strMethod = 1;
                    break;
                case "CREDIT CARD":
                    strMethod = 2;
                    break;
                case "DEBIT CARD":
                    strMethod = 3;
                    break;
                case "CASH CARD":
                    strMethod = 4;
                    break;
                case "MOBILE PAYMENT":
                    strMethod = 5;
                    break;
                case "OFF LINE":
                    strMethod = 11;
                    break;
                
            }
            return strMethod;
        }
        private string GetPaymentMethod(string id)
        {
            string strMethod = string.Empty;

            switch (id)
            {
                case "1":
                    strMethod = "Net Banking";
                    break;
                case "2":
                    strMethod = "Creit Card";
                    break;
                case "3":
                    strMethod = "Debit Card";
                    break;
                case "4":
                    strMethod = "Cash Card";
                    break;
                case "5":
                    strMethod = "Mobile Payment";
                    break;
                case "11":
                    strMethod = "Offline";
                    break;
            }
            return strMethod;
        }
    }
