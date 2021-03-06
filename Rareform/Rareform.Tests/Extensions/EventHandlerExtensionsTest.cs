﻿using NUnit.Framework;
using Rareform.Extensions;
using Rareform.IO;
using System;

namespace Rareform.Tests.Extensions
{
    [TestFixture]
    public class EventHandlerExtensionsTest
    {
        private event EventHandler TestEvent;

        private event EventHandler<DataTransferEventArgs> TestEventGeneric;

        [Test]
        public void RaiseSafe_EventHasSubscriber_EventIsRaised()
        {
            bool handled = false;

            this.TestEvent += (sender, e) => handled = true;

            this.TestEvent.RaiseSafe(this, EventArgs.Empty);

            Assert.IsTrue(handled);
        }

        [Test]
        public void RaiseSafeGeneric_EventHasSubscriver_EventIsRaised()
        {
            bool handled = false;

            this.TestEventGeneric += (sender, e) =>
            {
                Assert.AreEqual(e.TotalBytes, 1);
                Assert.AreEqual(e.TransferredBytes, 100);
                handled = true;
            };

            this.TestEventGeneric.RaiseSafe(this, new DataTransferEventArgs(1, 100));

            Assert.IsTrue(handled);
        }
    }
}