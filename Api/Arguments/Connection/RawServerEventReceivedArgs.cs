namespace AdiIRCAPIv2.Arguments.Connection
{
    using System;
    using System.Collections.Generic;
    using Enumerators;
    using Interfaces;

    /// <summary>
    ///     Arguments class passed to the RawServerEventReceived event
    /// </summary>
    public class RawServerEventReceivedArgs : EventArgs
    {
        private readonly IServer server;
        private readonly string numeric;
        private readonly string message;
        private readonly string rawMessage;
        private readonly string rawBytes;
        private readonly DateTime serverTime;
        private readonly IDictionary<string, string> messageTags;
        private EatData eatData;

        /// <summary>
        ///     Constructor for arguments class passed to the RawServerEventReceived event
        /// </summary>
        /// <param name="server">IServer</param>
        /// <param name="numeric">string</param>
        /// <param name="message">string</param>
        /// <param name="rawMessage">string</param>
        /// <param name="rawBytes">string</param>
        /// <param name="serverTime">DateTime</param>
        /// <param name="messageTags">IDictionary></param>
        /// <param name="eatData">EatData></param>
        public RawServerEventReceivedArgs(IServer server, string numeric, string message, string rawMessage, string rawBytes, DateTime serverTime, IDictionary<string, string> messageTags, EatData eatData)
        {
            this.server = server;
            this.numeric = numeric;
            this.message = message;
            this.rawMessage = rawMessage;
            this.rawBytes = rawBytes;
            this.serverTime = serverTime;
            this.messageTags = messageTags;
            this.eatData = eatData;
        }

        /// <summary>
        ///     The IServer where the event occured
        /// </summary>
        public IServer Server { get { return this.server; } }

        /// <summary>
        ///     The raw numeric received
        /// </summary>
        /// <remarks>
        ///     Can be a string event if the string is not supported by AdiIRC
        /// </remarks>
        public string Numeric { get { return this.numeric; } }

        /// <summary>
        ///     The raw message
        /// </summary>
        public string Message { get { return this.message; } }

        /// <summary>
        ///     Returns the raw event message
        /// </summary>
        public string RawMessage { get { return this.rawMessage; } }

        /// <summary>
        ///     Returns the raw event message without decoding
        /// </summary>
        public string RawBytes { get { return this.rawBytes; } }

        /// <summary>
        ///     Returns the time the event was recieved
        /// </summary>
        /// <remarks>
        ///     If no IRCv3 @time tag was found in the raw line, returns the current time in UTC format
        /// </remarks>
        public DateTime ServerTime { get { return this.serverTime; } }

        /// <summary>
        ///     Returns a list of IRCv3 tags found in the raw line
        /// </summary>
        public IDictionary<string, string> MessageTags { get { return this.messageTags; } }

        /// <summary>
        ///     Gets or sets the current event proccessing state
        /// </summary>
        public EatData EatData { get { return this.eatData; } set { this.eatData = value; } }
    }
}