using Newtonsoft.Json;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using zkemkeeper;

namespace Shared {
   public class FingerPrintDevice {
      private readonly string iPAddress;
      private readonly int port;
      private readonly int machineNumber;
      private zkemkeeper.CZKEM FDevice;

      public bool Connected { get; set; }

      public FingerPrintDevice(string IPAddress, int Port, int MachineNumber) {
         iPAddress = IPAddress;
         port = Port;
         machineNumber = MachineNumber;
      }

      public void Connect() {
         FDevice = new CZKEM();
         bool connected = FDevice.Connect_Net(this.iPAddress, this.port);
         if (connected) {
            if (FDevice.RegEvent(this.machineNumber, 65535)) {
               FDevice.OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(MesinAbsen_OnAttTransactionEx);
               Connected = true;
            }
         }
         else {
            Connected = false;
         }
      }

      private async void MesinAbsen_OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode) {

         string nik = sEnrollNumber.ToString();
         int year = DateTime.Now.Year;
         int month = DateTime.Now.Month;
         int day = DateTime.Now.Day;
         string strDate = year.ToString() + "/" + (month < 10 ? "0" + month.ToString() : month.ToString()) + "/" + (day < 10 ? "0" + day.ToString() : day.ToString());

         //await CekJadwalKerja(nik, strDate);
         string strTime = (iHour < 10 ? "0" + iHour.ToString() : iHour.ToString()) + ":" + (iMinute < 10 ? "0" + iMinute.ToString() : iMinute.ToString()) + ":" + (iSecond < 10 ? "0" + iSecond.ToString() : iSecond.ToString());
         string strDateTime = strDate + " " + strTime;

         Console.WriteLine($"NIK: {nik}, DateTime: {strDateTime}, IpAddress: {iPAddress}");

         //MesinRTFinger(sEnrollNumber, strDateTime, _iPAddress);
         await SaveAddAbsenRT(nik, iPAddress, port, machineNumber);

      }

      private async Task SaveAddAbsenRT(string nik, string ip, int port, int noMesin) {
         AttandenceLogDTO attandenceLogDTO = new AttandenceLogDTO {
            NIK = nik,
            deviceID = noMesin.ToString(),
            deviceIP = ip,
            enroll = DateTime.Now
         };

         var content = JsonConvert.SerializeObject(attandenceLogDTO);
         var buffer = Encoding.UTF8.GetBytes(content);
         var byteContent = new ByteArrayContent(buffer);
         byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
         using HttpClient client = new HttpClient();
         //var response = await client.PostAsync("https://localhost:7020/api/AttandenceLog", byteContent);
         client.DefaultRequestHeaders.Accept.Clear();
         client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         var response = await client.PostAsync("http://192.168.10.3/api/AttandenceLog", byteContent);
         Console.WriteLine($"response1: {response.StatusCode}");


      }
   }
}
