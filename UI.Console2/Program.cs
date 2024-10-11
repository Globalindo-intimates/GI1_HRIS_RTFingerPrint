// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Shared.DTOs;
using Shared;
using UI.Console2;
using FingerPrintDevice = UI.Console2.FingerPrintDevice;

Helpers helpers = new Helpers();
List<MesinAbsenDTO> listMesin = new List<MesinAbsenDTO>();
listMesin = await helpers.GetMesinAbsenAsync();

foreach (MesinAbsenDTO mesin in listMesin) {
   FingerPrintDevice fD = new FingerPrintDevice(mesin.IpMesin, mesin.Port, mesin.NoMesin);
   fD.Connect();
}

Console.ReadKey();
