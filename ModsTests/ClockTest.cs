using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mods;
using System;

namespace ModsTests
{
    [TestClass]
    public class ClockTest
    {
        [TestMethod]
        public void TimeCoderTest()
        {
            DateTime time = DateTime.Now;
            byte trueHour;
            if (time.Hour > 12)
            {
                trueHour = (byte)(118 - (time.Hour - 12) * 5 * 2);
            }
            else
            {
                trueHour = (byte)(118 - time.Hour * 5 * 2);
            }
            byte trueMinute = (byte)(118 - time.Minute * 2);
            //byte trueSecond = (byte)(120 - time.Second * 2);

            ClockMode clockMode = new ClockMode();
            byte[,] data = clockMode.GetDataArray();

            byte hour = 0x00;
            byte minute = 0x00;

            for(int i = 0; i < 8; i++)
            {
                hour |= (byte)((data[i + 1, 0] & 0b00000001) << i);
                minute |= (byte)((data[i + 9, 0] & 0b00000001) << i);
            }

            Assert.AreEqual(trueHour, hour);
            Assert.AreEqual(trueMinute, minute);
        }
    }
}
