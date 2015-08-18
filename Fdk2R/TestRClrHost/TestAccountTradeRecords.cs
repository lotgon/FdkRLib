using System;
using NUnit.Framework;
using RHost;
namespace TestRClrHost
{
	[TestFixture]
	public class TestAccountTradeRecords
	{
		[Test]
		public void TestGetTradeRecords()
		{
			//Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
			Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
			var time = DateTime.Now;
			var prevTime = time.AddHours(-120);
			var bars = FdkTradeReports.GetTradeTransactionReport(prevTime, time);
			var comission = FdkTradeReports.GetTradeAgentCommission(bars);
			FdkVars.Unregister(bars);
		}
	}
}

