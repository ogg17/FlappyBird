using System.Collections;
using EventSystem;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameTestScript
    {
        [Test]
        public void GetEventInstanceTest()
        {
            var result = EventsInstance.Events;
            Assert.True(result != null);
        }
    }
}
