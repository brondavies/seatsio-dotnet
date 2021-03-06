using System;
using System.Collections.Generic;
using SeatsioDotNet.Events;
using Xunit;


namespace SeatsioDotNet.Test.Events
{
    public class UpdateChannelsTest : SeatsioClientTest
    {

        [Fact]
        public void UpdateChannels() {
            var chartKey1 = CreateTestChart();
            var event1 = Client.Events.Create(chartKey1);

            var channels = new Dictionary<string, Channel>()
            {
                { "channelKey1", new Channel("channel 1", "#FFFF00", 1) },
                { "channelKey2", new Channel("channel 2", "#00FFFF", 2) }
            };

            Client.Events.UpdateChannels(event1.Key, channels);

            var retrievedEvent = Client.Events.Retrieve(event1.Key);
            Assert.Equal(2, retrievedEvent.Channels.Count);

            var channel1 = retrievedEvent.Channels[0];
            Assert.Equal("channelKey1", channel1.Key);
            Assert.Equal("channel 1", channel1.Name);
            Assert.Equal("#FFFF00", channel1.Color);
            Assert.Equal(1, channel1.Index);
            Assert.Empty(channel1.Objects);


            var channel2 = retrievedEvent.Channels[1];
            Assert.Equal("channelKey2", channel2.Key);
            Assert.Equal("channel 2", channel2.Name);
            Assert.Equal("#00FFFF", channel2.Color);
            Assert.Equal(2, channel2.Index);
            Assert.Empty(channel1.Objects);
        }

    }
}
