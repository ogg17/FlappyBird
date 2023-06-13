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

        [Test]
        public void TestEvents()
        {
            var test = false;

            EventsInstance.Events.TestEvent += OnTest;
            EventsInstance.Events.TestEvent.Invoke();
            EventsInstance.Events.TestEvent -= OnTest;
            Assert.True(test);
            return;

            void OnTest()
            {
                test = true;
            }
        }
    }
}
