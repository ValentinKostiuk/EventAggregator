using System;
using EventAggregator;
using FluentAssertions;
using NUnit.Framework;

namespace EventAggregatorTests
{
    class TestEventArgs : EventArgs
    {
    }

    [TestFixture]
    public class EventAggregatorTests
    {
        private EventAggregator.EventAggregator _eventAggregator;

        [SetUp]
        public void SetUp()
        {
            _eventAggregator = new EventAggregator.EventAggregator();
        }

        [Test]
        public void ShouldCallSubscribedMethod()
        {
            //arrange
            var wasCalled = false;
            AggregatorEventHandler<EventArgs> act = (o, args) => { wasCalled = true; };
            _eventAggregator.Subscribe(act);

            //action
            _eventAggregator.Publish(null, EventArgs.Empty);

            //assert
            wasCalled.Should().BeTrue();
        }

        [Test]
        public void ShouldCallAllSubscriptionsForSameArgsType()
        {
            //arrange
            var wasCalled1 = false;
            AggregatorEventHandler<EventArgs> act = (o, args) => { wasCalled1 = true; };
            _eventAggregator.Subscribe(act);

            var wasCalled2 = false;
            AggregatorEventHandler<EventArgs> act2 = (o, args) => { wasCalled2 = true; };
            _eventAggregator.Subscribe(act2);

            //action
            _eventAggregator.Publish(null, EventArgs.Empty);

            //assert
            wasCalled1.Should().BeTrue();
            wasCalled2.Should().BeTrue();
        }

        [Test]
        public void ShouldCallSubscriptionsForDifferentArgsType()
        {
            //arrange
            var wasCalled1 = false;
            AggregatorEventHandler<EventArgs> act = (o, args) => { wasCalled1 = true; };
            _eventAggregator.Subscribe(act);

            var wasCalled2 = false;
            AggregatorEventHandler<TestEventArgs> act2 = (o, args) => { wasCalled2 = true; };
            _eventAggregator.Subscribe(act2);

            //action
            _eventAggregator.Publish(null, EventArgs.Empty);
            _eventAggregator.Publish(null, new TestEventArgs());

            //assert
            wasCalled1.Should().BeTrue();
            wasCalled2.Should().BeTrue();
        }

        [Test]
        public void ShouldCallSubscriptionsOnlyForCertainType()
        {
            //arrange
            var wasCalled1 = false;
            AggregatorEventHandler<EventArgs> act = (o, args) => { wasCalled1 = true; };
            _eventAggregator.Subscribe(act);

            var wasCalled2 = false;
            AggregatorEventHandler<TestEventArgs> act2 = (o, args) => { wasCalled2 = true; };
            _eventAggregator.Subscribe(act2);

            //action
            _eventAggregator.Publish(null, new TestEventArgs());

            //assert
            wasCalled1.Should().BeFalse();
            wasCalled2.Should().BeTrue();
        }

        [Test]
        public void ShouldCallWithCorrectArguments()
        {
            //arrange
            var wasCalled1 = false;
            object source = null;
            EventArgs calledArgs = null;
            var expectedArgs = new EventArgs();

            AggregatorEventHandler<EventArgs> act = (o, args) =>
            {
                wasCalled1 = true;
                source = o;
                calledArgs = args;
            };
            _eventAggregator.Subscribe(act);

            //action
            _eventAggregator.Publish(this, expectedArgs);

            //assert
            wasCalled1.Should().BeTrue();
            source.Should().Be(this);
            calledArgs.Should().Be(expectedArgs);
        }

        [Test]
        public void ShouldNotCallUnSubscribedMethod()
        {
            //arrange
            var wasCalled = 0;
            AggregatorEventHandler<EventArgs> act = (o, args) => { wasCalled += 1; };
            var subscription = _eventAggregator.Subscribe(act);

            //action
            _eventAggregator.Publish(null, EventArgs.Empty);
            _eventAggregator.UnSbscribe(subscription);
            _eventAggregator.Publish(null, EventArgs.Empty);

            //assert
            wasCalled.Should().Be(1);
        }

        [Test]
        public void ShouldNotCallDesposedSubscription()
        {
            //arrange
            var wasCalled = 0;
            AggregatorEventHandler<EventArgs> act = (o, args) => { wasCalled += 1; };
            var subscription = _eventAggregator.Subscribe(act);

            //action
            _eventAggregator.Publish(null, EventArgs.Empty);
            subscription.Dispose();
            _eventAggregator.Publish(null, EventArgs.Empty);

            //assert
            wasCalled.Should().Be(1);
        }

        [Test]
        public void ShouldNotCallManyTimes()
        {
            //arrange
            var wasCalled = 0;
            AggregatorEventHandler<EventArgs> act = (o, args) => { wasCalled += 1; };
            _eventAggregator.Subscribe(act);

            //action
            _eventAggregator.Publish(null, EventArgs.Empty);
            _eventAggregator.Publish(null, EventArgs.Empty);
            _eventAggregator.Publish(null, EventArgs.Empty);
            _eventAggregator.Publish(null, EventArgs.Empty);

            //assert
            wasCalled.Should().Be(4);
        }
    }
}