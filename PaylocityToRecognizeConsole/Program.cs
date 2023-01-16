// See https://aka.ms/new-console-template for more information
using PaylocityHelper;

var paylocityService = new ConnectToPaylocity.Service.Controllers.PaylocityToRecognizeServiceController();

var result = await paylocityService.GetEmployees();

RecognizeUtility.WriteToCSVFile(result);

Console.WriteLine("Hello, World!");
