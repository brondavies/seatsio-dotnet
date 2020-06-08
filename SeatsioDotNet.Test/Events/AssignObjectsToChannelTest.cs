using System;
using System.Collections.Generic;
using SeatsioDotNet.Events;
using Xunit;


namespace SeatsioDotNet.Test.Events
{
    public class AssignObjectsToChannelTest : SeatsioClientTest
    {

        [Fact]
        public void assignObjectsToChannel() {
            var chartKey1 = CreateTestChart();
            var event1 = Client.Events.Create(chartKey1);
            var channels = new
            {
                channelKey1 = new
                {
                    name = "channel 1",
                    color = "#FFFF00",
                    index = 1
                },
                channelKey2 = new
                {
                    name = "channel 2",
                    color = "#00FFFF",
                    index = 2
                }
            };
            Client.Events.UpdateChannels(event1.Key, channels);

            Client.Events.AssignObjectsToChannel(event1.Key, new
            {
                channelKey1 = new [] {"A-1", "A-2"},
                channelKey2 = new [] {"A-3"},
            });

            var retrievedChannels = Client.Events.Retrieve(event1.Key).Channels;
            Assert.Equal(new [] {"A-1", "A-2"}, retrievedChannels[0].Objects);
            Assert.Equal(new [] {"A-3"}, retrievedChannels[1].Objects);
        }
    }
}
