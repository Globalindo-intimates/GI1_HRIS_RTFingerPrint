// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Shared.DTOs;
using Shared;
using UI.Console2;

Helpers helpers = new Helpers();
var Listmesin = await helpers.GetMesinAbsenAsync();

foreach (MesinAbsenDTO mesin in Listmesin) {
   FingerPrintDevice fD = new FingerPrintDevice(mesin.IpMesin, mesin.Port, mesin.NoMesin);
   fD.Connect();
}

Console.ReadKey();
